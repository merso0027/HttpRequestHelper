using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;

namespace HttpRequestHelper
{
    public static class HttpHelper
    {
        private static Uri baseAddress;

        public static void BaseApiAddress(string baseApi)
        {
            baseAddress = new Uri(baseApi);
        }

        /// <summary>
        /// Post http helper method
        /// </summary>
        /// <param name="url">Url to post API</param>
        /// <param name="contentValue">Post content as string</param>
        /// <param name="mediaType">Media type - default value is 'application/json'</param>
        public static async Task Post<T>(string url, T contentValue, string mediaType = MediaTypeNames.Application.Json)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                var content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, mediaType);
                var result = await client.PostAsync(url, content);
                result.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// put http helper method
        /// </summary>
        /// <param name="url">Url to put API</param>
        /// <param name="contentValue">Put content as string</param>
        /// <param name="mediaType">Media type - default value is 'application/json'</param>
        public static async Task Put<T>(string url, T stringValue, string mediaType = MediaTypeNames.Application.Json)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                var content = new StringContent(JsonConvert.SerializeObject(stringValue), Encoding.UTF8, mediaType);
                var result = await client.PutAsync(url, content);
                result.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Get http helper method
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="url">Get api url</param>
        /// <returns>Deserialized result from json in type T</returns>
        public static async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }

        /// <summary>
        /// Delete http helper method
        /// </summary>
        /// <param name="url">Url to delete api</param>
        public static async Task Delete(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseAddress;
                var result = await client.DeleteAsync(url);
                result.EnsureSuccessStatusCode();
            }
        }
    }
}

