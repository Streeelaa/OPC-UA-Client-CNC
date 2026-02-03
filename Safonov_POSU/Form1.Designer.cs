namespace Safonov_POSU
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonReadNodeValue = new System.Windows.Forms.Button();
            this.labelNodeValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonGetTree = new System.Windows.Forms.Button();
            this.buttonSubTest = new System.Windows.Forms.Button();
            this.buttonUnsubTest = new System.Windows.Forms.Button();
            this.channelStateControl1 = new Safonov_POSU.ChannelStateControl();
            this.progWorkTime1 = new OPCClientApp.ProgWorkTime();
            this.SuspendLayout();
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(560, 51);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(78, 13);
            this.labelConnectionStatus.TabIndex = 0;
            this.labelConnectionStatus.Text = "Не соединено";
            this.labelConnectionStatus.Click += new System.EventHandler(this.labelConnectionStatus_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(362, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(166, 43);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Соединиться";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(362, 61);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(166, 43);
            this.buttonDisconnect.TabIndex = 2;
            this.buttonDisconnect.Text = "Отключиться";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonReadNodeValue
            // 
            this.buttonReadNodeValue.Location = new System.Drawing.Point(362, 148);
            this.buttonReadNodeValue.Name = "buttonReadNodeValue";
            this.buttonReadNodeValue.Size = new System.Drawing.Size(166, 43);
            this.buttonReadNodeValue.TabIndex = 3;
            this.buttonReadNodeValue.Text = "Прочитать";
            this.buttonReadNodeValue.UseVisualStyleBackColor = true;
            this.buttonReadNodeValue.Click += new System.EventHandler(this.buttonReadNodeValue_Click);
            // 
            // labelNodeValue
            // 
            this.labelNodeValue.AutoSize = true;
            this.labelNodeValue.Location = new System.Drawing.Point(654, 148);
            this.labelNodeValue.Name = "labelNodeValue";
            this.labelNodeValue.Size = new System.Drawing.Size(28, 13);
            this.labelNodeValue.TabIndex = 4;
            this.labelNodeValue.Text = "0:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ops Server time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Coordinate X";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(654, 177);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(22, 13);
            this.labelX.TabIndex = 7;
            this.labelX.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Coordinate Y";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(654, 204);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(22, 13);
            this.labelY.TabIndex = 9;
            this.labelY.Text = "0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(560, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Coordinate Z";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(654, 230);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(22, 13);
            this.labelZ.TabIndex = 11;
            this.labelZ.Text = "0.0";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(-10, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(363, 308);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // buttonGetTree
            // 
            this.buttonGetTree.Location = new System.Drawing.Point(240, 276);
            this.buttonGetTree.Name = "buttonGetTree";
            this.buttonGetTree.Size = new System.Drawing.Size(104, 33);
            this.buttonGetTree.TabIndex = 13;
            this.buttonGetTree.Text = "Подписаться";
            this.buttonGetTree.UseVisualStyleBackColor = true;
            this.buttonGetTree.Click += new System.EventHandler(this.buttonGetTree_Click);
            // 
            // buttonSubTest
            // 
            this.buttonSubTest.Location = new System.Drawing.Point(362, 197);
            this.buttonSubTest.Name = "buttonSubTest";
            this.buttonSubTest.Size = new System.Drawing.Size(166, 41);
            this.buttonSubTest.TabIndex = 14;
            this.buttonSubTest.Text = "Подписаться";
            this.buttonSubTest.UseVisualStyleBackColor = true;
            this.buttonSubTest.Click += new System.EventHandler(this.buttonSubTest_Click);
            // 
            // buttonUnsubTest
            // 
            this.buttonUnsubTest.Location = new System.Drawing.Point(362, 244);
            this.buttonUnsubTest.Name = "buttonUnsubTest";
            this.buttonUnsubTest.Size = new System.Drawing.Size(166, 41);
            this.buttonUnsubTest.TabIndex = 15;
            this.buttonUnsubTest.Text = "Отписаться";
            this.buttonUnsubTest.UseVisualStyleBackColor = true;
            this.buttonUnsubTest.Click += new System.EventHandler(this.buttonUnsubTest_Click);
            // 
            // channelStateControl1
            // 
            this.channelStateControl1.Location = new System.Drawing.Point(554, 255);
            this.channelStateControl1.Name = "channelStateControl1";
            this.channelStateControl1.Size = new System.Drawing.Size(155, 87);
            this.channelStateControl1.TabIndex = 17;
            // 
            // progWorkTime1
            // 
            this.progWorkTime1.Location = new System.Drawing.Point(69, 326);
            this.progWorkTime1.Name = "progWorkTime1";
            this.progWorkTime1.Size = new System.Drawing.Size(328, 210);
            this.progWorkTime1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 562);
            this.Controls.Add(this.channelStateControl1);
            this.Controls.Add(this.progWorkTime1);
            this.Controls.Add(this.buttonUnsubTest);
            this.Controls.Add(this.buttonSubTest);
            this.Controls.Add(this.buttonGetTree);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNodeValue);
            this.Controls.Add(this.buttonReadNodeValue);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelConnectionStatus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonReadNodeValue;
        private System.Windows.Forms.Label labelNodeValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonGetTree;
        private System.Windows.Forms.Button buttonSubTest;
        private System.Windows.Forms.Button buttonUnsubTest;
        private OPCClientApp.ProgWorkTime progWorkTime1;
        private ChannelStateControl channelStateControl1;
    }
}

