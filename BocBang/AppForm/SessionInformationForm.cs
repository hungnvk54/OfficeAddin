using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BocBang.DataMessage;

namespace BocBang.AppForm
{
    public partial class SessionInformationForm : Form
    {
        public SessionInformationForm(SessionsEntity sessionsEntity)
        {
            InitializeComponent();
            InitForm(sessionsEntity);
        }

        private void InitForm(SessionsEntity sessionsEntity)
        {
            if (sessionsEntity != null)
            {
                this.LB_KyHop.Text = sessionsEntity.nationalAssembly.ToString();
                this.LB_Khoa.Text = sessionsEntity.meeting.ToString();
                this.LB_NgayHop.Text = sessionsEntity.meetingDay;
                this.LB_Buoi.Text = sessionsEntity.meetingEntity.name;
                this.LB_HoatDong.Text = sessionsEntity.activity.name;
                this.LB_NguoiChuTri.Text = sessionsEntity.leadConference;
                if (sessionsEntity.activityGroup != null)
                {
                    this.LB_To.Text = sessionsEntity.activityGroup.nameActivityGroup;
                }
                this.LB_MaPhien.Text = sessionsEntity.idSession.ToString();
                switch (sessionsEntity.public_status)
                {
                    case 0:
                        this.LB_XuatBan.Text = "Chưa xuất bản";
                        this.LB_XuatBan.ForeColor = Color.Black;
                        break;
                    case 1:
                        this.LB_XuatBan.Text = "Xuất bản lỗi";
                        this.LB_XuatBan.ForeColor = Color.Red;
                        break;
                    case 2:
                        this.LB_XuatBan.Text = "Đã xuất bản";
                        this.LB_XuatBan.ForeColor = Color.Green;
                        break;
                    case 3:
                        this.LB_XuatBan.Text = "Đã thu hồi";
                        this.LB_XuatBan.ForeColor = Color.Black;
                        break;
                }
                this.RTB_NoiDung.Text = sessionsEntity.contentMeeting;
            }
        }
    }
}
