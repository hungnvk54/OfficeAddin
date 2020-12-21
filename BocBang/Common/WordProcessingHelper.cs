using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using BocBang.DataMessage;
using System.Diagnostics;

namespace BocBang.Common
{
    class WordProcessingHelper
    {
        /// <summary>
        /// Split the representative speech content in the document
        /// </summary>
        /// <param name="document"> Document that contains the whole content</param>
        /// <returns></returns>
        public static DocumentEntity ParsingDocument(Word.Document document,
            List<RepresentativeEntity> representativeEntities)
        {
            DocumentEntity documentesEntity = new DocumentEntity();

            DocumentParagraph documentParagraph = new DocumentParagraph();
            documentesEntity.paragraphs.Add(documentParagraph);
            foreach (Word.Paragraph para in TextHelpers.GetText(document))
            {
                string styleName = ((Word.Style)para.get_Style()).NameLocal;
                if (styleName.Equals(Constants.RerpesentativeStyle))
                {
                    RepresentativeEntity entity = FindRepresentative(representativeEntities, para.Range.Text);
                    if (entity != null)
                    {   
                        documentParagraph = new DocumentParagraph();
                        documentesEntity.paragraphs.Add(documentParagraph);
                        documentParagraph.belongTo = entity;
                        documentParagraph.belongTo.fullTitle = Utils.FormatRepresentative(entity.name, entity.duty);
                    } else
                    {
                        if (!para.Range.Text.Trim().Equals(""))
                        {
                            documentParagraph.contents.Add(para.Range.Text);
                        }
                    }
                } else if (!Constants.TitleStyles.Contains(styleName))
                {
                    ///Do not get the title content
                    if (!para.Range.Text.Trim().Equals(""))
                    {
                        documentParagraph.contents.Add(para.Range.Text);
                    }
                }
            }

            return documentesEntity;
        } 


        public static RepresentativeEntity FindRepresentative(List<RepresentativeEntity> representativeEntities,
            string representativeText)
        {
            foreach (RepresentativeEntity entity in representativeEntities)
            {
                if (representativeText.Trim().Equals(Utils.FormatRepresentative(entity.name, entity.duty)))
                {
                    return entity;
                }
            }

            return null;
        }

        public static void GenerateRepresentativeDocument(List<DocumentParagraph> representativeDocumentParagraph, Word.Document document)
        {
            Word.Selection selection = Globals.ThisAddIn.Application.Selection;
            foreach (DocumentParagraph documentParagraph in representativeDocumentParagraph)
            {
                if (documentParagraph.belongTo != null )
                {
                    selection.set_Style(document.Styles[Constants.RerpesentativeStyle]);
                    selection.TypeText(Utils.FormatRepresentative(documentParagraph.belongTo.name,
                        documentParagraph.belongTo.duty));
                    selection.TypeParagraph();
                }
                selection.set_Style(document.Styles[Constants.ContentStyle]);
                foreach (string content in documentParagraph.contents)
                {
                    selection.TypeText(content);
                }
            }
        }

        public static void CreateDefaultDocumentStyle(Word.Document newDocument)
        {
            Word.PageSetup pageSetup = newDocument.PageSetup;
            pageSetup.TopMargin = Globals.ThisAddIn.Application.InchesToPoints(0.95f);
            pageSetup.BottomMargin = Globals.ThisAddIn.Application.InchesToPoints(0.79f);
            pageSetup.LeftMargin = Globals.ThisAddIn.Application.InchesToPoints(0.98f);
            pageSetup.RightMargin = Globals.ThisAddIn.Application.InchesToPoints(0.79f);


            ///Ten dai bieu
            Word.Style style = Globals.ThisAddIn.Application.ActiveDocument.Styles.Add(Constants.RerpesentativeStyle);

            style.Font.Name = "Times New Roman";
            style.Font.Size = 13;
            style.Font.Color = Word.WdColor.wdColorBlue;
            style.Font.Bold = -1;
            style.Font.Italic = -1;

            style.ParagraphFormat.FirstLineIndent = Globals.ThisAddIn.Application.InchesToPoints(0.37f);
            style.ParagraphFormat.SpaceBefore = 6;

            ///Loi phat bieu
            style = Globals.ThisAddIn.Application.ActiveDocument.Styles.Add(Constants.ContentStyle);

            style.Font.Name = "Times New Roman";
            style.Font.Size = 13;
            style.Font.Color = Word.WdColor.wdColorBlue;

            style.ParagraphFormat.FirstLineIndent = Globals.ThisAddIn.Application.InchesToPoints(0.37f);
            style.ParagraphFormat.SpaceAfterAuto = 0;
            style.ParagraphFormat.SpaceBefore = 0;

            ///Tieu de bien ban
            style = Globals.ThisAddIn.Application.ActiveDocument.Styles.Add(Constants.MeetingTitleStyle);
            style.Font.Name = "Times New Roman";
            style.Font.Size = 16;
            style.Font.Color = Word.WdColor.wdColorBlue;
            style.Font.Bold = -1;
            style.Font.AllCaps = -1;
            style.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            /// Ghi theo bang ghi am
            style = Globals.ThisAddIn.Application.ActiveDocument.Styles.Add(Constants.RecordingTitleStyle);

            style.Font.Name = "Times New Roman";
            style.Font.Size = 12;
            style.Font.Color = Word.WdColor.wdColorBlue;
            style.Font.Italic = -1;
            style.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            style.ParagraphFormat.SpaceBefore = 3;
            ///Thoi gian hop
            style = Globals.ThisAddIn.Application.ActiveDocument.Styles.Add(Constants.MeetingTimeTitleStyle);
            style.Font.Name = "Times New Roman";
            style.Font.Size = 13;
            style.Font.Color = Word.WdColor.wdColorBlue;
            style.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            style.ParagraphFormat.SpaceBefore = 3;
            ///Noi dung
            style = Globals.ThisAddIn.Application.ActiveDocument.Styles.Add(Constants.MeetingContentTitleStyle);
            style.Font.Name = "Times New Roman";
            style.Font.Size = 13;
            style.Font.Color = Word.WdColor.wdColorBlue;
            style.Font.Bold = -1;
            style.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            style.ParagraphFormat.SpaceBefore = 12;
        }

        /// <summary>
        /// Create default title.
        /// BẢN TỔNG HỢP THẢO LUẬN TẠI HỘI TRƯỜNG
        ///       (Ghi theo băng ghi âm)
        ///      Buổi sáng ngày 07/12/2020
        ///             Nội dung:
        ///                 1 
        ///      Đại biểu chủ trì 2 chủ trì
        ///Người điều hành nội dung điều hành nội dung

        /// </summary>
        /// <param name="document"></param>
        /// <param name="sessionEntity"></param>
        public static void CreateDocumentTitle(Word.Document document, SessionsEntity sessionEntity)
        {
            Word.Selection selection = Globals.ThisAddIn.Application.Selection;

            /// Create title
            /// BẢN TỔNG HỢP THẢO LUẬN TẠI HỘI TRƯỜNG
            string meetingTitle = "BẢN TỔNG HỢP THẢO LUẬN TẠI HỘI TRƯỜNG";
            if (sessionEntity.activity.type == Constants.ACTIVITY_TYPE_TO)
            {
                meetingTitle = string.Format("BẢN TỔNG HỢP THẢO LUẬN TẠI {0}", sessionEntity.activityGroup.nameActivityGroup);
            }
            selection.set_Style(document.Styles[Constants.MeetingTitleStyle]);
            selection.TypeText(meetingTitle);
            selection.TypeParagraph();

            ///  (Ghi theo băng ghi âm)
            selection.set_Style(document.Styles[Constants.RecordingTitleStyle]);
            selection.TypeText("(Ghi theo băng ghi âm)");
            selection.TypeParagraph();

            ///Buổi sáng ngày 07/12/2020
            string meetingDate = string.Format("Buổi {0} ngày {1}", sessionEntity.meetingEntity.name, sessionEntity.meetingDay);
            selection.set_Style(document.Styles[Constants.MeetingTimeTitleStyle]);
            selection.TypeText(meetingDate);
            selection.TypeParagraph();

            /// Tieu de: Nội dung:
            selection.set_Style(document.Styles[Constants.MeetingContentTitleStyle]);
            selection.TypeText("Nội dung:");
            selection.TypeParagraph();

            /// Noi dung
            selection.set_Style(document.Styles[Constants.MeetingContentTitleStyle]);
            selection.TypeText(sessionEntity.contentMeeting);
            selection.TypeParagraph();

            if (sessionEntity.activity.type == Constants.ACTIVITY_TYPE_TO)
            {
                string contentControl = string.Format("Chủ trì: {0}", sessionEntity.leadConference);
                selection.set_Style(document.Styles[Constants.MeetingContentTitleStyle]);
                selection.TypeText(contentControl);
                selection.TypeParagraph();
            } else
            {
                ///Đại biểu chủ trì 2 chủ 
                string leadingCoference = string.Format("{0} chủ trì", sessionEntity.leadConference);
                selection.set_Style(document.Styles[Constants.MeetingContentTitleStyle]);
                selection.TypeText(leadingCoference);
                selection.TypeParagraph();

                ///Người điều hành nội dung điều hành nội dung
                string contentControl = string.Format("{0} điều hành nội dung", sessionEntity.personContentControl);
                selection.set_Style(document.Styles[Constants.MeetingContentTitleStyle]);
                selection.TypeText(contentControl);
                selection.TypeParagraph();
                selection.set_Style(document.Styles[Constants.ContentStyle]);
            }
            
        }

        public static void InsertDataToMergedDocument(Word.Document document, DocumentEntity documentEntity)
        {
            Word.Selection selection = Globals.ThisAddIn.Application.Selection;

            foreach(DocumentParagraph documentParagraph in documentEntity.paragraphs)
            {
                if (documentParagraph.belongTo != null)
                {
                    selection.set_Style(document.Styles[Constants.RerpesentativeStyle]);
                    
                    if (documentParagraph.belongTo.fullTitle != null)
                    {
                        selection.TypeText(documentParagraph.belongTo.fullTitle);
                    } else if (documentParagraph.belongTo.name != null &&
                        documentParagraph.belongTo.duty != null)
                    {
                        selection.TypeText(Utils.FormatRepresentative(documentParagraph.belongTo.name, documentParagraph.belongTo.duty));
                    }
                    selection.TypeParagraph();
                }

                selection.set_Style(document.Styles[Constants.ContentStyle]);
                foreach ( string content in documentParagraph.contents)
                {
                    if (!content.Trim().Equals(""))
                    {
                        selection.TypeText(content.Trim());
                        selection.TypeParagraph();
                    }
                }
            }
        }
    }
}
