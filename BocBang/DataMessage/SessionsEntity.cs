using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BocBang.DataMessage
{
    public class SessionsEntity
    {
        [JsonProperty(Required = Required.Always)]
        public long idSession
        {
            get;set;
        }

        public ActitityEntity activity
        {
            get;set;
        }

        public string leadConference
        {
            get;set;
        }

        [JsonProperty(Required =Required.AllowNull)]
        public string createDate
        {
            get;set;
        }

        //id user create
        public long nationalAssembly
        {
            get;set;
        }

        public long meeting
        {
            get;set;
        }

        public string meetingDay
        {
            get;
            set;
        }
        public MeetingEntity meetingEntity
        {
            get;set;
        }
        public string contentMeeting
        {
            get;set;
        }

        public string personContentControl
        {
            get;set;
        }

        [JsonProperty(Required =Required.AllowNull)]
        public ActivityGroup activityGroup
        {
            get;set;
        }

        public long public_status
        {
            get;set;
        }
    }
}
