using System.IO;
using System.Net;

namespace JustEat.RecruitmentTest.App
{
    public class WebRequestManager : IWebRequestManager
    {
        public string GetJsonData(string code)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api-interview.just-eat.com/restaurants?q=" + code);
            request.Headers["Accept-Tenant"] = "uk";
            request.Headers["Accept-Language"] = "en-GB";
            request.Headers["Accept-Charset"] = "utf-8";
            request.Headers["Authorization"] = "Basic VGVjaFRlc3RBUEk6dXNlcjI=";
            request.Host = "api-interview.just-eat.com";
            var response = (HttpWebResponse)request.GetResponse();
            return GetJsonFromResponse(response);
            
        }

        private string GetJsonFromResponse(HttpWebResponse response)
        {
            var responseStream = new StreamReader(response.GetResponseStream());
            var jsonDataResult = responseStream.ReadToEnd();
            responseStream.Close();
            response.Close();
            return jsonDataResult;
        }
    }
}
