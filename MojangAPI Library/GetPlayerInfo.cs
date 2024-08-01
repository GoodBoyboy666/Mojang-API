using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MojangAPI_Library
{
    public class GetPlayerInfo
    {
        public enum Skin_or_Cape
        {
            Skin, Cape
        }

        /// <summary>
        /// 获取玩家UUID
        /// </summary>
        /// <param name="player_name">玩家名称</param>
        /// <param name="return_error">是否返回错误信息</param>
        /// <returns></returns>
        public static async Task<string?> GetUUID(string player_name, bool return_error)
        {
            string response_data = await HttpRequest.GetRequestString("https://api.mojang.com/users/profiles/minecraft/" + player_name);
            var obj_data = JsonConvert.DeserializeObject<JObject>(response_data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            if (return_error)
            {
                return obj_data?["id"]?.Value<string>() != null ? obj_data["id"]?.Value<string>() : obj_data?["errorMessage"]?.Value<string>() ?? "Failed to Get UUID";
            }
            else
            {
                return obj_data?["id"]?.Value<string>() ?? null;
            }
        }

        /// <summary>
        /// 获取玩家皮肤或披风
        /// </summary>
        /// <param name="uuid">玩家UUID</param>
        /// <param name="skin_or_cape">获取皮肤或披风</param>
        /// <param name="return_error">是否返回错误信息</param>
        /// <returns></returns>
        public static async Task<string?> GetSkin(string uuid, Skin_or_Cape skin_or_cape, bool return_error)
        {
            var obj_response = JsonConvert.DeserializeObject<JObject>(await HttpRequest.GetRequestString("https://sessionserver.mojang.com/session/minecraft/profile/" + uuid), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string value = obj_response?["properties"]?[0]?["value"]?.Value<string>() ?? "";
            if ((value == null || value == "") && return_error == true)
            {
                return obj_response?["errorMessage"]?.Value<string>() ?? "Failed to Get Skin";
            }
            else if ((value == null || value == "") && return_error == false)
            {
                return null;
            }

            string decode_value = "";
            byte[] bytes = Convert.FromBase64String(value ?? "");
            try
            {
                decode_value = Encoding.GetEncoding("utf-8").GetString(bytes);
            }
            catch (Exception)
            {

            }

            var textures = JsonConvert.DeserializeObject<JObject>(decode_value);

            if (skin_or_cape == Skin_or_Cape.Skin)
            {
                return textures?["textures"]?["SKIN"]?["url"]?.Value<string>() ?? "";
            }
            else if (skin_or_cape == Skin_or_Cape.Cape)
            {
                return textures?["textures"]?["CAPE"]?["url"]?.Value<string>() ?? "";
            }
            else
            {
                return "";
            }
        }
    }
}
