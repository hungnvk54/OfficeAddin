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
            Globals.ThisAddIn.Application.WindowSelectionChange += Application_WindowSelectionChange;
            ApplicationInitFormData();
        }

        private void Application_WindowSelectionChange(Word.Selection Sel)
        {
            Debug.WriteLine("Hello from selection change");
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
            if (Globals.ThisAddIn.Application.Documents.Count <= 0 )
            {
                Globals.ThisAddIn.Application.Documents.Add();
            }
            WordProcessingHelper.CreateDefaultDocumentStyle(Globals.ThisAddIn.Application.ActiveDocument);
        }

        private void Application_DocumentBeforeSave(Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            SaveDocumentToRemoteServer();
        }

        private void Application_DocumentBeforeClose(Word.Document Doc, ref bool Cancel)
        {
            
        }

        private void On_Btn_Login(object sender, RibbonControlEventArgs e)
        {
            DialogResult result = DialogResult.OK;
            
            result = mLoginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ///Create the Default document
                Aplication_CreateDefault();

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

                if (AppsSettings.GetInstance().Session != null)
                {
                    DialogResult dialogResult = CreateInformationDialog.CreateConfirmBoxWithTwoButton(
                        "Bạn đang mở phiên họp. Bạn có muốn lưu lại nội dung phiên họp hiện tại không?",
                        "Cảnh bảo");
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveDocumentToRemoteServer();
                    }
                }

                DialogResult result = DialogResult.OK;
                result = this.mSessionListForm.CustomDialogShow();
                if (result == DialogResult.OK)
                {
                    ///Create new document and save as new file
                    Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                    WordProcessingHelper.SaveNewSessionDocument(AppsSettings.GetInstance().Session, document);
                    ///Create default document
                    WordProcessingHelper.CreateDocumentTitle(document,
                        AppsSettings.GetInstance().Session);

                    //Get document Entity
                    DocumentEntity documentEntity = Request.getMergedDocument(AppsSettings.GetInstance().Session.idSession);
                    WordProcessingHelper.InsertDataToMergedDocument(document, documentEntity);

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
                    this.Btn_Save.Enabled = true;
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
            try
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
                } else
                {
                    Boolean isRequestSuccessful = Request.RequestMerge(entity.idAudio);

                    if (isRequestSuccessful == true)
                    {
                        NotificationFactor.InfoNotification("Tổng hợp biên bản thành công");
                    }
                    else
                    {
                        NotificationFactor.ErrorNotification("Tổng hợp biên bản thất bại");
                    }
                }
                //3.Goi ham lay lai du lieu
                //Get document Entity
                documentEntity = Request.getMergedDocument(AppsSettings.GetInstance().Session.idSession);
                //4.Clear current document
                TextHelpers.RemoveContent(document);
                //4. day du lieu ra ma hinh
                WordProcessingHelper.InsertDataToMergedDocument(Globals.ThisAddIn.Application.ActiveDocument, documentEntity);

            } catch (Exception ee)
            {
                NotificationFactor.ErrorNotification("Tổng hợp biên bản thất bại");
            }
        }

        private void Btn_Spit_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;

                DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                    document, mRepresentativeForm.GetRepresentativeList());
                mRepresentativeSplitForm.InitDataFormIntoForm(documentEntity);
                mRepresentativeSplitForm.ShowDialog();
            } catch (Exception ee)
            {
                NotificationFactor.ErrorNotification("Không thể tách lời đại biểu");
            }
            

        }

        private void Btn_Export_Click(object sender, RibbonControlEventArgs e)
        {
            mExportForm.LoadingData();
            DialogResult dialogResult = mExportForm.ShowDialog();

            if( dialogResult == DialogResult.OK)
            {
                NotificationFactor.InfoNotification("Xuất bản thành công");
            }  else
            {
                NotificationFactor.ErrorNotification("Xuất bản thất bại");
            }
        }

        private void Btn_Undo_Click(object sender, RibbonControlEventArgs e)
        {
            if (AppsSettings.GetInstance().Session != null)
            {
                Boolean deleteResult = Request.RemoteGGGSession(AppsSettings.GetInstance().Session.idSession);
                if (deleteResult == true)
                {
                    ///@Todo notify successfully here
                    NotificationFactor.InfoNotification("Thu hồi phiên thành công");
                } else
                {
                    NotificationFactor.ErrorNotification("Thu hồi phiên thất bại");
                }
            } else
            {
                //@Todo
                // Notify select session here
                NotificationFactor.ErrorNotification("Thu hồi phiên thất bại");
            }
        }

        private void Btn_FormatRepresentative_Click(object sender, RibbonControlEventArgs e)
        {
            if (Globals.ThisAddIn.Application.Documents.Count > 0)
            {
                Word.Selection selection = Globals.ThisAddIn.Application.Selection;
                try
                {
                    selection.set_Style(Globals.ThisAddIn.Application.ActiveDocument.Styles[Constants.RerpesentativeStyle]);
                } catch (Exception ee)
                {
                    Debug.WriteLine("Error while formating document");
                }
            }
        }

        private void Btn_Save_Click(object sender, RibbonControlEventArgs e)
        {
            SaveDocumentToRemoteServer();
        }

        private void SaveDocumentToRemoteServer()
        {
            try
            {
                //1. Luu lai cac thay doi
                ///Kiem tra xem co thay doi nao khoong, neu co, luu lai thay doi
                if (AppsSettings.GetInstance().isLogin == true)
                {
                    Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                    DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                        document, mRepresentativeForm.GetRepresentativeList());
                    documentEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
                    Request.SaveDocument(documentEntity);
                    NotificationFactor.InfoNotification("Lưu nội dung thành công");
                }
                else
                {
                    NotificationFactor.WarningNotification("Không thể lưu văn bản do chưa đăng nhập");
                }
            }
            catch (Exception e)
            {
                NotificationFactor.ErrorNotification("Lưu nội dung thất bại");
            }
            
        }

        private void Btn_SessionInfo_Click(object sender, RibbonControlEventArgs e)
        {
            using (var sessionInfo = new SessionInformationForm(AppsSettings.GetInstance().Session))
                sessionInfo.ShowDialog();
        }

        private void Btn_ContentFormat_Click(object sender, RibbonControlEventArgs e)
        {
            if (Globals.ThisAddIn.Application.Documents.Count > 0)
            {
                Word.Selection selection = Globals.ThisAddIn.Application.Selection;
                try
                {
                    selection.set_Style(Globals.ThisAddIn.Application.ActiveDocument.Styles[Constants.ContentStyle]);
                }
                catch (Exception ee)
                {
                    Debug.WriteLine("Error while formating document");
                }
            }
        }
        int index = 0;
        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            
            if (index % 3 == 1)
                NotificationFactor.InfoNotification("Toi la thong bao");
            else if (index %3 == 2)
                NotificationFactor.WarningNotification("Toi la thong bao");
            else
                NotificationFactor.ErrorNotification("Toi la thong bao");

            index +=1;
        }
    }
}
