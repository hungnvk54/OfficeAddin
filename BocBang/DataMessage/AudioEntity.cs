using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BocBang.DataMessage
{
    public class AudioEntity
    {
        public long idAudio
        {
            get;set;
        }

        [JsonProperty(Required = Required.AllowNull)]
        public long idAudioParent
        {
            get;set;
        }

        public string nameAudio
        {
            get;set;
        }
        [JsonProperty(Required = Required.AllowNull)]
        public UserEntity userHandle
        {
            get;set;
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? statusReview
        {
            get;set;
        }
        [JsonProperty(Required = Required.AllowNull)]
        public string infoAudio
        {
            get;set;
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long isUpdate
        {
            get;set;
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long status
        {
            get;set;
        }
    }
}
