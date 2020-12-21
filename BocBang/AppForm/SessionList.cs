using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BocBang.DataMessage;
using System.Diagnostics;
using BocBang.Common;


namespace BocBang.AppForm
{
    public partial class SessionList : Form
    {
        private List<SessionsEntity> mListSession;
        private List<SessionsEntity> mSearchSession;
        private Boolean isLoad;
        public SessionList()
        {
            InitializeComponent();
            this.isLoad = false;
            
        }

        public DialogResult CustomDialogShow()
        {
            if (this.isLoad == false)
            {
                this.fillingData();
                this.isLoad = true;
            }
            return this.ShowDialog();
        }

        private void fillingData()
        {
            Cursor.Current = Cursors.WaitCursor;
            loadData();
            BindingData(this.mListSession);
            Cursor.Current = Cursors.Default;
        }

        private  void loadData()
        {
            mListSession = Request.getListSession();
            mSearchSession = new List<SessionsEntity>();
        }

        private void BindingData(List<SessionsEntity> listSession)
        {
            try
            {
                this.DGV_SessionList.Rows.Clear();
                foreach (SessionsEntity entity in listSession)
                {
                    int rowIndex = this.DGV_SessionList.Rows.Add();

                    DataGridViewRow row = this.DGV_SessionList.Rows[rowIndex];

                    row.Cells["Session_Order"].Value = rowIndex + 1;
                    row.Cells["Session_MeetingDate"].Value = entity.meetingDay;
                    row.Cells["Session_Meeting"].Value = entity.meetingEntity.name;
                    row.Cells["Session_Number"].Value = entity.idSession;
                    row.Cells["Session_Activity"].Value = entity.activity.name;
                    if (entity.activityGroup != null)
                    {
                        row.Cells["Session_Group"].Value = entity.activityGroup.nameActivityGroup;
                    }
                }
            } catch( Exception e)
            {
                CreateInformationDialog.CreateWarningBox(
                    "Có lỗi xảy ra trong quá trình tải danh sách tệp. Mã lỗi [@Todo]",
                    "Cảnh báo");
            }
        }
        private void On_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Binding data here
            Debug.WriteLine("Select the row: " + e.RowIndex);
            if (e.RowIndex < 0)
            {
                return;
            }
            SessionsEntity entity = null;

            if(this.mSearchSession.Count > 0)
            {
                entity = this.mSearchSession[e.RowIndex];
            }
            else if (this.mListSession.Count > 0)
            {
                entity = this.mListSession[e.RowIndex];
            }

            if (entity != null)
            {
                BindingSessionInfo(entity);
            }
        }

        private void BindingSessionInfo(SessionsEntity entity)
        {
            this.LB_term.Text = entity.nationalAssembly.ToString();
            this.LB_kyhop.Text = entity.meeting.ToString();
            this.LB_MeetingDate.Text = entity.meetingDay;
            this.LB_Buoi.Text = entity.meetingEntity.name;
            this.LB_HoatDong.Text = entity.activity.name;
            this.LB_LeadConference.Text = entity.leadConference;
            if (entity.activityGroup != null)
            {
                this.LB_To.Text = entity.activityGroup.nameActivityGroup;
            }
            this.LB_MaPhien.Text = entity.idSession.ToString();

            switch (entity.public_status)
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

            this.LB_NoiDung.Text = entity.contentMeeting;
            
        }

        private void TB_SessionNumberSearch_TextChanged(object sender, EventArgs e)
        {
            if(this.TB_SessionNumberSearch.Text.Trim().Equals(""))
            {
                BindingData(this.mListSession);
                this.mSearchSession.Clear();
            }
            else
            {
                this.mSearchSession.Clear();
                foreach(SessionsEntity entity in this.mListSession)
                {
                    if (String.Format("{0}", entity.idSession).Contains(this.TB_SessionNumberSearch.Text))
                    {
                        this.mSearchSession.Add(entity);
                    }
                }
                BindingData(this.mSearchSession);
            }
        }

        private void On_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Binding data here
            Debug.WriteLine("Select the row: " + e.RowIndex);
            if (e.RowIndex < 0)
            {
                return;
            }
            SessionsEntity entity = null;

            if (this.mSearchSession.Count > 0)
            {
                entity = this.mSearchSession[e.RowIndex];
            }
            else if (this.mListSession.Count > 0)
            {
                entity = this.mListSession[e.RowIndex];
            }

            if (entity != null)
            {
                AppsSettings.GetInstance().Session = entity;
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
