namespace BocBang
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ConfigForm_TB_DataPath = new System.Windows.Forms.TextBox();
            this.TB_ApiUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.BT_Save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ConfigForm_TB_DataPath);
            this.groupBox1.Controls.Add(this.TB_ApiUrl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BT_Cancel);
            this.groupBox1.Controls.Add(this.BT_Save);
            this.groupBox1.Location = new System.Drawing.Point(17, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(992, 276);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cài đặt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Thư mục Tạm";
            // 
            // ConfigForm_TB_DataPath
            // 
            this.ConfigForm_TB_DataPath.Location = new System.Drawing.Point(244, 124);
            this.ConfigForm_TB_DataPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ConfigForm_TB_DataPath.Name = "ConfigForm_TB_DataPath";
            this.ConfigForm_TB_DataPath.Size = new System.Drawing.Size(624, 30);
            this.ConfigForm_TB_DataPath.TabIndex = 7;
            // 
            // TB_ApiUrl
            // 
            this.TB_ApiUrl.Location = new System.Drawing.Point(244, 53);
            this.TB_ApiUrl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TB_ApiUrl.MaximumSize = new System.Drawing.Size(624, 30);
            this.TB_ApiUrl.MinimumSize = new System.Drawing.Size(624, 30);
            this.TB_ApiUrl.Name = "TB_ApiUrl";
            this.TB_ApiUrl.Size = new System.Drawing.Size(624, 30);
            this.TB_ApiUrl.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "ApiUrl";
            // 
            // BT_Cancel
            // 
            this.BT_Cancel.Location = new System.Drawing.Point(597, 203);
            this.BT_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.Size = new System.Drawing.Size(111, 41);
            this.BT_Cancel.TabIndex = 10;
            this.BT_Cancel.Text = "Hủy";
            this.BT_Cancel.UseVisualStyleBackColor = true;
            this.BT_Cancel.Click += new System.EventHandler(this.BT_Cancel_Click);
            // 
            // BT_Save
            // 
            this.BT_Save.Location = new System.Drawing.Point(421, 203);
            this.BT_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(116, 41);
            this.BT_Save.TabIndex = 9;
            this.BT_Save.Text = "Lưu";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 309);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(1046, 356);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1046, 356);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.OnLoadForm);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BT_Cancel;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.TextBox TB_ApiUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ConfigForm_TB_DataPath;
    }
}