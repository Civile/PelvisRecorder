using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TXRXText
{
    class CaptainHook
    {

        private WebRequest _Request;
        private Stream     _DataStream;
        private String     _Status;
        public static ManualResetEvent _AllDone = new ManualResetEvent(false);

        /// <summary>
        /// Constructor
        /// </summary>
        public CaptainHook()
        {

        }


        public String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }


        public void HookRequest(string Url) 
        {
            if(Url == String.Empty)
                return;

            // Create a request using a URL that can receive a post.
            _Request = WebRequest.Create(Url);
        }


        public void HookRequest(string Url, string Method)
        {
            _Request = WebRequest.Create(Url);

            if (Method.Equals("GET") || Method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                _Request.Method = Method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
                
        }


        public void HookRequest(string Url, string Method, string Data)
        {
            HookRequest(Url, Method);

            string postData = Data;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            _Request.ContentType = "application/x-www-form-urlencoded";

            // Set the ContentLength property of the WebRequest.
            _Request.ContentLength = byteArray.Length;

            // Get the request stream.
            _DataStream = _Request.GetRequestStream();

            // Write the data to the request stream.
            _DataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            _DataStream.Close();
 

        }


        public string HookResponse()
        {
            try
            {

                using (WebResponse response = _Request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        this.Status = ((HttpWebResponse)response).StatusDescription;

                        // Get the stream containing all content returned by the requested server.
                        _DataStream = response.GetResponseStream();

                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(_DataStream);

                        // Read the content fully up to the end.
                        try
                        {
                            string responseFromServer = reader.ReadToEnd();
                            // Clean up the streams.
                            reader.Close();
                            _DataStream.Close();
                            response.Close();

                            return responseFromServer;
                        }
                        catch(System.IO.IOException e)
                        {
                            return String.Empty;
                        }

                        
                    }
                    else
                    {
                        return String.Empty;
                    }
                }


            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            //BAD REQUEST
                            return String.Empty;
                        }
                    }
                }
                else
                {
                    return String.Empty;
                }
            }


        }

    }




    public class RequestState
    {
        const int BufferSize = 1024;
        public StringBuilder RequestData;
        public byte[] BufferRead;
        public WebRequest Request;
        public Stream ResponseStream;
        // Create Decoder for appropriate enconding type.
        public Decoder StreamDecode = Encoding.UTF8.GetDecoder();

        public RequestState()
        {
            BufferRead = new byte[BufferSize];
            RequestData = new StringBuilder(String.Empty);
            Request = null;
            ResponseStream = null;
        }
    }




}
