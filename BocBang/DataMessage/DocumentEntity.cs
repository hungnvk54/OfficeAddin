using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.DataMessage
{
    public class DocumentEntity
    {
        public DocumentEntity()
        {
            this.paragraphs = new List<DocumentParagraph>();
        }
        public List<DocumentParagraph> paragraphs
        {
            get;set;
        }

        public long sessionId
        {
            get;set;
        }
    }

    public class DocumentParagraph
    {
        /// <summary>
        /// Init the content first to avoid crash
        /// </summary>
        public DocumentParagraph()
        {
            this.contents = new List<string>();
        }

        /// <summary>
        /// In Case of no representative, this will be null.
        /// </summary>
        public RepresentativeEntity belongTo
        {
            get;set;
        }

        /// <summary>
        /// List paragraph belong to representative
        /// </summary>
        public List<string> contents
        {
            get;set;
        }
    }
}
