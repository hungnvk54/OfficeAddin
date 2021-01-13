using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BocBang.DataMessage
{
    public class BaseMessage
    {
        public long status
        {
            get; set;
        }
        [JsonProperty(Required = Required.AllowNull)]
        public string errMes
        {
            get; set;
        }
    }
}
