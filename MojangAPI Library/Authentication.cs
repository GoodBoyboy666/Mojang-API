using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using MojangAPI_Library;

namespace MojangAPI
{
    public class Authentication
    {
        /// <summary>
        /// 获取授权链接
        /// </summary>
        /// <param name="Client_ID">客户端ID</param>
        /// <returns>授权链接地址</returns>
        public static string Get_Microsoft_Auth_Code_URL(string Client_ID = "00000000402b5328")
        {
            return "https://login.microsoftonline.com/consumers/oauth2/v2.0/authorize?client_id=" + Client_ID + "&response_type=code&redirect_uri=https:%2F%2Flogin.live.com%2Foauth20_desktop.srf&response_mode=query&scope=service%3A%3Auser.auth.xboxlive.com%3A%3AMBI_SSL";
        }

        /// <summary>
        /// 获取Microsoft_Access_Token
        /// </summary>
        /// <param name="Microsoft_Auth_Code">Microsoft授权代码</param>
        /// <returns>Microsoft_Access_Token</returns>
        /// <exception cref="Exception">获取Microsoft_Access_Token失败</exception>
        public static async Task<string> Get_Microsoft_Access_Token(string Microsoft_Auth_Code)
        {
            string Microsoft_Access_Token_json_data = await HttpRequest.PostRequestString("https://login.live.com/oauth20_token.srf", new StringContent(String.Format("client_id=00000000402b5328&code={0}&grant_type=authorization_code&redirect_uri=https%3A%2F%2Flogin.live.com%2Foauth20_desktop.srf&scope=service%3A%3Auser.auth.xboxlive.com%3A%3AMBI_SSL", Microsoft_Auth_Code), Encoding.UTF8, "application/x-www-form-urlencoded"));
            var Microsoft_Access_Token_data = JsonConvert.DeserializeObject<JObject>(Microsoft_Access_Token_json_data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string Microsoft_Access_Token = Microsoft_Access_Token_data?["access_token"]?.Value<string>() ?? "";
            if (Microsoft_Access_Token == "")
            {
                throw new Exception("Can not get Microsoft_Access_Token");
            }
            return Microsoft_Access_Token;
        }

        /// <summary>
        /// 获取Xbox Live令牌
        /// </summary>
        /// <param name="Microsoft_Access_Token">Microsoft_Access_Token</param>
        /// <returns>Xbox Live令牌</returns>
        /// <exception cref="Exception">获取Xbox Live令牌失败</exception>
        public static async Task<string> Get_Xbox_Live_Token(string Microsoft_Access_Token)
        {
            JObject Root = new JObject();
            JObject Properties = new JObject();
            Properties["AuthMethod"] = "RPS";
            Properties["SiteName"] = "user.auth.xboxlive.com";
            Properties["RpsTicket"] = Microsoft_Access_Token;
            Root["Properties"] = Properties;
            Root["RelyingParty"] = "http://auth.xboxlive.com";
            Root["TokenType"] = "JWT";

            string json_data = await HttpRequest.PostRequestString("https://user.auth.xboxlive.com/user/authenticate", new StringContent(Root.ToString(), Encoding.UTF8, "application/json"));
            var data = JsonConvert.DeserializeObject<JObject>(json_data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string Xbox_Live_Token = data?["Token"]?.Value<string>() ?? "";
            if (Xbox_Live_Token == "")
            {
                throw new Exception("Can not get Xbox_Live_Token!");
            }
            return Xbox_Live_Token;
        }

        /// <summary>
        /// 获取XSTS令牌
        /// </summary>
        /// <param name="Xbox_Live_Token">Xbox Live令牌</param>
        /// <returns>XSTS令牌</returns>
        /// <exception cref="Exception">获取XSTS令牌失败</exception>
        public static async Task<List<string>> Get_XSTS_Token(string Xbox_Live_Token)
        {
            JObject XSTS_Root = new JObject();
            JObject XSTS_Properties = new JObject();
            JArray XSTS_UserTokens = new JArray();
            XSTS_Properties["SandboxId"] = "RETAIL";
            XSTS_UserTokens.Add(Xbox_Live_Token);
            XSTS_Properties["UserTokens"] = XSTS_UserTokens;
            XSTS_Root["Properties"] = XSTS_Properties;
            XSTS_Root["RelyingParty"] = "rp://api.minecraftservices.com/";
            XSTS_Root["TokenType"] = "JWT";
            string XSTS_json_data = await HttpRequest.PostRequestString("https://xsts.auth.xboxlive.com/xsts/authorize", new StringContent(XSTS_Root.ToString(), Encoding.UTF8, "application/json"));
            var XSTS_data = JsonConvert.DeserializeObject<JObject>(XSTS_json_data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string XSTS_Token = XSTS_data?["Token"]?.Value<string>() ?? "";
            string User_Hash = XSTS_data?["DisplayClaims"]?["xui"]?[0]?["uhs"]?.Value<string>() ?? "";
            if (XSTS_Token == "")
            {
                throw new Exception("Can not get XSTS_Token!");
            }
            if (User_Hash == "")
            {
                throw new Exception("Can not get user hash!");
            }
            List<string> list = new List<string>();
            list.Add(XSTS_Token);
            list.Add(User_Hash);
            return list;
        }

        /// <summary>
        /// 获取Minecraft访问令牌
        /// </summary>
        /// <param name="XSTS_Token">XSTS令牌</param>
        /// <returns>Minecraft访问令牌</returns>
        /// <exception cref="Exception">获取Minecraft访问令牌失败</exception>
        public static async Task<string> Get_Minecraft_Access_Token(string XSTS_Token, string User_Hash)
        {
            JObject Minecraft_Root = new JObject();
            Minecraft_Root["identityToken"] = String.Format("XBL3.0 x={0};{1}", User_Hash, XSTS_Token);
            string Minecraft_json_data = await HttpRequest.PostRequestString("https://api.minecraftservices.com/authentication/login_with_xbox", new StringContent(Minecraft_Root.ToString(), Encoding.UTF8, "application/json"));
            var Minecraft_data = JsonConvert.DeserializeObject<JObject>(Minecraft_json_data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string Access_Token = Minecraft_data?["access_token"]?.Value<string>() ?? "";
            if (Access_Token == "")
            {
                throw new Exception("Can not get Access_Token!");
            }
            return Access_Token;
        }

        /// <summary>
        /// 是否拥有Minecraft
        /// </summary>
        /// <param name="Access_Token">Access_Token</param>
        /// <returns>布尔值</returns>
        public static async Task<bool> Is_Own_Minecraft(string Access_Token)
        {
            string json_response = await HttpRequest.GetRequestString("https://api.minecraftservices.com/entitlements/mcstore", Access_Token);
            var data_response = JsonConvert.DeserializeObject<JObject>(json_response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string signature = data_response?["signature"]?.Value<string>() ?? "";
            if (json_response == "" || signature == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
