using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using BocBang.Common;
using BocBang.DataMessage;

namespace BocBang.AppForm
{
    public partial class RepresentativeForm : Form
    {
        private List<RepresentativeEntity> mListRepresentative;
        private List<RepresentativeEntity> mSearchRepresentative;
        private Boolean isLoad;
        public RepresentativeForm()
        {
            InitializeComponent();
        }

        public List<RepresentativeEntity> GetRepresentativeList()
        {
            ///@Todo Phai khoi tao danh sach dai bieu truoc.
            return mListRepresentative;
        }

        private void generateDataTest()
        {
            mListRepresentative = new List<RepresentativeEntity>();
            RepresentativeEntity entity = new RepresentativeEntity();
            entity.name = "Nguyễn Hoàng Anh";
            entity.duty = "Bắc Giang";
            entity.legislature = "14";
            mListRepresentative.Add(entity);

            entity = new RepresentativeEntity();
            entity.name = "Hoàng Liên Sơn";
            entity.duty = "Bộ trưởng Bộ Giáo dục & đạo tạo";
            entity.legislature = "14";
            mListRepresentative.Add(entity);

            BindingData(this.mListRepresentative);
        }

        public void FillingData()
        {
            this.isLoad = true;
            Cursor.Current = Cursors.WaitCursor;
            RequestData(AppsSettings.GetInstance().Session.nationalAssembly);
            BindingData(this.mListRepresentative);
            Cursor.Current = Cursors.Default;
        }
        public DialogResult CustomShowDialog()
        {
            if( this.isLoad == false)
            {
                FillingData();
            }
            return this.ShowDialog();
        }

        private void RequestData(long term)
        {
            mListRepresentative = Request.getListRepresentative(term);
            mSearchRepresentative = new List<RepresentativeEntity>();
        }
        private void BindingData(List<RepresentativeEntity> representativeEntities)
        {
            this.DGV_RepresentativeList.Rows.Clear();
            
            foreach( RepresentativeEntity entity in representativeEntities) { 
                int index = this.DGV_RepresentativeList.Rows.Add();

                DataGridViewRow row = this.DGV_RepresentativeList.Rows[index];
                row.Cells["Representative_Order"].Value = index + 1;
                row.Cells["Representative_Name"].Value = entity.name;
                row.Cells["Representative_Duty"].Value = entity.duty;
                row.Cells["Representative_Term"].Value = entity.legislature;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void On_Representative_Selection(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("Selection the Row At: (row,colm) (" + e.RowIndex + ", " + e.ColumnIndex + ")");
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow selected_row = this.DGV_RepresentativeList.Rows[e.RowIndex];

            string nameRepresentative = (string)selected_row.Cells["Representative_Name"].Value;
            string dutyRepresentative = (string)selected_row.Cells["Representative_Duty"].Value;
            string representative = Utils.FormatRepresentative(nameRepresentative, dutyRepresentative);
            InsertRepresentativeToDocument(representative);
            DialogResult = DialogResult.OK;
        }

        private void InsertRepresentativeToDocument(string representative)
        {
            Word.Document currentDocument = Globals.ThisAddIn.Application.ActiveDocument;

            Word.Selection selection = Globals.ThisAddIn.Application.Selection;
            selection.set_Style(currentDocument.Styles[Constants.RerpesentativeStyle]);
            selection.TypeText(representative);
            //selection.InsertStyleSeparator();
            //selection.set_Style(currentDocument.Styles[Constants.ContentStyle]);
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            if(TB_Search.Text.Trim().Equals(""))
            {
                mSearchRepresentative.Clear();
                BindingData(mListRepresentative);
            } else
            {
                if(this.RB_Duty.Checked)
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
            mSearchRepresentative = mListRepresentative.FindAll(x => Utils.fromUtf8ToAscii(x.name.ToLower()).Contains(
                    Utils.fromUtf8ToAscii(name.Trim().ToLower())));
            BindingData(mSearchRepresentative);
        }

        private void SearchByDuty(string duty)
        {
            mSearchRepresentative = mListRepresentative.FindAll(x => Utils.fromUtf8ToAscii(x.duty.ToLower()).Contains(
                    Utils.fromUtf8ToAscii(duty.Trim().ToLower())));
            BindingData(mSearchRepresentative);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillingData();
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
