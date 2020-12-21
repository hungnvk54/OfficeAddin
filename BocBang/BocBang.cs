using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using BocBang.AppForm;
using BocBang.Common;
using BocBang.DataMessage;

namespace BocBang
{
    public partial class BocBang
    {
        private SessionList mSessionListForm;
        private RepresentativeForm mRepresentativeForm;
        private RepresentativeSplitForm mRepresentativeSplitForm;
        private LoginForm mLoginForm;
        private ExportForm mExportForm;
        private void BocBang_Load(object sender, RibbonUIEventArgs e)
        {
            Debug.WriteLine("This had beend loaded");
            Globals.ThisAddIn.Application.DocumentBeforeClose += Application_DocumentBeforeClose;
            Globals.ThisAddIn.Application.DocumentBeforeSave += Application_DocumentBeforeSave;
            Aplication_CreateDefault();
            ApplicationInitFormData();
        }

        private void ApplicationInitFormData()
        {
            mRepresentativeSplitForm = new RepresentativeSplitForm();
            mLoginForm = new LoginForm();
            mExportForm = new ExportForm();
        }

        private void Aplication_CreateDefault()
        {
            //Create new document if there are now documents at this time
            if (Globals.ThisAddIn.Application.Documents.Count <=0 )
            {
                Globals.ThisAddIn.Application.Documents.Add();
            }
            WordProcessingHelper.CreateDefaultDocumentStyle(Globals.ThisAddIn.Application.ActiveDocument);
        }

        private void Application_DocumentBeforeSave(Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            if (AppsSettings.GetInstance().Session != null)
            {
                Debug.WriteLine("***********Starting save documennt***************");
                ///Kiem tra xem co thay doi nao khoong, neu co, luu lai thay doi
                Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                    document, mRepresentativeForm.GetRepresentativeList());
                documentEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
                Request.SaveDocument(documentEntity);
                Debug.WriteLine("***********Save document done***************");
            }
        }

        private void Application_DocumentBeforeClose(Word.Document Doc, ref bool Cancel)
        {
            if (AppsSettings.GetInstance().Session != null)
            {
                ///Kiem tra xem de lieu co thay doi khong. Neu co, bat popup hoi nguoi dung luu lai thay doi
                Debug.WriteLine("***********Starting save documennt Before Close***************");
                ///Kiem tra xem co thay doi nao khoong, neu co, luu lai thay doi
                Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                    document, mRepresentativeForm.GetRepresentativeList());
                documentEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
                Request.SaveDocument(documentEntity);
                Debug.WriteLine("***********Save document done Before Close***************");
            }
        }

        private void On_Btn_Login(object sender, RibbonControlEventArgs e)
        {
            DialogResult result = DialogResult.OK;
            
            result = mLoginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                AppsSettings.GetInstance().isLogin = true;
                Btn_ListSession.Enabled = true;

                ///Create form
                mSessionListForm = new SessionList();
                mRepresentativeForm = new RepresentativeForm();
            }
        }

        private void On_Btn_Setting(object sender, RibbonControlEventArgs e)
        {
            var setting = new SettingForm();
            setting.ShowDialog();
        }

        private void Btn_Insert_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
            if (this.mRepresentativeForm == null)
            {
                this.mRepresentativeForm = new RepresentativeForm();
            }
            this.mRepresentativeForm.CustomShowDialog();
            doc.Activate();
        }

        private void Btn_ListSession_Click(object sender, RibbonControlEventArgs e)
        {
            if (AppsSettings.GetInstance().isLogin == false) 
            {
                MessageBox.Show("Bạn phải đăng nhập trước khi sử dụng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                DialogResult result = DialogResult.OK;
                result = this.mSessionListForm.CustomDialogShow();
                if (result == DialogResult.OK)
                {
                    ///Create default document
                    WordProcessingHelper.CreateDocumentTitle(Globals.ThisAddIn.Application.ActiveDocument,
                        AppsSettings.GetInstance().Session);

                    //Get document Entity
                    DocumentEntity documentEntity = Request.getMergedDocument(AppsSettings.GetInstance().Session.idSession);
                    WordProcessingHelper.InsertDataToMergedDocument(Globals.ThisAddIn.Application.ActiveDocument, documentEntity);

                    ///Load predefine data
                    mRepresentativeForm.FillingData();

                    ///Enable button
                    this.Btn_Insert.Enabled = true;
                    this.Btn_Spit.Enabled = true;
                    this.Btn_Export.Enabled = true;
                    this.Btn_Undo.Enabled = true;
                    this.Btn_ListAudio.Enabled = true;
                    this.Btn_Merge.Enabled = true;
                    this.Btn_SessionInfo.Enabled = true;
                }
            }
            
        }

        private void Btn_ListAudio_Click(object sender, RibbonControlEventArgs e)
        {
            DialogResult result = DialogResult.OK;
            using (var form = new ListAudioForm())
                result = form.ShowDialog();
        }

        private void Btn_Merge_Click(object sender, RibbonControlEventArgs e)
        {
            //1. Luu lai cac thay doi
            ///Kiem tra xem co thay doi nao khoong, neu co, luu lai thay doi
            Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
            DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                document, mRepresentativeForm.GetRepresentativeList());
            documentEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
            Request.SaveDocument(documentEntity);
            //2. Goi ham merger doc
            AudioEntity entity = Request.GetParentAudioByIdSession(AppsSettings.GetInstance().Session.idSession);
            if (entity == null)
            {
                CreateInformationDialog.CreateWarningBox("Không tồn tại tệp âm thanh tổng hợp", "cảnh báo");
            }
            //3.Goi ham lay lai du lieu
            //Get document Entity
            documentEntity = Request.getMergedDocument(AppsSettings.GetInstance().Session.idSession);
            //4.Clear current document
            TextHelpers.RemoveContent(document);
            //4. day du lieu ra ma hinh
            WordProcessingHelper.InsertDataToMergedDocument(Globals.ThisAddIn.Application.ActiveDocument, documentEntity);
        }

        private void Btn_Spit_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;

            DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                document, mRepresentativeForm.GetRepresentativeList());
            mRepresentativeSplitForm.SettingData(documentEntity);
            mRepresentativeSplitForm.BindingData();
            mRepresentativeSplitForm.ShowDialog();

        }

        private void Btn_Export_Click(object sender, RibbonControlEventArgs e)
        {
            mExportForm.LoadingData();
            DialogResult dialogResult = mExportForm.ShowDialog();
        }

        private void Btn_Undo_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void Btn_FormatRepresentative_Click(object sender, RibbonControlEventArgs e)
        {
            TextHelpers.RemoveContent(Globals.ThisAddIn.Application.ActiveDocument);
        }

        private void Btn_Save_Click(object sender, RibbonControlEventArgs e)
        {
            //1. Luu lai cac thay doi
            ///Kiem tra xem co thay doi nao khoong, neu co, luu lai thay doi
            Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
            DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                document, mRepresentativeForm.GetRepresentativeList());
            documentEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
            Request.SaveDocument(documentEntity);
        }

        private void Btn_SessionInfo_Click(object sender, RibbonControlEventArgs e)
        {
            using (var sessionInfo = new SessionInformationForm(AppsSettings.GetInstance().Session))
                sessionInfo.ShowDialog();
        }
    }
}
