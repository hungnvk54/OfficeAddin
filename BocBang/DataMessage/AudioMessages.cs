using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BocBang.DataMessage
{
    public class AudioMessages : BaseMessage
    {

        [JsonProperty(Required =Required.AllowNull)]
        public List<AudioEntity> data
        {
            get;set;
        }
    }
}
