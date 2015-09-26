namespace laba2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.etalon1_panel = new System.Windows.Forms.Panel();
            this.etalon2_panel = new System.Windows.Forms.Panel();
            this.etalon3_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // etalon1_panel
            // 
            this.etalon1_panel.Location = new System.Drawing.Point(15, 15);
            this.etalon1_panel.Name = "etalon1_panel";
            this.etalon1_panel.Size = new System.Drawing.Size(170, 170);
            this.etalon1_panel.TabIndex = 0;
            // 
            // etalon2_panel
            // 
            this.etalon2_panel.Location = new System.Drawing.Point(190, 15);
            this.etalon2_panel.Name = "etalon2_panel";
            this.etalon2_panel.Size = new System.Drawing.Size(170, 170);
            this.etalon2_panel.TabIndex = 1;
            // 
            // etalon3_panel
            // 
            this.etalon3_panel.Location = new System.Drawing.Point(366, 15);
            this.etalon3_panel.Name = "etalon3_panel";
            this.etalon3_panel.Size = new System.Drawing.Size(170, 170);
            this.etalon3_panel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(556, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 170);
            this.panel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.etalon3_panel);
            this.Controls.Add(this.etalon2_panel);
            this.Controls.Add(this.etalon1_panel);
            this.Name = "Form1";
            this.Text = "laba2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel etalon1_panel;
        private System.Windows.Forms.Panel etalon2_panel;
        private System.Windows.Forms.Panel etalon3_panel;
        private System.Windows.Forms.Panel panel1;
    }
}

