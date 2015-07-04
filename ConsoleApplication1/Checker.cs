using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Net.NetworkInformation;
using System.Net;
using System.Configuration;


namespace ConsoleApplication1
{
    public class Checker : IChecker
    {
        private string host;

        public Checker()
        {
            host = System.Configuration.ConfigurationManager.AppSettings["host"];
        }
        
        public bool Check()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(host);

                HttpWebResponse respond = (HttpWebResponse)request.GetResponse();
                
                if (HttpStatusCode.OK == respond.StatusCode)
                {
                    // HTTP = 200
                    respond.Close();
                    return true;
                }
                else
                {
                    // !HttpStatusCode.OK
                    respond.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                // Error
                return false;
            }
        }
    }
}
