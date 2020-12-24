﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;


namespace BocBang.Common
{
    class TextHelpers
    {
        public static IEnumerable<Word.Paragraph> GetText(Word.Document doc)
        {
            foreach (Word.Paragraph para in doc.Paragraphs)
            {
                yield return para;
            }

            yield break;
        }

        public static void RemoveContent(Word.Document doc)
        {
            foreach (Word.Paragraph para in doc.Paragraphs)
            {
                int startRange = -1, endRange = -1;
                string paragraphStyleName = ((Word.Style)para.get_Style()).NameLocal;
                if (!Constants.TitleStyles.Contains(paragraphStyleName))
                {
                    Word.Range range = doc.Range(para.Range.Start, para.Range.End);
                    range.Delete();
                }
                Debug.WriteLine("Paragraph Start " + para.Range.Start + " Stop: " + para.Range.End);
            }

            Word.Selection selection = Globals.ThisAddIn.Application.Selection;
            selection.TypeParagraph();
            selection.set_Style(doc.Styles[Constants.ContentStyle]);
        }

        public static void RemoveAllContent(Word.Document doc)
        {
            foreach (Word.Paragraph para in doc.Paragraphs)
            {
                Word.Range range = doc.Range(para.Range.Start, para.Range.End);
                range.Delete();
            }

            Word.Selection selection = Globals.ThisAddIn.Application.Selection;
            selection.TypeParagraph();
            selection.set_Style(doc.Styles[Constants.ContentStyle]);
        }

        public static void GoToEndDocument(Word.Document doc)
        {
            int endDocument = -1;
            foreach (Word.Paragraph para in doc.Paragraphs)
            {
                Word.Range range = doc.Range(para.Range.Start, para.Range.End);
                endDocument = para.Range.End;
            }

            if (endDocument > 0 )
            {
                Globals.ThisAddIn.Application.Selection.SetRange(endDocument - 1, endDocument - 1);
            }
        }
    }
}
