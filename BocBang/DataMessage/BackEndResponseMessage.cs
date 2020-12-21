using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocBang
{
    public class BackEndResponseMessage
    {
        public BackEndResponseMessage()
        {
            this.status = "";
            this.errMes = "";
            this.data = "";
        }
        public string status
        {
            get; set;
        }
        public string errMes
        {
            get; set;
        }
        public string data
        {
            get; set;
        }
    }
}
