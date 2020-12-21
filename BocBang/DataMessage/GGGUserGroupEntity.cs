using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.DataMessage
{
    public class GGGUserGroupEntity
    {
        public long group_id
        {
            get;set;
        }
        public string group_name
        {
            get;set;
        }

        public long default_confidential_accessible
        {
            get;set;
        }
    }
}
