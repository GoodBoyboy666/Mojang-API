using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MojangAPI_Library
{
    public class HttpRequest
    {
        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <returns>HttpResponseMessage对象</returns>
        public static async Task<HttpResponseMessage> GetRequest(string url)
        {
            using HttpClient client = new HttpClient();
            return await client.GetAsync(url);
        }

        /// <summary>
        /// 发送包含Authentication的请求
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="Bearer">Minecraft Access Token</param>
        /// <returns>HttpResponseMessage对象</returns>
        public static async Task<HttpResponseMessage> GetRequest(string url, string Bearer)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Bearer);
            HttpResponseMessage response = await client.GetAsync(url);
            client.Dispose();
            return response;
        }

        /// <summary>
        /// 发送Get请求并返回String对象
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <returns>String对象</returns>
        public static async Task<string> GetRequestString(string url)
        {
            HttpResponseMessage response = await GetRequest(url);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 发送包含Authentication的请求并返回String对象
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="Bearer">Minecraft Access Token</param>
        /// <returns>String对象</returns>
        public static async Task<string> GetRequestString(string url, string Bearer)
        {
            HttpResponseMessage response = await GetRequest(url, Bearer);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="content">Http内容</param>
        /// <returns>HttpResponseMessage对象</returns>
        public static async Task<HttpResponseMessage> PostRequest(string url, HttpContent content)
        {
            using HttpClient client = new HttpClient();
            return await client.PostAsync(url, content);
        }

        /// <summary>
        /// 发送Post请求并返回String对象
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="content"></param>
        /// <returns>String对象</returns>
        public static async Task<string> PostRequestString(string url, HttpContent content)
        {
            HttpResponseMessage response = await PostRequest(url, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
