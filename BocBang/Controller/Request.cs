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

        public static bool RequestChangeSessionStatus(string sessionId, int isLive)
        {
            try
            {
                bool requestResult = false;
                // Create a request using a URL that can receive a post.
                string uri = string.Format("{0}/sessions/updateStatusByIdSession", AppsSettings.GetInstance().ApiUrl);
                Debug.WriteLine(String.Format("Send change system status {0} to {1}", isLive, uri));
                WebRequest request = GetWebRequester(uri, AppsSettings.GetInstance().UserInfo.Authorization);
                // Set the Method property of the request to POST.
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";

                // Create POST data and convert it to a byte array.
                string postData = String.Format("{{\"idSession\": {0}, \"status\": 1, \"isLive\": {1} }}", sessionId, isLive);
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
                    try
                    {
                        BackEndResponseMessage RspMsg = JsonConvert.DeserializeObject<BackEndResponseMessage>(responseFromServer);
                        if (RspMsg.status.Equals("1"))
                        {
                            requestResult = true;
                        }
                        else
                        {
                            requestResult = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                        requestResult = false;
                    }
                }

                // Close the response.
                response.Close();
                return requestResult;
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));
                return false;
            }

        }

        private static string CreateFormDataBoundary()
        {
            return "---------------------------" + DateTime.Now.Ticks.ToString("x");
        }
        public static bool RequestCreateParentAudio(string sessionId, string fileName)
        {
            try
            {
                bool requestResult = true;
                string FormDataTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n";
                // Create a request using a URL that can receive a post.
                string uri = string.Format("{0}/transcript/saveAudioTranslateOnline", AppsSettings.GetInstance().ApiUrl);
                WebRequest request = GetWebRequester(uri, AppsSettings.GetInstance().UserInfo.Authorization);
                // Set the Method property of the request to POST.
                string boundary = CreateFormDataBoundary();
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=" + boundary;

                // Create POST data and convert it to a byte array.
                string postData2 = String.Format("{{\"transcript\": {{}},\"idSession\": {0}, \"fileNameAudio\": \"{1}\",\"type\":\"0\",\"startTimeSplit\": 0}}", sessionId, fileName);

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.

                string item = String.Format(FormDataTemplate, boundary, "translateOnlineInfo", postData2);
                byte[] itemBytes = Encoding.UTF8.GetBytes(item);
                dataStream.Write(itemBytes, 0, itemBytes.Length);


                string HeaderTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n";
                string header = String.Format(HeaderTemplate, boundary, "file", fileName, "audio/wav");
                byte[] headerbytes = Encoding.UTF8.GetBytes(header);
                dataStream.Write(headerbytes, 0, headerbytes.Length);

                byte[] newlineBytes = Encoding.UTF8.GetBytes("\r\n");
                dataStream.Write(newlineBytes, 0, newlineBytes.Length);

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
                    try { 
                        BackEndResponseMessage RspMsg = JsonConvert.DeserializeObject<BackEndResponseMessage>(responseFromServer);
                        if (RspMsg.status.Equals("1"))
                        {
                            requestResult = true;
                        }
                        else
                        {
                            requestResult = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                        requestResult = false;
                    }
                }

                // Close the response.
                response.Close();

                return requestResult;
            } catch(Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));
                return false;
            }
            
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

        public static bool UploadFileToServer(string sessionId, string fileName, double startSplit)
        {
            try
            {
                bool requestResult = true;
                string FormDataTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n";
                // Create a request using a URL that can receive a post.
                string uri = string.Format("{0}/fileAudio/uploadFileToTranslate", AppsSettings.GetInstance().ApiUrl);
                WebRequest request = GetWebRequester(uri, AppsSettings.GetInstance().UserInfo.Authorization);
                // Set the Method property of the request to POST.
                string boundary = CreateFormDataBoundary();
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=" + boundary;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.

                string item = String.Format(FormDataTemplate, boundary, "idSession", sessionId);
                byte[] itemBytes = Encoding.UTF8.GetBytes(item);
                dataStream.Write(itemBytes, 0, itemBytes.Length);


                string HeaderTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n";
                string header = String.Format(HeaderTemplate, boundary, "files", Path.GetFileName(fileName), "audio/wav");
                byte[] headerbytes = Encoding.UTF8.GetBytes(header);
                dataStream.Write(headerbytes, 0, headerbytes.Length);

                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        dataStream.Write(buffer, 0, bytesRead);
                    }
                    fileStream.Close();
                }

                byte[] newlineBytes = Encoding.UTF8.GetBytes("\r\n");
                dataStream.Write(newlineBytes, 0, newlineBytes.Length);

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
                        BackEndResponseMessage RspMsg = JsonConvert.DeserializeObject<BackEndResponseMessage>(responseFromServer);
                        if (RspMsg.status.Equals("1"))
                        {
                            requestResult = true;
                        }
                        else
                        {
                            requestResult = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                        requestResult = false;
                    }
                }

                // Close the response.
                response.Close();

                return requestResult;
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));
                return false;
            }

        }


        public static bool CreateOfflineSession(string sessionId, string fileName)
        {
            try
            {
                bool requestResult = true;
                string FormDataTemplate = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n";
                // Create a request using a URL that can receive a post.
                string uri = string.Format("{0}/sessions/saveOfflineParrent", AppsSettings.GetInstance().ApiUrl);
                WebRequest request = GetWebRequester(uri, AppsSettings.GetInstance().UserInfo.Authorization);
                // Set the Method property of the request to POST.
                string boundary = CreateFormDataBoundary();
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=" + boundary;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.

                string item = String.Format(FormDataTemplate, boundary, "idSession", sessionId);
                byte[] itemBytes = Encoding.UTF8.GetBytes(item);
                dataStream.Write(itemBytes, 0, itemBytes.Length);

                item = String.Format(FormDataTemplate, boundary, "parentName", fileName);
                itemBytes = Encoding.UTF8.GetBytes(item);
                dataStream.Write(itemBytes, 0, itemBytes.Length);

                //byte[] newlineBytes = Encoding.UTF8.GetBytes("\r\n");
                //dataStream.Write(newlineBytes, 0, newlineBytes.Length);

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
                        BackEndResponseMessage RspMsg = JsonConvert.DeserializeObject<BackEndResponseMessage>(responseFromServer);
                        if (RspMsg.status.Equals("1"))
                        {
                            requestResult = true;
                        }
                        else
                        {
                            requestResult = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                        requestResult = false;
                    }
                }

                // Close the response.
                response.Close();

                return requestResult;
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("{0}", e));
                return false;
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
                string postData = "{{";// String.Format("{{\"idSession\": {0}, \"status\": 1, \"isLive\": {1} }}", sessionId, isLive);

                foreach (string key in parameter.Keys)
                {
                    string param = string.Format("\"{0}\": {1},", key, parameter[key]);
                    postData = postData + param;
                }
                //Remove last comma
                postData = postData.Substring(0, postData.Length - 1);
                postData = postData + "}}";

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
    
        
        public static List<SessionsEntity> getListSession()
        {
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            //meetingEntity
            listParameter.Add("meetingEntity", "");
            //activity
            listParameter.Add("activity", "");
            //meetingDay
            listParameter.Add("meetingDay", "");
            //page
            listParameter.Add("page", "1");
            //size
            listParameter.Add("size", "100");

            string result = SendGetRequest(AppsSettings.GetInstance().ApiUrl + "/sessions/findByUserPermit", listParameter);

            if (result.Equals(""))
            {
                return new List<SessionsEntity>();
            } else
            {
                try
                {
                    SessionMessage sessionMsg = JsonConvert.DeserializeObject<SessionMessage>(result);
                    return sessionMsg.data.listSession;
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
                    return sessionMsg.data;
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
                    return sessionMsg.data;
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
                    return sessionMsg.data;
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

            return !postResult.Equals("");
        }
    
        public static bool RequestMerge(long idAudioParent)
        {
            string url = AppsSettings.GetInstance().ApiUrl + "/reviewDocx/mergeFile";
            Dictionary<string, object> listParameter = new Dictionary<string, object>();
            listParameter.Add("idAudioParent", idAudioParent);

            string result = SendPostJsonApplicationTypeRequest(url, listParameter);

            return !result.Equals("");
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
                AudioParentMessage entity = JsonConvert.DeserializeObject<AudioParentMessage>(result);

                return entity.data;
            }
        }

        public static List<GGGActivityEntitity> GetGGGActivityEntitities()
        {
            string url = AppsSettings.GetInstance().ApiUrl + String.Format("/activity/list");
            Dictionary<string, object> listParameter = new Dictionary<string, object>();

            string result = Request.SendGetRequest(url, listParameter);

            if (result.Equals(""))
            {
                return null;
            }
            else
            {
                GGGActivitiesMessage message = JsonConvert.DeserializeObject<GGGActivitiesMessage>(result);

                return message.data;
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
                GGGLocationMessage message = JsonConvert.DeserializeObject<GGGLocationMessage>(result);

                return message.data;
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
                GGGUserGroupMessage message = JsonConvert.DeserializeObject<GGGUserGroupMessage>(result);

                return message.data;
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
    }
}