using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MojangAPI_Library
{
    public class PlayerConfig
    {
        public enum PlayerProfile
        {
            id, name, skins, capes, all
        }

        public enum Check_Name
        {
            DUPLICATE, AVAILABLE, NOT_ALLOWED,ERROR
        }

        /// <summary>
        /// 获取玩家配置信息
        /// </summary>
        /// <param name="Minecraft_Access_Token">Minecraft Access Token</param>
        /// <param name="proflie">配置信息类型</param>
        /// <returns>string类型的玩家信息</returns>
        public static async Task<string> GetProfile(string Minecraft_Access_Token, PlayerProfile proflie)
        {
            string response = await HttpRequest.GetRequestString("https://api.minecraftservices.com/minecraft/profile", Minecraft_Access_Token);
            var data = JsonConvert.DeserializeObject<JObject>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            switch (proflie)
            {
                case PlayerProfile.id:
                    {
                        return data?["id"]?.Value<string>() ?? "";
                    }
                case PlayerProfile.name:
                    {
                        return data?["name"]?.Value<string>() ?? "";
                    }
                case PlayerProfile.skins:
                    {
                        return data?["skins"]?.Value<JArray>()?.ToString() ?? "";
                    }
                case PlayerProfile.capes:
                    {
                        return data?["capes"]?.Value<JArray>()?.ToString() ?? "";
                    }
                case PlayerProfile.all:
                    {
                        return response;
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// 获取玩家属性
        /// </summary>
        /// <param name="Minecraft_Access_Token">Minecraft Access Token</param>
        /// <returns>string类型的玩家属性</returns>
        public static async Task<string> GetAttributes(string Minecraft_Access_Token)
        {
            return await HttpRequest.GetRequestString("https://api.minecraftservices.com/player/attributes", Minecraft_Access_Token);
        }

        /// <summary>
        /// 检查名称可用性
        /// </summary>
        /// <param name="Minecraft_Access_Token">Minecraft Access Token</param>
        /// <param name="name">名称</param>
        /// <returns>可用性</returns>
        public static async Task<Check_Name> CheckName(string Minecraft_Access_Token, string name)
        {
            string json_response = await HttpRequest.GetRequestString("https://api.minecraftservices.com/minecraft/profile/name/" + name + "/available", Minecraft_Access_Token);
            var data = JsonConvert.DeserializeObject<JObject>(json_response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            switch(data?["status"]?.Value<string>()?? "ERROR")
            {
                case "DUPLICATE":
                    {
                        return Check_Name.DUPLICATE;
                    }
                case "AVAILABLE":
                    {
                        return Check_Name.AVAILABLE;
                    }
                case "NOT_ALLOWED":
                    {
                        return Check_Name.NOT_ALLOWED;
                    }
                default:
                    {
                        return Check_Name.ERROR;
                    }
            }
        }
    }
}
