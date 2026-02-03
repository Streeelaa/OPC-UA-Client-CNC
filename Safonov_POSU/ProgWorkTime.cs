using Safonov_POSU;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Safonov_POSU.SimpleOPCClient;
namespace OPCClientApp
{
    public partial class ProgWorkTime : UserControl, IOPCClientControl
    {
        private SimpleOPCClient _client;
        private List<OPCUnsubscribeObject> _subscriptions = new List<OPCUnsubscribeObject>();
        public ProgWorkTime()
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
        private void _client_NodeValueChanged(object sender, NodeValueChangedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                switch (e.nodeId)
                {
                    case "ns=1;s=127.0.0.1/WorkTime":
                        labelWorkTime1.Text = e.nodeValue;
                        break;
                    case "ns=1;s=127.0.0.1/Channel 1/Program work time":
                        labelWorkTime2.Text = e.nodeValue;
                        break;
                    case "ns=1;s=127.0.0.1/Channel 1/Program percent":
                        progressBarWorkTime.Value = int.Parse(e.nodeValue);
                        break;
                }
            }));
        }
        private void _client_ConnectComplete(object sender, EventArgs e)
        {
            if (_client.ConnectionStatus == true)
            {
                _subscriptions.Add(_client.SubscribeNodeValue("ns=1;s=127.0.0.1/WorkTime", 1000));
                _subscriptions.Add(_client.SubscribeNodeValue("ns=1;s=127.0.0.1/Channel 1/Program work time", 1000));

                _subscriptions.Add(_client.SubscribeNodeValue("ns=1;s=127.0.0.1/Channel 1/Program percent", 1000));
            }
            else
            {
                _subscriptions.Clear();
            }
        }
    }
}
