using OPCClientApp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Safonov_POSU.SimpleOPCClient;

namespace Safonov_POSU
{
    public partial class ChannelStateControl : UserControl, IOPCClientControl
    {
        private SimpleOPCClient _client;
        private List<OPCUnsubscribeObject> _subscriptions = new List<OPCUnsubscribeObject>();

        public ChannelStateControl()
        {
            InitializeComponent();
        }

        void IOPCClientControl.Init(SimpleOPCClient client)
        {
            _subscriptions.Clear();
            _client = client;

            if (_client != null)
            {
                _client.ConnectComplete += _client_ConnectComplete;
                _client.NodeValueChanged += _client_NodeValueChanged;
            }
        }

        private void _client_ConnectComplete(object sender, EventArgs e)
        {
            if (_client.ConnectionStatus)
            {
                var subMode = _client.SubscribeNodeValue("ns=1;s=127.0.0.1/Channel 2/Mode", 1000);
                if (subMode != null) _subscriptions.Add(subMode);

                var subState = _client.SubscribeNodeValue("ns=1;s=127.0.0.1/Channel 2/State", 1000);
                if (subState != null) _subscriptions.Add(subState);
            }
            else
            {
                _subscriptions.Clear();
            }
        }

        private void _client_NodeValueChanged(object sender, NodeValueChangedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (e.nodeId.Contains("Channel 2/Mode"))
                {
                    labelModeValue.Text = e.nodeValue;
                }
                else if (e.nodeId.Contains("Channel 2/State"))
                {
                    labelStateValue.Text = e.nodeValue;
                }
            }));
        }
    }
}