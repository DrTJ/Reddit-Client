using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RedditClient.Services
{
    public static class NetService
    {
        public static async Task<string> GetAsync(string url)
        {
            var response = await WebRequest.CreateHttp(url).GetResponseAsync();

            string result;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            var response = await WebRequest.CreateHttp(url).GetResponseAsync();

            string resultString;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                resultString = reader.ReadToEnd();
            }

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultString);
            return result;
        }

        public static async Task<T> PostAsync<T>(string url, string data)
        {
            var request = WebRequest.CreateHttp(url);
            request.ContentType = "application/json";
            request.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            Stream dataStream = await request.GetRequestStreamAsync();
            dataStream.Write(byteArray, 0, byteArray.Length);

            var response = await request.GetResponseAsync();

            string resultString;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                resultString = reader.ReadToEnd();
            }

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultString);
            return result;
        }
    }
}