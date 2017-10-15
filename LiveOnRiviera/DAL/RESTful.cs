using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace LiveOnRiviera.DAL
{
    public enum httpverb
    {

        GET,
        POST,
        PUT,
        DELETE
    }

    class REST
    {
        public string endpoint { get; set; }
        public httpverb httpMethod { get; set; }

        public REST()
        {
            endpoint = string.Empty;
            httpMethod = httpverb.GET;


        }

        public string makerequest()
        {
            string strResponseValue = string.Empty;
            //requests data from url 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);
            request.Method = httpMethod.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("The Error Code :" + response.StatusCode.ToString());
                }


                using (Stream responsestream = response.GetResponseStream())
                {
                    if (responsestream != null)
                    {
                        using (StreamReader Reader = new StreamReader(responsestream))
                        {
                            strResponseValue = Reader.ReadToEnd();
                        }
                    }

                }

            }

            return strResponseValue;
        }
    }
}