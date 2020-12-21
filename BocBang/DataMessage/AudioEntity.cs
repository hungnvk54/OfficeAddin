using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.DataMessage
{
    public class AudioEntity
    {
        public long idAudio
        {
            get;set;
        }

        public long idAudioParent
        {
            get;set;
        }

        public string nameAudio
        {
            get;set;
        }

        public UserEntity userHandle
        {
            get;set;
        }

        public long statusReview
        {
            get;set;
        }

        public string infoAudio
        {
            get;set;
        }

        public long isUpdate
        {
            get;set;
        }

        public long status
        {
            get;set;
        }
    }
}
