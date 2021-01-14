using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocBang.DataMessage
{
    public class ActivityEntityMessage: BaseMessage
    {
        public List<ActivityEntity> data
        {
            get;set;
        }
    }
}
