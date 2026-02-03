using OPCClientApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Safonov_POSU.SimpleOPCClient;

namespace Safonov_POSU
{
    public partial class Form1 : Form
    {
        private SimpleOPCClient _opcClient;
        public Form1()
        {
            InitializeComponent();
            _opcClient = new SimpleOPCClient();
            _opcClient.ConnectComplete += _opcClient_ConnectComplete;
            _opcClient.NodeValueChanged += _opcClient_NodeValueChanged;
            foreach (var control in this.Controls)
            {
                if (control is IOPCClientControl)
                    (control as IOPCClientControl).Init(_opcClient);
            }
        }

        private void _opcClient_NodeValueChanged(object sender, NodeValueChangedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {

                if (e.nodeId.Contains("WorkTime"))
                {
                    labelNodeValue.Text = e.nodeValue;
                }
                else if (e.nodeId.Contains("Axis 1 (X)"))
                {
                    labelX.Text = "X: " + e.nodeValue;
                }
                else if (e.nodeId.Contains("Axis 2 (Y)"))
                {
                    labelY.Text = "Y: " + e.nodeValue;
                }
                else if (e.nodeId.Contains("Axis 3 (Z)"))
                {
                    labelZ.Text = "Z: " + e.nodeValue;
                }
            }));
        }



        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                await _opcClient.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _opcClient.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void labelConnectionStatus_Click(object sender, EventArgs e)
        {

        }
        private void _opcClient_ConnectComplete(object sender, EventArgs e)
        {
            if (_opcClient.ConnectionStatus == true)
            {
                this.labelConnectionStatus.BackColor = Color.Green;
                this.labelConnectionStatus.Text = "Соединено";
            }
            else
            {
                this.labelConnectionStatus.BackColor = Color.Red;
                this.labelConnectionStatus.Text = "Не соединено";
            }
        }

        private void buttonReadNodeValue_Click(object sender, EventArgs e)
        {
            buttonUnsubTest_Click(null, null);
            // 1. Читаем время работы (WorkTime)
            // Адрес узла мы выяснили ранее
            string valTime = _opcClient.ReadNodeValue("ns=1;s=127.0.0.1/WorkTime");
            labelNodeValue.Text = valTime;

            // 2. Читаем координату X (CurPos - текущая позиция)
            // Адрес берем из таблицы нод в Лаб №1
            string valX = _opcClient.ReadNodeValue("ns=1;s=127.0.0.1/Channel 1/Axis 1 (X)/CurPos");
            labelX.Text = "X: " + valX;

            // 3. Читаем координату Y
            string valY = _opcClient.ReadNodeValue("ns=1;s=127.0.0.1/Channel 1/Axis 2 (Y)/CurPos");
            labelY.Text = "Y: " + valY;

            // 4. Читаем координату Z
            string valZ = _opcClient.ReadNodeValue("ns=1;s=127.0.0.1/Channel 1/Axis 3 (Z)/CurPos");
            labelZ.Text = "Z: " + valZ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonGetTree_Click(object sender, EventArgs e)
        {
            List<string> structure = _opcClient.ReadServerNodeStructure();
            richTextBox1.Clear();
            foreach (string line in structure)
            {
                richTextBox1.AppendText(line + Environment.NewLine);
            }
        }
        OPCUnsubscribeObject _workTimeUnsub = null;
        private OPCUnsubscribeObject _xUnsub;
        private OPCUnsubscribeObject _yUnsub;
        private OPCUnsubscribeObject _zUnsub;
        private void buttonSubTest_Click(object sender, EventArgs e)
        {
            try
            {
                // ВАЖНО: Сначала пытаемся отписаться от старых подписок,
                // чтобы не создавать дубликатов ("призраков"), которые невозможно остановить.
                buttonUnsubTest_Click(null, null);

                // Теперь создаем новые подписки
                _workTimeUnsub = _opcClient.SubscribeNodeValue("ns=1;s=127.0.0.1/WorkTime", 1000);

                // Подписки на оси (интервал 250 мс)
                _xUnsub = _opcClient.SubscribeNodeValue("ns=1;s=127.0.0.1/Channel 1/Axis 1 (X)/CurPos", 250);
                _yUnsub = _opcClient.SubscribeNodeValue("ns=1;s=127.0.0.1/Channel 1/Axis 2 (Y)/CurPos", 250);
                _zUnsub = _opcClient.SubscribeNodeValue("ns=1;s=127.0.0.1/Channel 1/Axis 3 (Z)/CurPos", 250);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подписки: " + ex.Message);
            }
        }
        private void buttonUnsubTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (_workTimeUnsub != null)
                {
                    _workTimeUnsub.Dispose();
                }
                if (_xUnsub != null)
                {
                    _xUnsub.Dispose();
                }
                if (_yUnsub != null)
                {
                    _yUnsub.Dispose();
                }
                if (_zUnsub != null)
                {
                    _zUnsub.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _workTimeUnsub = null;
                _xUnsub = null;
                _yUnsub = null;
                _zUnsub = null;
            }
        }
    }
}