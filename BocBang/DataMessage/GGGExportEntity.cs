using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.DataMessage
{
    public class GGGExportEntity
    {
        public long sessionId
        {
            get;set;
        }
        public GGGActivityEntitity activity
        {
            get;set;
        }

        public long locationId
        {
            get;set;
        }

        public int confidentialStatus
        {
            get;set;
        }

        public List<long> allowedGroupIds
        {
            get;set;
        }
    }
}
