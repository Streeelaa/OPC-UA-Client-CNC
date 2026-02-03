using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using Opc.Ua;
using System.Diagnostics;

namespace Safonov_POSU
{
    internal class NodeValueChangedEventArgs : EventArgs
    {
        public string nodeId;
        public string nodeValue;
        public NodeValueChangedEventArgs(string nodeId, string nodeValue)
        {
            this.nodeId = nodeId;
            this.nodeValue = nodeValue;
        }
    }
    internal class SimpleOPCClient
    {
        private ApplicationInstance application;
        private Session m_session;
        /// <summary>
        /// Значения параметров сессии по умолчанию
        /// </summary>
        public static readonly uint DefaultSessionTimeout = 60000;
        public static readonly int DefaultDiscoverTimeout = 15000;
        public static readonly int DefaultReconnectPeriod = 1;
        public static readonly int DefaultReconnectPeriodExponentialBackOff = 10;
        public SimpleOPCClient()
        {
            application = new ApplicationInstance();
            application.ApplicationConfiguration = new ApplicationConfiguration();
            application.ApplicationType = ApplicationType.Client;
            application.ConfigSectionName = "SimpleOPCClient";
            application.LoadApplicationConfiguration(false).Wait();
        }
        private async Task<Session> InternalConnect(string serverUrl, bool useSecurity, uint sessionTimeout)
        {
            //согласование точки подключения к серверу
            var endpointDescription = CoreClientUtils.SelectEndpoint(application.ApplicationConfiguration, serverUrl, useSecurity, DefaultDiscoverTimeout);
            var endpointConfiguration = EndpointConfiguration.Create(application.ApplicationConfiguration);
            var endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
            //создание сессии
            m_session = await Session.Create(application.ApplicationConfiguration,
                endpoint,
                false,
                true,
                application.ApplicationConfiguration.ApplicationName,
                sessionTimeout == 0 ? DefaultSessionTimeout : sessionTimeout,
                null,
                null);
            //подписка на событие поддержания активности соединения
            m_session.KeepAlive += session_KeepAlive;
            //выдача наружу события о изменении статуса соединения
            if (m_ConnectComplete != null)
                m_ConnectComplete(this, null);
            return m_session;
        }
        public Task<Session> Connect()
        {
            return InternalConnect("opc.tcp://127.0.0.1:4840", false, 0);
        }
        private void session_KeepAlive(ISession session, KeepAliveEventArgs e)
        {
            if (Object.ReferenceEquals(session, m_session))
            {
                if (ServiceResult.IsBad(e.Status))
                {
                    this.Disconnect();
                }
            }
        }
        /// <summary>
        /// Событие генерируется после успешного соединения или отключения от сервера
        /// </summary>
        private EventHandler m_ConnectComplete;
        public event EventHandler ConnectComplete
        {
            add { m_ConnectComplete += value; }
            remove { m_ConnectComplete -= value; }
        }
        public bool ConnectionStatus
        {
            get => (m_session != null) ? m_session.Connected : false;
        }
        public void Disconnect()
        {
            //отключаем существующую сессию
            if (m_session != null)
            {
                //отписывыемся от события KeepAlive
                m_session.KeepAlive -= session_KeepAlive;
                //закрываем сессию
                m_session.Close(10000);
                m_session = null;
            }
            //выдача события об отключении
            if (m_ConnectComplete != null)
                m_ConnectComplete(this, null);
        }
        public string ReadNodeValue(string strNodeId)
        {
            if ((m_session == null) || (ConnectionStatus == false))
                return string.Empty;
            NodeId nodeId = new NodeId(strNodeId);
            DataValue val = m_session.ReadValue(nodeId);
            return val.ToString();
        }
        public List<string> ReadServerNodeStructure()
        {
            List<string> retVal = new List<string>();
            if ((m_session == null) || (ConnectionStatus == false))
                return retVal;
            ReferenceDescriptionCollection refs;
            Byte[] cp;
            m_session.Browse(null, null,
            ObjectIds.ObjectsFolder,
            0u,
            BrowseDirection.Forward,
            ReferenceTypeIds.HierarchicalReferences,
            true,
            (uint)NodeClass.Object,
            out cp, out refs);
            foreach (ReferenceDescription rd in refs)
            {
                string str = string.Format("{0}: {1}", rd.DisplayName, rd.NodeClass);
                retVal.Add(str);
                retVal.AddRange(BrowseOPCObject(rd, 0));
            }
            return retVal;
        }
        private List<string> BrowseOPCObject(ReferenceDescription rd, int level)
        {
            List<string> retVal = new List<string>();
            byte[] nextCp;
            ReferenceDescriptionCollection nextRefs;
            m_session.Browse(null, null,
            ExpandedNodeId.ToNodeId(rd.NodeId, m_session.NamespaceUris),
            0u,
            BrowseDirection.Forward,
            ReferenceTypeIds.HierarchicalReferences,
            true,
            (uint)NodeClass.Variable | (uint)NodeClass.Object,
            out nextCp, out nextRefs);
            string strPadding = new String(' ', 2 * level);
            foreach (var nextRd in nextRefs)
            {
                switch (nextRd.NodeClass)
                {
                    case NodeClass.Object:
                        retVal.Add(strPadding + string.Format("+ {0}: {1}", nextRd.DisplayName,
                       nextRd.NodeClass));
                        retVal.AddRange(BrowseOPCObject(nextRd, level + 1));
                        break;
                    case NodeClass.Variable:
                        DataValue dv = m_session.ReadValue((NodeId)nextRd.NodeId);
                        string strValueType = dv.WrappedValue.TypeInfo.BuiltInType.ToString();
                        retVal.Add(strPadding + string.Format("+ {0}: {1}, {2}", nextRd.DisplayName,
                       nextRd.NodeClass, strValueType));
                        break;
                }
            }
            return retVal;
        }
        private EventHandler<NodeValueChangedEventArgs> m_NodeValueChanged;
        public event EventHandler<NodeValueChangedEventArgs> NodeValueChanged
        {
            add { m_NodeValueChanged += value; }
            remove { m_NodeValueChanged -= value; }
        }
        public OPCUnsubscribeObject SubscribeNodeValue(string strNodeId, int publishingInterval)
        {
            if ((m_session == null) || (ConnectionStatus == false))
                return null;
            NodeId nodeId = new NodeId(strNodeId);
            //ищем подписку с заданным интервалом обновления, если не нашли - создаем
            Subscription sub = m_session.Subscriptions.FirstOrDefault((s) => s.PublishingInterval == publishingInterval);
            if (sub == null)
            {
                sub = new Subscription()
                {
                    PublishingEnabled = true,
                    PublishingInterval = 1000,
                    Priority = 1,
                    KeepAliveCount = 10,
                    LifetimeCount = 30,
                    MaxNotificationsPerPublish = 1000
                };
                m_session.AddSubscription(sub);
                sub.Create();
            }
            //ищем в подписке узел с заданным Id, если не нашли - создаем
            MonitoredItem item = sub.MonitoredItems.FirstOrDefault((mi) => mi.StartNodeId ==
           nodeId);
            if (item == null)
            {
                MonitoredItem monitoredItem = new MonitoredItem();
                monitoredItem.StartNodeId = nodeId;
                monitoredItem.AttributeId = Attributes.Value;
                monitoredItem.Notification += MonitoredItem_Notification;
                sub.AddItem(monitoredItem);
                sub.ApplyChanges();
                OPCUnsubscribeObject unsub = new OPCUnsubscribeObject(monitoredItem);
                return unsub;
            }
            return null;
        }
        private void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            var itemNotification = e.NotificationValue as MonitoredItemNotification;
            if (itemNotification != null)
            {
                Debug.WriteLine(monitoredItem.StartNodeId.ToString() + ": " +
               itemNotification.Value.ToString());
                if (m_NodeValueChanged != null)
                {
                    m_NodeValueChanged(this, new
                   NodeValueChangedEventArgs(monitoredItem.StartNodeId.ToString(),
                   itemNotification.Value.ToString()));
                }
            }
        }
        public class OPCUnsubscribeObject : IDisposable
        {
            private MonitoredItem item;
            public OPCUnsubscribeObject(MonitoredItem item)
            {
                this.item = item;
            }
            public void Dispose()
            {
                Unsubscribe();
            }
            private void Unsubscribe()
            {
                if ((item != null) && (item.Subscription != null))
                {
                    var sub = item.Subscription;
                    sub.RemoveItem(item);
                    sub.ApplyChanges();
                    Debug.WriteLine("Unsubscribed " + item.DisplayName);
                }
            }
        }

    }
}
