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
            //Globals.ThisAddIn.Application.DocumentBeforeClose += Application_DocumentBeforeClose;
            Globals.ThisAddIn.Application.DocumentBeforeSave += Application_DocumentBeforeSave;
            //Globals.ThisAddIn.Application.WindowSelectionChange += Application_WindowSelectionChange;
            Globals.ThisAddIn.Application.WindowActivate += Application_WindowActivate;
            ApplicationInitFormData();
        }

        private void SettingKeyTips()
        {
            this.Btn_ListSession.KeyTip = "G";
        }

        private void ActiveControl()
        {
            ///Enable button
            this.Btn_Insert.Enabled = true;
            this.Btn_Spit.Enabled = true;
            this.Btn_Export.Enabled = true;
            this.Btn_Undo.Enabled = true;
            this.Btn_ListAudio.Enabled = true;
            this.Btn_Merge.Enabled = true;
            this.Btn_SessionInfo.Enabled = true;
            this.Btn_Save.Enabled = true;
            this.btn_ResetAll.Enabled = true;
        }

        private void FocusMainDocument()
        {
            Globals.ThisAddIn.Application.ActiveWindow.SetFocus();
            //Globals.ThisAddIn.Application.Activate();
        }

        private void DeactiveControl()
        {
            ///Enable button
            this.Btn_Insert.Enabled = false;
            this.Btn_Spit.Enabled = false;
            this.Btn_Export.Enabled = false;
            this.Btn_Undo.Enabled = false;
            this.Btn_ListAudio.Enabled = false;
            this.Btn_Merge.Enabled = false;
            this.Btn_SessionInfo.Enabled = false;
            this.Btn_Save.Enabled = false;
            this.btn_ResetAll.Enabled = false;
        }

        private void Application_WindowActivate(Word.Document Doc, Word.Window Wn)
        {
            Debug.WriteLine("Windown Active on this: " + Doc.FullName + "  " +
                Doc.FullName.Equals(AppsSettings.GetInstance().DocumentName));
            if (AppsSettings.GetInstance().isLogin &&
                AppsSettings.GetInstance().Session != null &&
                AppsSettings.GetInstance().DocumentName != null &&
                Doc.FullName.Equals(AppsSettings.GetInstance().DocumentName))
            {
                ActiveControl();
            }
            else
            {
                DeactiveControl();
            }


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
            if (AppsSettings.GetInstance().isLogin &&
                 AppsSettings.GetInstance().Session != null &&
                 AppsSettings.GetInstance().DocumentName != null &&
                Doc.FullName.Equals(AppsSettings.GetInstance().DocumentName))
            {
                Debug.WriteLine(Doc.FullName);
                SaveDocumentToRemoteServer();
            }
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
            if (this.mRepresentativeForm == null)
            {
                this.mRepresentativeForm = new RepresentativeForm();
            }
            this.mRepresentativeForm.CustomShowDialog();

            this.FocusMainDocument();
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
                        SaveDocumentToRemoteServer(false);
                    }
                }

                DialogResult result = DialogResult.OK;
                result = this.mSessionListForm.CustomDialogShow();
                if (result == DialogResult.OK)
                {
                    ///Create new document and save as new file
                    Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                    AppsSettings.GetInstance().DocumentName = null; //To prevent save unknow document
                    WordProcessingHelper.SaveNewSessionDocument(AppsSettings.GetInstance().Session, document);
                    ///Create default document
                    WordProcessingHelper.CreateDocumentTitle(document,
                        AppsSettings.GetInstance().Session);
                    AppsSettings.GetInstance().DocumentName = document.FullName;
                    //Get document Entity
                    DocumentEntity documentEntity = Request.getMergedDocument(AppsSettings.GetInstance().Session.idSession);
                    WordProcessingHelper.InsertDataToMergedDocument(document, documentEntity);
                    ///Load predefine data
                    mRepresentativeForm.FillingData();
                    AppsSettings.GetInstance().IsRepresentativeSplit = false;
                    this.FocusMainDocument();
                    this.ActiveControl();
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
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                //0. Kiem tra danh sach dai bieu
                /*string missingName;
                if (WordProcessingHelper.CheckRepresentativeList(document, 
                    mRepresentativeForm.GetRepresentativeList(), out missingName) == false)
                {
                    //Tai lai danh sach
                    mRepresentativeForm.FillingData();
                    if (WordProcessingHelper.CheckRepresentativeList(document,
                    mRepresentativeForm.GetRepresentativeList(), out missingName) == false)
                    {
                        ///Notify nguoi dung tao moi
                        DialogResult result = CreateInformationDialog.CreateConfirmBoxWithTwoButton("Không tìm thấy đại biểu: " + missingName + "  Bạn có muốn thêm mới?", "Cảnh báo");
                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(AppsSettings.GetInstance().ApiUrl + "/quan-ly-dai-bieu");
                        }
                    }
                }*/
                //1. Luu lai cac thay doi
                ///Kiem tra xem co thay doi nao khoong, neu co, luu lai thay doi
                /*DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                    document, mRepresentativeForm.GetRepresentativeList());
                documentEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
                Request.SaveDocument(documentEntity);*/
                //2. Goi ham merge doc
                AudioEntity entity = Request.GetParentAudioByIdSession(AppsSettings.GetInstance().Session.idSession);
                if (entity == null)
                {
                    CreateInformationDialog.CreateWarningBox("Không tồn tại tệp âm thanh tổng hợp", "cảnh báo");
                } else
                {
                    DocumentEntity mergedDocument = Request.RequestMergeAndGetResult(entity.idAudio);

                    if (mergedDocument == null)
                    {
                        NotificationFactor.ErrorNotification("Tổng hợp biên bản thất bại");
                        return;
                    }

                    //3.Goi ham lay lai du lieu
                    //Get document Entity
                    //documentEntity = Request.getMergedDocument(AppsSettings.GetInstance().Session.idSession);
                    //4.Clear current document
                    //TextHelpers.RemoveContent(document);
                    //4. day du lieu ra ma hinh
                    WordProcessingHelper.InsertDataToEndDocument(Globals.ThisAddIn.Application.ActiveDocument, mergedDocument);
                    AppsSettings.GetInstance().IsRepresentativeSplit = false;
                    NotificationFactor.InfoNotification("Tổng hợp biên bản thành công");
                }
                
            } catch (Exception ee)
            {
                NotificationFactor.ErrorNotification("Tổng hợp biên bản thất bại");
            }

            Cursor.Current = Cursors.Default;
        }

        private void Btn_Spit_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                string missingName;
                if (WordProcessingHelper.CheckRepresentativeList(document,
                    mRepresentativeForm.GetRepresentativeList(), out missingName) == false)
                {
                    //Tai lai danh sach
                    mRepresentativeForm.FillingData();
                    if (WordProcessingHelper.CheckRepresentativeList(document,
                    mRepresentativeForm.GetRepresentativeList(), out missingName) == false)
                    {
                        ///Notify nguoi dung tao moi
                        DialogResult result = CreateInformationDialog.CreateConfirmBoxWithTwoButton("Không tìm thấy đại biểu: " + missingName + "  Bạn có muốn thêm mới?", "Cảnh báo");
                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(AppsSettings.GetInstance().ApiUrl + "/quan-ly-dai-bieu");
                        }
                        return;
                    }
                }
                DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                    document, mRepresentativeForm.GetRepresentativeList());

                ///Save document to server
                documentEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
                Request.SaveDocument(documentEntity);

                ///Call API to split representative
                Request.RequestSplitRepresentative(AppsSettings.GetInstance().Session.idSession);

                mRepresentativeSplitForm.InitDataFormIntoForm(documentEntity);
                mRepresentativeSplitForm.ShowDialog();
                AppsSettings.GetInstance().IsRepresentativeSplit = true;
            } catch (Exception ee)
            {
                NotificationFactor.ErrorNotification("Không thể tách lời đại biểu");
            }
            

        }

        private void Btn_Export_Click(object sender, RibbonControlEventArgs e)
        {
            if (AppsSettings.GetInstance().IsRepresentativeSplit == true)
            {
                mExportForm.LoadingData();
                DialogResult dialogResult = mExportForm.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    NotificationFactor.InfoNotification("Xuất bản thành công");
                }
                else if (dialogResult == DialogResult.No)
                {
                    NotificationFactor.ErrorNotification("Xuất bản thất bại");
                }
            }
            else
            {
                CreateInformationDialog.CreateWarningBox("Bạn chưa tách lời đại biểu. Tách lời đại biểu trước khi xuất bản.",
                    "cảnh báo");
            }
        }

        private void Btn_Undo_Click(object sender, RibbonControlEventArgs e)
        {
            DialogResult dialogResult = CreateInformationDialog.CreateConfirmBoxWithTwoButton(
                "Bạn có chắc chắn muốn thu hồi phiên họp từ hệ thống 3G?", "Xác nhận");
            if (dialogResult == DialogResult.Yes)
            { 
                if (AppsSettings.GetInstance().Session != null)
                {
                    Boolean deleteResult = Request.RemoteGGGSession(AppsSettings.GetInstance().Session.idSession);
                    if (deleteResult == true)
                    {
                        NotificationFactor.InfoNotification("Thu hồi phiên thành công");
                    } else
                    {
                        NotificationFactor.ErrorNotification("Thu hồi phiên thất bại");
                    }
                } else
                {
                    NotificationFactor.ErrorNotification("Thu hồi phiên thất bại");
                }
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
            Cursor.Current = Cursors.WaitCursor;
            SaveDocumentToRemoteServer();
            Cursor.Current = Cursors.Default;
        }

        private void SaveDocumentToRemoteServer(bool isNotify = true)
        {
            try
            {
                //1. Luu lai cac thay doi
                ///Kiem tra xem co thay doi nao khoong, neu co, luu lai thay doi
                if (AppsSettings.GetInstance().isLogin == true)
                {
                    Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                    /*string missingName;
                    if (WordProcessingHelper.CheckRepresentativeList(document,
                        mRepresentativeForm.GetRepresentativeList(), out missingName) == false)
                    {
                        //Tai lai danh sach
                        mRepresentativeForm.FillingData();
                        if (WordProcessingHelper.CheckRepresentativeList(document,
                        mRepresentativeForm.GetRepresentativeList(), out missingName) == false)
                        {
                            ///Notify nguoi dung tao moi
                            DialogResult result = CreateInformationDialog.CreateConfirmBoxWithTwoButton("Không tìm thấy đại biểu: " + missingName + "  Bạn có muốn thêm mới?", "Cảnh báo");
                            if (result == DialogResult.Yes)
                            {
                                System.Diagnostics.Process.Start(AppsSettings.GetInstance().ApiUrl + "/quan-ly-dai-bieu");
                            }
                        }
                    }*/
                    DocumentEntity documentEntity = WordProcessingHelper.ParsingDocument(
                        document, mRepresentativeForm.GetRepresentativeList());
                    documentEntity.sessionId = AppsSettings.GetInstance().Session.idSession;
                    Request.SaveDocument(documentEntity);

                    if( isNotify)
                        NotificationFactor.InfoNotification("Lưu nội dung thành công");
                }
                else
                {
                    if (isNotify)
                        NotificationFactor.WarningNotification("Không thể lưu văn bản do chưa đăng nhập");
                }
            }
            catch (Exception e)
            {
                if (isNotify)
                    NotificationFactor.ErrorNotification("Lưu nội dung thất bại");
            }

            this.FocusMainDocument();
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

        private void btn_ResetAll_Click(object sender, RibbonControlEventArgs e)
        {
            DialogResult dialogResult = CreateInformationDialog.CreateConfirmBoxWithTwoButton("" +
                "Tổng hợp lại toàn bộ sẽ xóa toàn bộ thay đổi trên tệp tổng hợp và ghép lại các băng đã được kiểm duyệt. Bạn có muốn tiếp tục?", "Cảnh báo");
            try
            {
                if (dialogResult == DialogResult.Yes && AppsSettings.GetInstance().Session != null)
                {
                    Debug.WriteLine("Xoa toan bo");
                    ///1. Reset merged request

                    bool resetMergedStatus = Request.ResetMergeDocument(AppsSettings.GetInstance().Session.idSession);

                    if (resetMergedStatus == true)
                    {
                        ///Call remerged document
                        //2. Goi ham merge doc
                        AudioEntity entity = Request.GetParentAudioByIdSession(AppsSettings.GetInstance().Session.idSession);
                        if (entity == null)
                        {
                            CreateInformationDialog.CreateWarningBox("Không tồn tại tệp âm thanh tổng hợp", "cảnh báo");
                        }
                        else
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
                        DocumentEntity documentEntity = Request.getMergedDocument(AppsSettings.GetInstance().Session.idSession);
                        //4.Clear current document
                        AppsSettings.GetInstance().DocumentName = null; // To avoid save document when call the saveAs method
                        Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                        WordProcessingHelper.SaveNewSessionDocument(AppsSettings.GetInstance().Session, document);
                        WordProcessingHelper.CreateDocumentTitle(document, AppsSettings.GetInstance().Session);
                        //4. day du lieu ra ma hinh
                        WordProcessingHelper.InsertDataToMergedDocument(Globals.ThisAddIn.Application.ActiveDocument, documentEntity);
                        AppsSettings.GetInstance().IsRepresentativeSplit = false;
                        AppsSettings.GetInstance().DocumentName = document.FullName;
                    } else
                    {
                        NotificationFactor.ErrorNotification("Không thể tổng hợp lại biên bản");
                    }
                }
            } catch (Exception ex)
            {
                NotificationFactor.ErrorNotification("Không thể tổng hợp lại biên bản");
            }
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;

            TextHelpers.GoToEndDocument(document);
        }
    }
}
