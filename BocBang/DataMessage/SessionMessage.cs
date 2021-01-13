using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BocBang.DataMessage
{
    class SessionMessage
    {
        public long status
        {
            get;set;
        }

        [JsonProperty(Required =Required.AllowNull)]
        public string errMes
        {
            get;set;
        }

        public SessionData data
        {
            get;set;
        }
    }

    public class SessionData
    {
        public long total
        {
            get;set;
        }

        public List<SessionsEntity> listSession
        {
            get;set;
        }
    }
}
