using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace BocBang.DataMessage
{
    public class GGGUserGroupMessage : BaseMessage
    {
        [JsonProperty(Required = Required.AllowNull)]
        public List<GGGUserGroupEntity> data
        {
            get;set;
        }
    }
}
