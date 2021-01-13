using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BocBang.DataMessage
{
    public class GGGLocationEntity
    {
        public long place_id 
        {
            get;set;
        }

        public string code
        {
            get; set;
        }

        [JsonProperty(Required = Required.AllowNull)]
        public string name
        {
            get;set;
        }
    }
}
