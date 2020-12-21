using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BocBang.DataMessage
{
    public class GGGActivityEntitity
    {
        public long activity_id
        {
            get;set;
        }
        public string code
        {
            get;set;
        }
        public string name
        {
            get;set;
        }

        public long old_id
        {
            get;set;
        }
        [JsonProperty(Required =Required.AllowNull)]
        public string session_prefix_title
        {
            get;set;
        }
        [JsonProperty(Required = Required.AllowNull)]
        public long ordering
        {
            get;set;
        }
        [JsonProperty(Required = Required.AllowNull)]
        public long menu_status
        {
            get;set;
        }
        public string title_view_doc
        {
            get; set;
        }
        public string title_view_doc_2
        {
            get;set;
        }
        [JsonProperty(Required = Required.AllowNull)]
        public long meeting_type
        {
            get;set;
        }
    }
}
