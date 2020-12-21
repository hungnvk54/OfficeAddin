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
    public partial class ListAudioForm : Form
    {
        private List<AudioEntity> mListAudio;
        public ListAudioForm()
        {
            InitializeComponent();
            LoadData(AppsSettings.GetInstance().Session.idSession);
            BindingData(this.mListAudio);
        }
        private void LoadData(long sessionId)
        {
            this.mListAudio = Request.getListAudio(sessionId);
        }

        private void BindingData(List<AudioEntity> listAudioEntity)
        {
            ///Start binding here
            this.DGV_ListAudio.Rows.Clear();
            foreach (AudioEntity entity in listAudioEntity)
            {
                if (entity.idAudioParent <= 0)
                {
                    continue;
                }
                int rowIndex = this.DGV_ListAudio.Rows.Add();
                DataGridViewRow rowContent = this.DGV_ListAudio.Rows[rowIndex];

                rowContent.Cells["Order"].Value = rowIndex + 1;
                rowContent.Cells["AudioName"].Value = entity.nameAudio;

                rowContent.Cells["TranslateStatus"].Value = entity.status;
                switch (entity.status)
                {
                    case 0:
                        rowContent.Cells["TranslateStatus"].Value = "Chưa dịch";
                        rowContent.Cells["TranslateStatus"].Style.ForeColor = Color.Black;
                        break;
                    case 1:
                        rowContent.Cells["TranslateStatus"].Value = "Đang dịch";
                        rowContent.Cells["TranslateStatus"].Style.ForeColor = Color.Orange;
                        break;
                    case 2:
                        rowContent.Cells["TranslateStatus"].Value = "Đã dịch";
                        rowContent.Cells["TranslateStatus"].Style.ForeColor = Color.Green;
                        break;

                }

                switch (entity.statusReview)
                {
                    case 0:
                        rowContent.Cells["ReviewStatus"].Value = "Chưa duyệt";
                        rowContent.Cells["ReviewStatus"].Style.ForeColor = Color.Black;
                        break;
                    case 1:
                        rowContent.Cells["ReviewStatus"].Value = "Đang duyệt";
                        rowContent.Cells["ReviewStatus"].Style.ForeColor = Color.Orange;
                        break;
                    case 2:
                        rowContent.Cells["ReviewStatus"].Value = "Đã duyệt";
                        rowContent.Cells["ReviewStatus"].Style.ForeColor = Color.Green;
                        break;
                }

            if (entity.userHandle != null)
                {
                    rowContent.Cells["Reviewer"].Value = entity.userHandle.lastName + " " +
                        entity.userHandle.firstName;
                        
                }
                
                if (entity.isUpdate == 0)
                {
                    rowContent.Cells["MergedStatus"].Value = "Chưa tổng hợp";
                    rowContent.Cells["MergedStatus"].Style.ForeColor = Color.Black;
                }
                else
                {
                    rowContent.Cells["MergedStatus"].Value = "Đã tổng hợp";
                    rowContent.Cells["MergedStatus"].Style.ForeColor = Color.Green;
                }
            }
        }

        private void DGV_ListAudio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
