using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BocBang.AppForm
{
    public partial class CustomNotificationForm : Form
    {
        public CustomNotificationForm(string message, Color bgColor)
        {
            InitializeComponent();

            this.LB_Message.Text = message;
            this.BackColor = bgColor;
        }

        private void OnTimerTicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - Height)/2;
            this.Left = Screen.PrimaryScreen.Bounds.Width - Width;
            this.TimerClose.Start();
        }
    }
}
