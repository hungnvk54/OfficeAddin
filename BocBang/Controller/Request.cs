using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using BocBang.DataMessage;
using System.Diagnostics;
using BocBang.Common;
using System.Collections.Generic;

namespace BocBang
{
    /// <summary>
    /// Create Http Request, using json, and read Http Response.
    /// </summary>

    public class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint,
          X509Certificate certificate, WebRequest request,
          int certificateProblem)
        {
            //Return True to force the certificate to be accepted.
            return true;
        }
    }

    public class Request
    {
        public static WebRequest GetWebRequester(string url, string token = "")
        {
            Utils.ConnectionType type = Utils.ParsingConnectionType(url);
            if (type == Utils.ConnectionType.Unknown)
            {
                return null;
            }

            WebRequest request = WebRequest.Create(url);
            if (!token.Equals(""))
            {
                request.Headers.Add("Authorization", token);
            }

            if (type == Utils.ConnectionType.SSLProtocol)
            {
                ServicePointManager.CertificatePolicy = new MyPolicy();
            }

            return request;
        }


        private static string CreateFormDataBoundary()
        {
            return "---------------------------" + DateTime.Now.Ticks.ToString("x");
        }

        public static UserInfoMessage RequestLogin(string username, string password)
        {
            try
            {
                // Create a request using a URL that can receive a post.
                string uri = string.Format("{0}/login", AppsSettings.GetInstance().ApiUrl);
                WebRequest request = GetWebRequester(uri, "");
                // Set the Method property of the request to POST.
                string boundary = CreateFormDataBoundary();
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=" + boundary;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                string FormDataTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n";

                string item = String.Format(FormDataTemplate, boundary, "username", username);
                byte[] itemBytes = Encoding.UTF8.GetBytes(item);
                dataStream.Write(itemBytes, 0, itemBytes.Length);

                item = String.Format(FormDataTemplate, boundary, "password", password);
                itemBytes = Encoding.UTF8.GetBytes(item);
                dataStream.Write(itemBytes, 0, itemBytes.Length);

                byte[] endBytes = Encoding.UTF8.GetBytes("--" + boundary + "--");
                dataStream.Write(endBytes, 0, endBytes.Length);
                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Debug.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Debug.WriteLine(responseFromServer);
                    try
                    {
                        UserInfoMessage RspMsg = JsonConvert.DeserializeObject<UserInfoMessage>(responseFromServer);
                        return RspMsg;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }

                // Close the response.
                response.Close();

                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));
                return null;
            }

        }
    
        public static string SendPostJsonApplicationTypeRequest(string uri, Dictionary<string, Object> parameter)
        {
            try
            {
                // Create a request using a URL that can receive a post.
                WebRequest request = GetWebRequester(uri, AppsSettings.GetInstance().UserInfo.Authorization);
                // Set the Method property of the request to POST.
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";

                // Create POST data and convert it to a byte array.
                string postData = "{";// String.Format("{{\"idSession\": {0}, \"status\": 1, \"isLive\": {1} }}", sessionId, isLive);

                foreach (string key in parameter.Keys)
                {
                    string param = string.Format("\"{0}\": {1},", key, parameter[key]);
                    postData = postData + param;
                }
                //Remove last comma
                postData = postData.Substring(0, postData.Length - 1);
                postData = postData + "}";

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Debug.WriteLine(responseFromServer);
                    response.Close();
                    return responseFromServer;
                }
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));
                
            }
            return "";
        }


        public static string SendPostJsonApplicationTypeRequest(string uri, string postData)
        {
            try
            {
                // Create a request using a URL that can receive a post.
                WebRequest request = GetWebRequester(uri, AppsSettings.GetInstance().UserInfo.Authorization);
                // Set the Method property of the request to POST.
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Debug.WriteLine(responseFromServer);
                    response.Close();
                    return responseFromServer;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));

            }
            return "";
        }
        public static string SendGetRequest(string uri, Dictionary<string, Object> parameter)
        {
            try
            {
                if (parameter.Keys.Count > 0) 
                { 
                    uri = uri + "?";
                }
                foreach (string key in parameter.Keys)
                {
                    string param = string.Format("{0}={1}&", key, parameter[key]);
                    uri = uri + param;
                }
                if (parameter.Keys.Count > 0)
                {
                    uri = uri.Substring(0, uri.Length - 1);
                }
                byte[] byteArray = new byte[0];

                // Create a request using a URL that can receive a post.
                WebRequest request = GetWebRequester(uri, AppsSettings.GetInstance().UserInfo.Authorization);
                // Set the Method property of the request to POST.
                request.Method = "GET";
                // Get the response.

                using (WebResponse response = request.GetResponse())
                {
                    // Display the status.
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                    // Get the stream containing content returned by the server.
                    // The using block ensures the stream is automatically closed.
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.
                        Debug.WriteLine(responseFromServer);
                        response.Close();
                        return responseFromServer;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));
            }
            return "";
        }

        public static string SendDeleteRequest(string uri, Dictionary<string, Object> parameter)
        {
            try
            {
                if (parameter.Keys.Count > 0)
                {
                    uri = uri + "?";
                }
                foreach (string key in parameter.Keys)
                {
                    string param = string.Format("{0}={1}&", key, parameter[key]);
                    uri = uri + param;
                }
                if (parameter.Keys.Count > 0)
                {
                    uri = uri.Substring(0, uri.Length - 1);
                }
                byte[] byteArray = new byte[0];

                // Create a request using a URL that can receive a post.
                WebRequest request = GetWebRequester(uri, AppsSettings.GetInstance().UserInfo.Authorization);
                // Set the Method property of the request to POST.
                request.Method = "DELETE";
                // Get the response.

                using (WebResponse response = request.GetResponse())
                {
                    // Display the status.
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                    // Get the stream containing content returned by the server.
                    // The using block ensures the stream is automatically closed.
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.
                        Debug.WriteLine(responseFromServer);
                        response.Close();
                        return responseFromServer;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));
            }
            return "";
        }


        public static List<SessionsEntity> getListSession(long numberRecords, string ky, string khoa, string hoatDong, string meetingDate)
        {
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            //meetingEntity
            listParameter.Add("meetingEntity", "");
            //activity
            listParameter.Add("activity", hoatDong);
            //meetingDay
            listParameter.Add("meetingDay", meetingDate);
            //Khoa
            listParameter.Add("nationalAssembly", khoa);
            //Khoa
            listParameter.Add("meeting", ky);
            //page
            listParameter.Add("page", "1");
            //size
            listParameter.Add("size", String.Format("{0}",numberRecords));

            string result = SendGetRequest(AppsSettings.GetInstance().ApiUrl + "/sessions/findByUserPermit", listParameter);

            if (result.Equals(""))
            {
                return new List<SessionsEntity>();
            } else
            {
                try
                {
                    SessionMessage sessionMsg = JsonConvert.DeserializeObject<SessionMessage>(result);
                    if (sessionMsg != null && sessionMsg.data != null)
                    {
                        return sessionMsg.data.listSession;
                    }
                    else
                    {
                        return new List<SessionsEntity>();
                    }
                } catch (Exception e){
                    Debug.WriteLine(e);
                    return new List<SessionsEntity>();
                }
            }
        }


        public static List<RepresentativeEntity> getListRepresentative(long term)
        {
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string result = SendGetRequest(AppsSettings.GetInstance().ApiUrl + String.Format("/representative/national-assembly/{0}", term), listParameter);

            if (result.Equals(""))
            {
                return new List<RepresentativeEntity>();
            }
            else
            {
                try
                {
                    RepresentativeMessage sessionMsg = JsonConvert.DeserializeObject<RepresentativeMessage>(result);
                    if (sessionMsg != null)
                    {
                        return sessionMsg.data;
                    }
                    else
                    {
                        return new List<RepresentativeEntity>();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return new List<RepresentativeEntity>();
                }
            }
        }

        public static List<AudioEntity> getListAudio(long sessionId)
        {
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string result = SendGetRequest(AppsSettings.GetInstance().ApiUrl + String.Format("/fileAudio/findAudioByIdSession/{0}", sessionId), listParameter);

            if (result.Equals(""))
            {
                return new List<AudioEntity>();
            }
            else
            {
                try
                {
                    AudioMessages sessionMsg = JsonConvert.DeserializeObject<AudioMessages>(result);
                    if (sessionMsg != null)
                    {
                        return sessionMsg.data;
                    }
                    else
                    {
                        return new List<AudioEntity>();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return new List<AudioEntity>();
                }
            }
        }
    
        public static DocumentEntity getMergedDocument(long sessionId)
        {
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string result = SendGetRequest(AppsSettings.GetInstance().ApiUrl + String.Format("/reviewDocx/getMergedFile/{0}", sessionId), listParameter);

            if (result.Equals(""))
            {
                return new DocumentEntity();
            }
            else
            {
                try
                {
                    DocumentMessage sessionMsg = JsonConvert.DeserializeObject<DocumentMessage>(result);
                    if (sessionMsg != null)
                    {
                        return sessionMsg.data;
                    }
                    else
                    {
                        return new DocumentEntity();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return new DocumentEntity();
                }
            }
        }

        public static bool SaveDocument(DocumentEntity documentEntity)
        {
            string postData = JsonConvert.SerializeObject(documentEntity);
            string postResult = SendPostJsonApplicationTypeRequest(
                AppsSettings.GetInstance().ApiUrl + "/reviewDocx/saveMergedFile",
                postData);
            try
            {
                BaseMessage message = JsonConvert.DeserializeObject<BaseMessage>(postResult);
                if (message != null && message.status == Constants.RESPONSE_STATUS_SUCCESS)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
    
        public static bool RequestMerge(long idAudioParent)
        {
            string url = AppsSettings.GetInstance().ApiUrl + "/reviewDocx/mergeFile";
            Dictionary<string, object> listParameter = new Dictionary<string, object>();
            listParameter.Add("idAudioParent", idAudioParent);

            string result = SendPostJsonApplicationTypeRequest(url, listParameter);

            try
            {
                BaseMessage message = JsonConvert.DeserializeObject<BaseMessage>(result);
                if (message != null && message.status == Constants.RESPONSE_STATUS_SUCCESS)
                {
                    return true;
                }
            } catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public static DocumentEntity RequestMergeAndGetResult(long idAudioParent)
        {
            string url = AppsSettings.GetInstance().ApiUrl + "/reviewDocx/mergeFileEndGetResult";
            Dictionary<string, object> listParameter = new Dictionary<string, object>();
            listParameter.Add("idAudioParent", idAudioParent);

            string result = SendPostJsonApplicationTypeRequest(url, listParameter);

            try
            {
                DocumentMessage message = JsonConvert.DeserializeObject<DocumentMessage>(result);
                if (message != null && message.status == Constants.RESPONSE_STATUS_SUCCESS)
                {
                    return message.data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public static AudioEntity GetParentAudioByIdSession(long sessionId)
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/fileAudio/findAudioParrentByIdSession/{0}", sessionId);
            Dictionary<string, object> listParameter = new Dictionary<string, object>();
            string result = Request.SendGetRequest(url, listParameter);

            if (result.Equals(""))
            {
                return null;
            } else
            {
                try
                {
                    AudioParentMessage entity = JsonConvert.DeserializeObject<AudioParentMessage>(result);
                    if (entity != null )
                    {
                        return entity.data;
                    }
                    else
                    {
                        return null;
                    }
                } catch (Exception e)
                {
                    return null;
                }
                
            }
        }

        public static List<GGGActivityEntitity> GetGGGActivityEntitities()
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/activity/list");
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string result = Request.SendGetRequest(url, listParameter);

            if (result.Equals(""))
            {
                return new List<GGGActivityEntitity>();
            }
            else
            {
                try
                {
                    GGGActivitiesMessage message = JsonConvert.DeserializeObject<GGGActivitiesMessage>(result);

                    if (message != null)
                    {
                        return message.data;
                    }
                    else
                    {
                        return null;
                    }
                } catch (Exception)
                {
                    return null;
                }
                
            }
        }

        public static List<GGGLocationEntity> GetGGGLocationEntitities()
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/location/list");
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string result = Request.SendGetRequest(url, listParameter);

            if (result.Equals(""))
            {
                return null;
            }
            else
            {
                try
                {
                    GGGLocationMessage message = JsonConvert.DeserializeObject<GGGLocationMessage>(result);
                    if (message != null)
                    {
                        return message.data;
                    }
                    else
                    {
                        return null;
                    }
                } catch (Exception e)
                {
                    return null;
                }
                
            }
        }

        public static List<GGGUserGroupEntity> GetGGGUserGroupEntities()
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/role/list");
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string result = Request.SendGetRequest(url, listParameter);

            if (result.Equals(""))
            {
                return null;
            }
            else
            {
                try
                {
                    GGGUserGroupMessage message = JsonConvert.DeserializeObject<GGGUserGroupMessage>(result);
                    if (message != null)
                    {
                        return message.data;
                    }
                    else
                    {
                        return null;
                    }
                } catch (Exception e)
                {
                    return null;
                }
                
            }
        }
    
        public static bool ExportSessionToGGGSystem(GGGExportEntity gGGExportEntity)
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/sessions/exportToRemoteServer");
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string postData = JsonConvert.SerializeObject(gGGExportEntity);
            string postResult = SendPostJsonApplicationTypeRequest( url, postData);

            try
            {
                BaseMessage message = JsonConvert.DeserializeObject<BaseMessage>(postResult);
                if ( message != null && message.status == Constants.RESPONSE_STATUS_SUCCESS)
                {
                    return true;
                }
            } catch (Exception e)
            {
                return false;
            }
            return false;
        }


        public static bool RemoteGGGSession(long sessionId)
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/sessions/deteleSessionFromRemoteServer/{0}", sessionId);
            Dictionary<string, object> listParameter = new Dictionary<string, object>();
            string postResult = SendDeleteRequest(url,listParameter);
            try
            {
                BaseMessage message = JsonConvert.DeserializeObject<BaseMessage>(postResult);
                if (message != null && message.status == Constants.RESPONSE_STATUS_SUCCESS)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
    
        public static bool RequestSplitRepresentative(long sessionId)
        {
            AudioEntity audioEntity = GetParentAudioByIdSession(sessionId);
            if (audioEntity == null)
            {
                return false;
            }

            RequestSplitRepresentativeParam requestSplitRepresentativeParam = new RequestSplitRepresentativeParam();
            requestSplitRepresentativeParam.idAudio = audioEntity.idAudio;

            try
            {
                string postData = JsonConvert.SerializeObject(requestSplitRepresentativeParam);
                string postResult = SendPostJsonApplicationTypeRequest(
               AppsSettings.GetInstance().ApiUrl + "/representativeSplit/loadSplitRepresentative",
               postData);
                BaseMessage message = JsonConvert.DeserializeObject<BaseMessage>(postResult);
                if (message != null && message.status == Constants.RESPONSE_STATUS_SUCCESS)
                {
                    return true;
                }
                
            }catch (Exception e)
            {
                return false;
            }
            return false;
        }


        public static bool ResetMergeDocument(long sessionId)
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/reviewDocx/resetMergeFile/{0}", sessionId);
            Dictionary<string, object> listParameter = new Dictionary<string, object>();
            string postResult = SendGetRequest(url, listParameter);
            try
            {
                BaseMessage message = JsonConvert.DeserializeObject<BaseMessage>(postResult);
                if (message != null && message.status == Constants.RESPONSE_STATUS_SUCCESS)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }


        public static List<ActivityEntity> ActivityEntitities()
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/activity/all");
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string result = Request.SendGetRequest(url, listParameter);

            if (result.Equals(""))
            {
                return new List<ActivityEntity>();
            }
            else
            {
                try
                {
                    ActivityEntityMessage message = JsonConvert.DeserializeObject<ActivityEntityMessage>(result);

                    if (message != null)
                    {
                        return message.data;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}