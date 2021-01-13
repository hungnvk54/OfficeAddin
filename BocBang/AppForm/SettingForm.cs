using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BocBang
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();

            TB_ApiUrl.Text = AppsSettings.GetInstance().ApiUrl;
            this.ConfigForm_TB_DataPath.Text = AppsSettings.GetInstance().DataDir;
        }

        private void TB_DefaultAudioLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            AppsSettings.GetInstance().ApiUrl = TB_ApiUrl.Text;
            AppsSettings.GetInstance().DataDir = ConfigForm_TB_DataPath.Text;
            AppsSettings.GetInstance().SaveConfigure();

            this.Close();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigForm_BT_FolderBrower_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.ConfigForm_TB_DataPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void OnLoadForm(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }
    }
}
