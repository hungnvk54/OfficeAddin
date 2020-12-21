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
        public RepresentativeSplitForm()
        {
            InitializeComponent();
        }

        public void SettingData(DocumentEntity documentEntity)
        {
            mDocumentEntity = documentEntity;
        }

        public void BindingData()
        {
            this.DGV_SplitRepresentative.Rows.Clear();
            HashSet<string> representativeMark = new HashSet<string>();
            foreach (DocumentParagraph para in this.mDocumentEntity.paragraphs)
            {
                if (para.belongTo != null && !representativeMark.Contains(Utils.FormatRepresentative(
                    para.belongTo.name, para.belongTo.duty)))
                {
                    RepresentativeEntity entity = para.belongTo;
                    int index = this.DGV_SplitRepresentative.Rows.Add();

                    DataGridViewRow row = this.DGV_SplitRepresentative.Rows[index];
                    row.Cells["STT"].Value = index + 1;
                    row.Cells["Representative_Name"].Value = entity.name;
                    row.Cells["Representative_Duty"].Value = entity.duty;

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
                WordProcessingHelper.CreateDefaultDocumentStyle(newDocument);
                WordProcessingHelper.CreateDocumentTitle(newDocument, AppsSettings.GetInstance().Session);
                WordProcessingHelper.GenerateRepresentativeDocument(representativeDocumentParagraphs, newDocument);
            }
            else
            {
                //Notify here
            }

            DialogResult = DialogResult.OK;
        }
    }
}
