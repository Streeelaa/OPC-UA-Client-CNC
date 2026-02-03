namespace OPCClientApp
{
    partial class ProgWorkTime
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelWorkTime1 = new System.Windows.Forms.Label();
            this.labelWorkTime2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBarWorkTime = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWorkTime1
            // 
            this.labelWorkTime1.AutoSize = true;
            this.labelWorkTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWorkTime1.Location = new System.Drawing.Point(3, 0);
            this.labelWorkTime1.Name = "labelWorkTime1";
            this.labelWorkTime1.Size = new System.Drawing.Size(419, 95);
            this.labelWorkTime1.TabIndex = 0;
            this.labelWorkTime1.Text = "label1";
            this.labelWorkTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWorkTime2
            // 
            this.labelWorkTime2.AutoSize = true;
            this.labelWorkTime2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWorkTime2.Location = new System.Drawing.Point(3, 95);
            this.labelWorkTime2.Name = "labelWorkTime2";
            this.labelWorkTime2.Size = new System.Drawing.Size(419, 95);
            this.labelWorkTime2.TabIndex = 1;
            this.labelWorkTime2.Text = "label2";
            this.labelWorkTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 15);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(60, 43);
            this.progressBar1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelWorkTime1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelWorkTime2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBarWorkTime, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(425, 287);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // progressBarWorkTime
            // 
            this.progressBarWorkTime.Location = new System.Drawing.Point(3, 193);
            this.progressBarWorkTime.Name = "progressBarWorkTime";
            this.progressBarWorkTime.Size = new System.Drawing.Size(419, 91);
            this.progressBarWorkTime.Step = 1;
            this.progressBarWorkTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarWorkTime.TabIndex = 2;
            // 
            // ProgWorkTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.progressBar1);
            this.Name = "ProgWorkTime";
            this.Size = new System.Drawing.Size(425, 287);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWorkTime1;
        private System.Windows.Forms.Label labelWorkTime2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBarWorkTime;
    }
}
