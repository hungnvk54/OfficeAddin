using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.DataMessage
{
    public class DocumentMessage: BaseMessage
    {
       public DocumentEntity data
        {
            get;set;
        }
    }
}
