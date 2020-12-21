using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BocBang.AppForm;
using System.Drawing;

namespace BocBang.Common
{
    class NotificationFactor
    {
        public static void InfoNotification(string messages)
        {
            CustomNotificationForm notificationForm = new CustomNotificationForm(
                messages, Color.FromArgb(2, 240, 176));
            notificationForm.Show();
        }

        public static void WarningNotification(string messages)
        {
            CustomNotificationForm notificationForm = new CustomNotificationForm(
                messages, Color.FromArgb(252, 190, 3));
            notificationForm.Show();
        }

        public static void ErrorNotification(string messages)
        {
            CustomNotificationForm notificationForm = new CustomNotificationForm(
                messages, Color.FromArgb(252, 40, 3));
            notificationForm.Show();
        }
    }
}
