namespace BocBang
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Login_TB_UserName = new System.Windows.Forms.TextBox();
            this.Login_TB_Password = new System.Windows.Forms.TextBox();
            this.Login_BT_Login = new System.Windows.Forms.Button();
            this.LoginForm_CB_SavePassword = new System.Windows.Forms.CheckBox();
            this.LoginForm_LB_Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(340, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(117, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(117, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            // 
            // Login_TB_UserName
            // 
            this.Login_TB_UserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_TB_UserName.Location = new System.Drawing.Point(263, 107);
            this.Login_TB_UserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Login_TB_UserName.Name = "Login_TB_UserName";
            this.Login_TB_UserName.Size = new System.Drawing.Size(391, 30);
            this.Login_TB_UserName.TabIndex = 3;
            // 
            // Login_TB_Password
            // 
            this.Login_TB_Password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_TB_Password.Location = new System.Drawing.Point(263, 159);
            this.Login_TB_Password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Login_TB_Password.Name = "Login_TB_Password";
            this.Login_TB_Password.PasswordChar = '*';
            this.Login_TB_Password.Size = new System.Drawing.Size(391, 30);
            this.Login_TB_Password.TabIndex = 4;
            // 
            // Login_BT_Login
            // 
            this.Login_BT_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Login_BT_Login.Location = new System.Drawing.Point(263, 236);
            this.Login_BT_Login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Login_BT_Login.Name = "Login_BT_Login";
            this.Login_BT_Login.Size = new System.Drawing.Size(124, 34);
            this.Login_BT_Login.TabIndex = 6;
            this.Login_BT_Login.Text = "Đăng nhập";
            this.Login_BT_Login.UseVisualStyleBackColor = true;
            this.Login_BT_Login.Click += new System.EventHandler(this.Login_BT_Login_Click);
            // 
            // LoginForm_CB_SavePassword
            // 
            this.LoginForm_CB_SavePassword.AutoSize = true;
            this.LoginForm_CB_SavePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LoginForm_CB_SavePassword.Location = new System.Drawing.Point(263, 198);
            this.LoginForm_CB_SavePassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginForm_CB_SavePassword.Name = "LoginForm_CB_SavePassword";
            this.LoginForm_CB_SavePassword.Size = new System.Drawing.Size(152, 29);
            this.LoginForm_CB_SavePassword.TabIndex = 5;
            this.LoginForm_CB_SavePassword.Text = "Lưu mật khẩu";
            this.LoginForm_CB_SavePassword.UseVisualStyleBackColor = true;
            this.LoginForm_CB_SavePassword.CheckedChanged += new System.EventHandler(this.LoginForm_CB_SavePassword_CheckedChanged);
            // 
            // LoginForm_LB_Info
            // 
            this.LoginForm_LB_Info.AutoSize = true;
            this.LoginForm_LB_Info.ForeColor = System.Drawing.Color.Red;
            this.LoginForm_LB_Info.Location = new System.Drawing.Point(416, 198);
            this.LoginForm_LB_Info.Name = "LoginForm_LB_Info";
            this.LoginForm_LB_Info.Size = new System.Drawing.Size(0, 17);
            this.LoginForm_LB_Info.TabIndex = 8;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.Login_BT_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 316);
            this.Controls.Add(this.LoginForm_LB_Info);
            this.Controls.Add(this.LoginForm_CB_SavePassword);
            this.Controls.Add(this.Login_BT_Login);
            this.Controls.Add(this.Login_TB_Password);
            this.Controls.Add(this.Login_TB_UserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(799, 363);
            this.MinimumSize = new System.Drawing.Size(799, 363);
            this.Name = "LoginForm";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Login_TB_UserName;
        private System.Windows.Forms.TextBox Login_TB_Password;
        private System.Windows.Forms.Button Login_BT_Login;
        private System.Windows.Forms.CheckBox LoginForm_CB_SavePassword;
        private System.Windows.Forms.Label LoginForm_LB_Info;
    }
}