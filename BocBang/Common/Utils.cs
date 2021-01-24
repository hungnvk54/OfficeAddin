using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BocBang.DataMessage;
using System.Collections.Generic;

namespace BocBang
{
    class Utils
    {
        public enum ConnectionType
        {
            NormProtocol = 0,
            SSLProtocol = 1,
            Unknown = 2
        }
        public static string ParsingApiUrl()
        {
            return AppsSettings.GetInstance().ApiUrl;
        }


        public static string ParsingSessionId(string url)
        {
            /* The url format: http://hostname/phien-hop/1323 */
            String[] spearator = { "/"};
            String[] listPattern = url.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            if (listPattern.Length <=3)
            {
                return String.Empty;
            }
            else
            {
                return listPattern[listPattern.Length - 1];
            }
        }

        public static ConnectionType ParsingConnectionType(String url)
        {
            ConnectionType type = ConnectionType.NormProtocol;
            if (url.StartsWith("wss://") || url.StartsWith("https://"))
            {
                type = ConnectionType.SSLProtocol;
            }
            else if (url.StartsWith("ws://") || url.StartsWith("http://"))
            {
                type = ConnectionType.NormProtocol;
            }
            else
            {
                type = ConnectionType.Unknown;
            }

            return type;
        }

        public static string Base64Encode(byte [] data, int length)
        {
            return System.Convert.ToBase64String(data, 0, length);
        }

        public static string GetFilePath(string fileName, string ext, string addPath = "")
        {
            if (string.IsNullOrEmpty(addPath))
            {
                return Path.Combine(AppsSettings.GetInstance().DataDir, fileName + ext);
            }
            else
            {
                return Path.Combine(AppsSettings.GetInstance().DataDir, addPath, fileName + ext);
            }
        }

        public static string GetAudioFilePath(string session, string fileName, string ext)
        {
            return GetFilePath(fileName, ext, session);
        }


        public static string FormatRepresentative(String name, String duty)
        {
            return String.Format("{0} - {1}", name, duty);
        }

        public static string FormatRepresentativeWindownSeperator(String name, String duty)
        {
            return String.Format("{0} – {1}", name, duty);
        }

        public static bool CompareRepresentative(
            string representativeTitle, string name, string duty
            )
        {
            bool isEqual = representativeTitle.Trim().Equals(FormatRepresentative(name, duty)) ||
                representativeTitle.Trim().Equals(FormatRepresentativeWindownSeperator(name, duty));

            return isEqual;
        }


        public static string fromUtf8ToAscii(string src)
        {
            /*"a á, à, ả, ạ, ã
             ă ắ, ằ, ẳ, ặ, ẵ
             â ấ, ầ, ẩ, ậ, ẫ
             b
             c
             d
             đ
             e é, è, ẻ, ẹ, ẽ,
             ê ế, ề, ể, ệ, ễ,
             g
             h
             i í, ì, ỉ, ị, ĩ
             k l m n 
             o ó, ò, ỏ, ọ, õ
             ô ố ồ ổ ộ ỗ
             ơ ớ ờ ở ợ ỡ
             p q r s t 
             u ú ù ủ ụ ũ
             ư ứ ừ ử, ự, ữ
             v x "
             y ý ỳ ỷ ỵ
            */
            Dictionary<string, string> charMapper = new Dictionary<string, string>();

            charMapper.Add("á", "a"); charMapper.Add("à", "a"); charMapper.Add("ả", "a"); charMapper.Add("ạ", "a"); charMapper.Add("ã", "a");
            charMapper.Add("ă", "a");
            charMapper.Add("ắ", "a"); charMapper.Add("ằ", "a"); charMapper.Add("ẳ", "a"); charMapper.Add("ặ", "a"); charMapper.Add("ẵ", "a");
            charMapper.Add("â", "a");
            charMapper.Add("ấ", "a"); charMapper.Add("ầ", "a"); charMapper.Add("ẩ", "a"); charMapper.Add("ậ", "a"); charMapper.Add("ẫ", "a");
            charMapper.Add("đ", "d");
            charMapper.Add("é", "e"); charMapper.Add("è", "e"); charMapper.Add("ẻ", "e"); charMapper.Add("ẹ", "e"); charMapper.Add("ẽ", "e");
            charMapper.Add("ê", "e");
            charMapper.Add("ế", "e"); charMapper.Add("ề", "e"); charMapper.Add("ể", "e"); charMapper.Add("ệ", "e"); charMapper.Add("ễ", "e");
            charMapper.Add("í", "i"); charMapper.Add("ì", "i"); charMapper.Add("ỉ", "i"); charMapper.Add("ị", "i"); charMapper.Add("ĩ", "i");
            charMapper.Add("ó", "o"); charMapper.Add("ò", "o"); charMapper.Add("ỏ", "o"); charMapper.Add("ọ", "o"); charMapper.Add("õ", "o");
            charMapper.Add("ô", "o");
            charMapper.Add("ố", "o"); charMapper.Add("ồ", "o"); charMapper.Add("ổ", "o"); charMapper.Add("ộ", "o"); charMapper.Add("ỗ", "o");
            charMapper.Add("ơ", "o");
            charMapper.Add("ớ", "o"); charMapper.Add("ờ", "o"); charMapper.Add("ở", "o"); charMapper.Add("ợ", "o"); charMapper.Add("ỡ", "o");
            charMapper.Add("ú", "u"); charMapper.Add("ù", "u"); charMapper.Add("ủ", "u"); charMapper.Add("ụ", "u"); charMapper.Add("ũ", "u");
            charMapper.Add("ư", "u");
            charMapper.Add("ứ", "u"); charMapper.Add("ừ", "u"); charMapper.Add("ử", "u"); charMapper.Add("ự", "u"); charMapper.Add("ữ", "u");
            charMapper.Add("ý", "y"); charMapper.Add("ỳ", "y"); charMapper.Add("ỷ", "y"); charMapper.Add("ỵ", "y"); charMapper.Add("ỹ", "y");

            string dst = "";
            foreach( char c in src)
            {
                if (charMapper.ContainsKey(c.ToString()))
                {
                    dst += charMapper[c.ToString()];
                } else
                {
                    dst += c;
                }
            }

            return dst;
        }
    
        public static string FormatDateTime(string dateTime)
        {
            string[] patterns = { "MM-dd-yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "yyyy-MMM-dd" };

            foreach( string pattern in patterns)
            {
                DateTime formatedDate;
                if (DateTime.TryParseExact(dateTime,pattern,null, System.Globalization.DateTimeStyles.None, out formatedDate))
                {
                    return formatedDate.ToString("dd/MM/yyyy");
                }
            }

            try
            {
                double dateTimeFromEpoch = double.Parse(dateTime)/1000;
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); //from start epoch time
                start.AddSeconds(dateTimeFromEpoch);
                return start.ToString("dd/MM/yyyy");
            } catch (Exception e)
            {
                ///
            }

            return dateTime;
        }

        public static string FormatDateTimeToSaveFile(string dateTime)
        {
            string[] patterns = { "MM-dd-yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "yyyy-MMM-dd" };

            foreach (string pattern in patterns)
            {
                DateTime formatedDate;
                if (DateTime.TryParseExact(dateTime, pattern, null, System.Globalization.DateTimeStyles.None, out formatedDate))
                {
                    return formatedDate.ToString("ddMMyyyy");
                }
            }

            return dateTime;
        }

        public static bool CheckActivityMapping(long bocbang_code, string ggg_code)
        {
            // Code in 3g system
            //Kỳ họp Quốc hội                                       QH
            //	Phiên họp tổ (PHT)                                  TO
            //Phiên họp UBTVQH                                      TV
            //Hội nghị ĐBQH chuyên trách                            HN
            //Phiên họp của HĐDT, các Ủy ban của Quốc hội           UB

            ///Code in bocbang
            /// public static final int TYPE_HOI_TRUONG = 1;

            ///public static final int TYPE_TO = 2;

            ////public static final int TYPE_HN_DBQH_CHUYEN_TRACH = 4;

            ///public static final int TYPE_KHAC = 5;

            ///public static final int TYPE_THUONG_VU = 3;

            Dictionary<long, string> mapping = new Dictionary<long, string>();
            mapping.Add(1, "QH");
            mapping.Add(2, "TO");
            mapping.Add(3, "TV");
            mapping.Add(4, "HN");
            mapping.Add(5, "KHAC");

            if (mapping.ContainsKey(bocbang_code) &&
                mapping[bocbang_code] == ggg_code)
            {
                return true;
            } else
            {
                return !mapping.ContainsKey(bocbang_code);
            }
        }
    }
}
