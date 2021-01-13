using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.DataMessage
{
    public class GGGActivitiesMessage: BaseMessage
    {

        public List<GGGActivityEntitity> data
        {
            get;set;
        }
    }
}
