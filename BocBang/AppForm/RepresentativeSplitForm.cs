using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BocBang.DataMessage;
using BocBang.Common;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;


namespace BocBang.AppForm
{
    public partial class RepresentativeSplitForm : Form
    {
        private DocumentEntity mDocumentEntity;
        private List<RepresentativeEntity> mListRepresentativeInDocument;
        private List<RepresentativeEntity> mSearchListRepresenative;
        public RepresentativeSplitForm()
        {
            InitializeComponent();
            mListRepresentativeInDocument = new List<RepresentativeEntity>();
            mSearchListRepresenative = new List<RepresentativeEntity>();
        }

        public void InitDataFormIntoForm(DocumentEntity documentEntity)
        {
            SettingData(documentEntity);
            SplitRepresentativeSpeechFromDocument();
            BindingData(this.mListRepresentativeInDocument);
        }

        public void SettingData(DocumentEntity documentEntity)
        {
            mDocumentEntity = documentEntity;
        }

        public void BindingData(List<RepresentativeEntity> representativeEntities)
        {
            this.DGV_SplitRepresentative.Rows.Clear();
            foreach (RepresentativeEntity entity in representativeEntities)
            { 
                int index = this.DGV_SplitRepresentative.Rows.Add();
                DataGridViewRow row = this.DGV_SplitRepresentative.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["Representative_Name"].Value = entity.name;
                row.Cells["Representative_Duty"].Value = entity.duty;
            }
        }

        private void SplitRepresentativeSpeechFromDocument()
        {
            HashSet<string> representativeMark = new HashSet<string>();
            mListRepresentativeInDocument.Clear();
            mSearchListRepresenative.Clear();
            foreach (DocumentParagraph para in this.mDocumentEntity.paragraphs)
            {
                if (para.belongTo != null && !representativeMark.Contains(Utils.FormatRepresentative(
                    para.belongTo.name, para.belongTo.duty)))
                {
                    RepresentativeEntity entity = para.belongTo;
                    mListRepresentativeInDocument.Add(entity);
                    representativeMark.Add(Utils.FormatRepresentative(para.belongTo.name, para.belongTo.duty));
                }
            }
        }

        private void On_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("On_CellContentDoubleClick");
        }

        private void On_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("On_CellDoubleClick");
            if (e.RowIndex >= this.DGV_SplitRepresentative.Rows.Count
                || e.RowIndex < 0)
            {
                return;
            }
            string representative_name = (string)this.DGV_SplitRepresentative.Rows[e.RowIndex].Cells["Representative_Name"].Value;
            string representative_duty = (string)this.DGV_SplitRepresentative.Rows[e.RowIndex].Cells["Representative_Duty"].Value;
            List<DocumentParagraph> representativeDocumentParagraphs = new List<DocumentParagraph>();
            foreach (DocumentParagraph para in this.mDocumentEntity.paragraphs)
            {
                if (para.belongTo != null &&
                    Utils.FormatRepresentative(para.belongTo.name, para.belongTo.duty).Equals(
                    Utils.FormatRepresentative(representative_name, representative_duty)))
                {
                    ///Generate document here
                    representativeDocumentParagraphs.Add(para);
                }
            }
            if (representativeDocumentParagraphs.Count > 0)
            {
                Word.Document newDocument = Globals.ThisAddIn.Application.Documents.Add();
                WordProcessingHelper.SaveRepresentativeDocument(AppsSettings.GetInstance().Session, newDocument, representativeDocumentParagraphs[0].belongTo.name);
                WordProcessingHelper.CreateDefaultDocumentStyle(newDocument);
                WordProcessingHelper.CreateDocumentTitle(newDocument, AppsSettings.GetInstance().Session);
                WordProcessingHelper.GenerateRepresentativeDocument(representativeDocumentParagraphs, newDocument);
                newDocument.Save();
            }
            else
            {
                
            }

            DialogResult = DialogResult.OK;
        }



        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Escape == e.KeyCode)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            this.mSearchListRepresenative.Clear();

            if (this.TB_Search.Text.Trim().Equals(""))
            {
                BindingData(this.mListRepresentativeInDocument);
            } else
            {
                if (this.RB_Duty.Checked)
                {
                    SearchByDuty(this.TB_Search.Text);
                } else
                {
                    SearchByName(this.TB_Search.Text);
                }
            }
        }

        private void SearchByName(string name)
        {
            mSearchListRepresenative = mListRepresentativeInDocument.FindAll(x => Utils.fromUtf8ToAscii(x.name.ToLower()).Contains(
                    Utils.fromUtf8ToAscii(name.Trim().ToLower())));
            BindingData(mSearchListRepresenative);
        }

        private void SearchByDuty(string duty)
        {
            mSearchListRepresenative = mListRepresentativeInDocument.FindAll(x => Utils.fromUtf8ToAscii(x.duty.ToLower()).Contains(
                    Utils.fromUtf8ToAscii(duty.Trim().ToLower())));
            BindingData(mSearchListRepresenative);
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }
    }
}
