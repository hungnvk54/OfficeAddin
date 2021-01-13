using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.DataMessage
{
    class AudioParentMessage: BaseMessage
    {
        public AudioEntity data
        {
            get;set;
        }
    }
}
