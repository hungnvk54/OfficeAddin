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
        private long mNumberOfRecords;
        private Boolean isLoad;
        private static long MAX_NUMBER_RECORD = 300;
        public SessionList()
        {
            InitializeComponent();
            this.isLoad = false;
            this.mNumberOfRecords = 100;
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
            LoadData(this.mNumberOfRecords);
            BindingData(this.mListSession);
            Cursor.Current = Cursors.Default;
        }

        private  void LoadData(long numberOfRecords)
        {
            mListSession = Request.getListSession(mNumberOfRecords);
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
                    row.Cells["Session_MeetingDate"].Value = Utils.FormatDateTime(entity.meetingDay);
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
                    "Có lỗi xảy ra trong quá trình tải danh sách tệp. Mã lỗi " + e.Message,
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
            ChangeSessionInfoBinding(e.RowIndex);
        }

        private void ChangeSessionInfoBinding(int rowIndex)
        {
            SessionsEntity entity = null;

            if (this.mSearchSession.Count > 0 && rowIndex < this.mSearchSession.Count)
            {
                entity = this.mSearchSession[rowIndex];
            }
            else if (this.mListSession.Count > 0 && rowIndex < this.mListSession.Count)
            {
                entity = this.mListSession[rowIndex];
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
            this.LB_MeetingDate.Text = Utils.FormatDateTime(entity.meetingDay);
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

            this.RTB_NoiDung.Text = entity.contentMeeting;
            
        }

        private void TB_SessionNumberSearch_TextChanged(object sender, EventArgs e)
        {
            this.mSearchSession.Clear();
            if (this.TB_SessionNumberSearch.Text.Trim().Equals(""))
            {
                BindingData(this.mListSession);
            }
            else
            {
                if (this.RB_SessionId.Checked)
                {
                    SearchByIdSession(this.TB_SessionNumberSearch.Text);
                } else if (this.RB_Content.Checked)
                {
                    SearchByContent(this.TB_SessionNumberSearch.Text);
                } else if (this.RB_Activity.Checked)
                {
                    SearchByActivity(this.TB_SessionNumberSearch.Text);
                }
            }
        }

        private void SearchByIdSession(string idSession)
        {
            this.mSearchSession.Clear();
            foreach (SessionsEntity entity in this.mListSession)
            {
                if (String.Format("{0}", entity.idSession).Contains(this.TB_SessionNumberSearch.Text))
                {
                    this.mSearchSession.Add(entity);
                }
            }
            BindingData(this.mSearchSession);
        }

        private void SearchByContent(string content)
        {
            this.mSearchSession.Clear();
            foreach (SessionsEntity entity in this.mListSession)
            {
                string[] seperator = { " " };
                string[] listWord = content.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                Boolean isFound = true;
                string contentInAsii = Utils.fromUtf8ToAscii(entity.contentMeeting).ToLower();
                foreach(string word in listWord)
                {
                    if (!contentInAsii.Contains(Utils.fromUtf8ToAscii(word).ToLower()))
                    {
                        isFound = false;
                        break;
                    }
                }
                if (isFound)
                {
                    this.mSearchSession.Add(entity);
                }

            }
            BindingData(this.mSearchSession);
        }

        private void SearchByActivity(string activity)
        {
            this.mSearchSession.Clear();
            foreach (SessionsEntity entity in this.mListSession)
            {
                string[] seperator = { " " };
                string[] listWord = activity.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                Boolean isFound = true;
                string meetingNameInAsii = Utils.fromUtf8ToAscii(entity.activity.name).ToLower();
                foreach (string word in listWord)
                {
                    if (!meetingNameInAsii.Contains(Utils.fromUtf8ToAscii(word).ToLower()))
                    {
                        isFound = false;
                        break;
                    }
                }
                if (isFound)
                {
                    this.mSearchSession.Add(entity);
                }

            }
            BindingData(this.mSearchSession);
        }

        private void On_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Binding data here
            Debug.WriteLine("Select the row: " + e.RowIndex);
            if (e.RowIndex < 0)
            {
                return;
            }
            SelectRow(e.RowIndex);
        }

        private void SelectRow(int rowIndex)
        {
            SessionsEntity entity = null;
            if (this.mSearchSession.Count > 0)
            {
                entity = this.mSearchSession[rowIndex];
            }
            else if (this.mListSession.Count > 0)
            {
                entity = this.mListSession[rowIndex];
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

        private void OnEnterClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Enter on table: " + DGV_SessionList.CurrentCell.RowIndex);
            if (DGV_SessionList.CurrentCell.RowIndex >= 0)
            {
                SelectRow(DGV_SessionList.CurrentCell.RowIndex);
            }
        }

        private void OnRowSelectionChange(object sender, EventArgs e)
        {
            if (DGV_SessionList.CurrentCell.RowIndex >= 0)
            {
                ChangeSessionInfoBinding(DGV_SessionList.CurrentCell.RowIndex);
            }
        }

        private void OnScrollChanged(object sender, ScrollEventArgs e)
        {
            int totalHeight = 0;
            foreach (DataGridViewRow row in this.DGV_SessionList.Rows)
                totalHeight += row.Height;

            if (totalHeight - this.DGV_SessionList.Height < this.DGV_SessionList.VerticalScrollingOffset)
            {
                //Last row visible
                if (this.mNumberOfRecords < MAX_NUMBER_RECORD && this.mSearchSession.Count<=0)
                {
                    this.mNumberOfRecords = MAX_NUMBER_RECORD;
                    LoadData(this.mNumberOfRecords);
                    BindingData(this.mListSession);
                    Debug.WriteLine("Load more data");
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                //Refreset data
                this.fillingData();
                this.isLoad = true;
            } else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }
    }
}
