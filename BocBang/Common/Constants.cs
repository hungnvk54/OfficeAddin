using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BocBang.Common
{
    class Constants
    {
        public static string ContentStyle = "ContentStyle";
        public static string RerpesentativeStyle = "RepresentativeStyle";
        public static string MeetingTitleStyle = "MeetingTileStyle";
        public static string RecordingTitleStyle = "RecordingTitleStyle";
        public static string MeetingTimeTitleStyle = "MeetingTimeTitleStyle";
        public static string MeetingContentTitleStyle = "MeetingContentTitleStyle";

        public static string[] ListTitleStyle = { MeetingTitleStyle , 
                                                    RecordingTitleStyle,
                                                    MeetingTimeTitleStyle,
                                                    MeetingContentTitleStyle};
        public static HashSet<string> TitleStyles = new HashSet<string>(ListTitleStyle);


        ///
        public static int PARAGRAPH_REPRESENTATIVE_NAME = 0;
        public static int PARAGRAPH_REPRESENTATIVE_SPEECH = 0;


        ///Actity type
        public static long ACTIVITY_TYPE_HOI_TRUONG = 1;
        public static long ACTIVITY_TYPE_TO = 2;
        public static long ACTIVITY_TYPE_HN_DBQH_CHUYEN_TRACH = 4;
        public static long ACTIVITY_TYPE_KHAC = 5;
        public static long ACTIVITY_TYPE_THUONG_VU = 3;


        ///Response Code
        public static long RESPONSE_STATUS_ERROR = 0;
        public static long RESPONSE_STATUS_SUCCESS = 1;

    }
}
