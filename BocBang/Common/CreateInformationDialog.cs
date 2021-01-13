using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BocBang.Common
{
    class CreateInformationDialog
    {
        public static void CreateWarningBox(
            string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult CreateConfirmBoxWithTwoButton(
            string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
