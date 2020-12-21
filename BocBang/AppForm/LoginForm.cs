using BocBang.DataMessage;
using BocBang.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BocBang
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LoadLoginInfo();

            if (string.IsNullOrEmpty(this.Login_TB_Password.Text))
            {
                this.LoginForm_CB_SavePassword.Checked = false;
            }
            else
            {
                this.LoginForm_CB_SavePassword.Checked = true;
            }
        }

        private void SaveInfo()
        {
            PasswordRepository password_repos = new PasswordRepository();

            password_repos.SaveUserName(this.Login_TB_UserName.Text);

            if (this.LoginForm_CB_SavePassword.Checked)
            {
                password_repos.SavePassword(this.Login_TB_Password.Text);
            }
        }

        private void LoadLoginInfo()
        {
            PasswordRepository password_repos = new PasswordRepository();

            string userName = password_repos.GetUsername();
            string password = password_repos.GetPassword();

            this.Login_TB_UserName.Text = userName;
            this.Login_TB_Password.Text = password;
        }

        private void Login_To_System()
        {
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;
            this.SaveInfo();
            UserInfoMessage userInfo = Request.RequestLogin(this.Login_TB_UserName.Text, this.Login_TB_Password.Text);

            if (userInfo == null)
            {
                ///Return False here
                Debug.WriteLine("Cannot login to system");
                this.LoginForm_LB_Info.Text = "Không thể đăng nhập vào hệ thống.\nKiểm tra lại Tên đăng nhập/Mật khẩu";
            }
            else if (userInfo.roleType == "2")
            {
                Debug.WriteLine("Cannot login to system with this role");
                this.LoginForm_LB_Info.Text = "Không thể đăng nhập vào hệ thống \nbằng quyền người duyệt";
            }
            else
            {
                Debug.WriteLine("Login done");
                this.LoginForm_LB_Info.Text = "";
                AppsSettings.GetInstance().UserInfo = userInfo;
                DialogResult = DialogResult.OK;
            }
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }

        private void Login_BT_Login_Click(object sender, EventArgs e)
        {
            Login_To_System();
        }

        private void LoginForm_CB_SavePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.LoginForm_CB_SavePassword.Checked)
            {
                SaveInfo();
            }
            else
            {
                PasswordRepository password_repos = new PasswordRepository();
                password_repos.SavePassword("");
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }
    }
}
