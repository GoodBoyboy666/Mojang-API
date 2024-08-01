using Microsoft.Win32;
using MojangAPI_Library;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Web;
using static MojangAPI_Library.GetPlayerInfo;
using static MojangAPI_Library.PlayerConfig;
namespace MojangAPI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn_GetUUID_Click(object sender, EventArgs e)
        {
            if(textBox_Player_Name.Text=="")
            {
                MessageBox.Show("������Ʋ���Ϊ�գ�");
            }
            else
            {
                textBox_UUID.Text = await GetPlayerInfo.GetUUID(textBox_Player_Name.Text, true);
            }
        }

        private async void GetSkinAndCape_Click(object sender, EventArgs e)
        {
            if(textBox_UUID.Text=="")
            {
                MessageBox.Show("���Ȼ�ȡUUID��");
            }
            else
            {
                textBox_Skin_Url.Text = await GetPlayerInfo.GetSkin(textBox_UUID.Text, Skin_or_Cape.Skin, true);
                textBox_Cape_Url.Text = await GetPlayerInfo.GetSkin(textBox_UUID.Text, Skin_or_Cape.Cape, true);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_WebSite.Text == "")
            {
                MessageBox.Show("���ȷ�����Ȩ��");
            }
            else
            {
                textBox_Microsoft_authorization_code.Text = textBox_WebSite.Text.Split('?')[1].Split('&')[0].Split('=')[1];
            }
        }

        private async void button_Get_Access_Token_Click(object sender, EventArgs e)
        {
            if (textBox_Microsoft_authorization_code.Text == "")
            {
                MessageBox.Show("���Ȼ�ȡMicrosoft��Ȩ���룡");
            }
            else
            {
                textBox_Microsoft_Access_Token.Text = await Authentication.Get_Microsoft_Access_Token(textBox_Microsoft_authorization_code.Text);
                textBox_Xbox_Live_Token.Text = await Authentication.Get_Xbox_Live_Token(textBox_Microsoft_Access_Token.Text);
                List<string> list = await Authentication.Get_XSTS_Token(textBox_Xbox_Live_Token.Text);
                textBox_XSTS_Token.Text = list[0];
                string user_hash = list[1];
                textBox_Accees_Token.Text = await Authentication.Get_Minecraft_Access_Token(textBox_XSTS_Token.Text, user_hash);
            }
        }

        private void button_Initiate_authorization_Click(object sender, EventArgs e)
        {
            string url = Authentication.Get_Microsoft_Auth_Code_URL(textBox_Microsoft_Client_ID.Text);
            string s = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\")?.GetValue("")?.ToString() ?? "";
            if (s == "")
            {
                MessageBox.Show("��Ĭ�������ʧ�ܣ����ֶ�ճ���������ַ���������");
                Clipboard.SetText(url);
            }
            else
            {
                Process.Start(s, url);
            }
        }

        private async void button_Get_Player_Info_Click(object sender, EventArgs e)
        {
            if (textBox_Accees_Token.Text == "")
            {
                MessageBox.Show("���Ȼ�ȡAccess_Token��");
            }
            else
            {
                //����Ƿ�ӵ��Minecraft
                bool Own_Minecraft = await Authentication.Is_Own_Minecraft(textBox_Accees_Token.Text);
                if (Own_Minecraft)
                {
                    textBox_Own_Minecraft.Text = "��";
                }
                else
                {
                    textBox_Own_Minecraft.Text = "��";
                }

                //��ȡƤ��������
                string json_skins = await PlayerConfig.GetProfile(textBox_Accees_Token.Text, PlayerConfig.PlayerProfile.skins);
                string json_capes = await PlayerConfig.GetProfile(textBox_Accees_Token.Text, PlayerConfig.PlayerProfile.capes);
                var skins = JsonConvert.DeserializeObject<JArray>(json_skins, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var capes = JsonConvert.DeserializeObject<JArray>(json_capes, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                for (int i = 0; i < (skins?.Count ?? 0); i++)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    ListViewItem.ListViewSubItem state = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem url = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem variant = new ListViewItem.ListViewSubItem();
                    listViewItem.Name = "id";
                    listViewItem.Text = skins?[i]?["id"]?.Value<string>() ?? "";
                    state.Name = "state";
                    state.Text = skins?[i]?["state"]?.Value<string>() ?? "";
                    url.Name = "url";
                    url.Text = skins?[i]?["url"]?.Value<string>() ?? "";
                    variant.Name = "variant";
                    variant.Text = skins?[i]?["variant"]?.Value<string>() ?? "";
                    listViewItem.SubItems.Add(state);
                    listViewItem.SubItems.Add(url);
                    listViewItem.SubItems.Add(variant);
                    listViewItem.Group = listView_Skin_Cape.Groups["Skins"];
                    listView_Skin_Cape.Items.Add(listViewItem);
                }

                for (int i = 0; i < (capes?.Count ?? 0); i++)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    ListViewItem.ListViewSubItem state = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem url = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem alias = new ListViewItem.ListViewSubItem();
                    listViewItem.Name = "id";
                    listViewItem.Text = capes?[i]?["id"]?.Value<string>() ?? "";
                    state.Name = "state";
                    state.Text = capes?[i]?["state"]?.Value<string>() ?? "";
                    url.Name = "url";
                    url.Text = capes?[i]?["url"]?.Value<string>() ?? "";
                    alias.Name = "alias";
                    alias.Text = capes?[i]?["alias"]?.Value<string>() ?? "";
                    listViewItem.SubItems.Add(state);
                    listViewItem.SubItems.Add(url);
                    listViewItem.SubItems.Add(alias);
                    listViewItem.Group = listView_Skin_Cape.Groups["Capes"];
                    listView_Skin_Cape.Items.Add(listViewItem);
                }

                //��ȡ�������
                richTextBox_Player_Attributes.Text += "������ԣ�\n";
                string json_player_attributes = await PlayerConfig.GetAttributes(textBox_Accees_Token.Text);
                var data_player_attributes = JsonConvert.DeserializeObject<JObject>(json_player_attributes, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                richTextBox_Player_Attributes.Text += "����������Ϣ��" + data_player_attributes?["privileges"]?["onlineChat"]?["enabled"]?.Value<string>() ?? "";
                richTextBox_Player_Attributes.Text += "\r\n������˷�������" + data_player_attributes?["privileges"]?["multiplayerServer"]?["enabled"]?.Value<string>() ?? "";
                richTextBox_Player_Attributes.Text += "\r\n����Realms��" + data_player_attributes?["privileges"]?["multiplayerRealms"]?["enabled"]?.Value<string>() ?? "";
                richTextBox_Player_Attributes.Text += "\r\n����ң�����ݣ�" + data_player_attributes?["privileges"]?["telemetry"]?["enabled"]?.Value<string>() ?? "";
                richTextBox_Player_Attributes.Text += "\r\n��ѡң�����ݣ�" + data_player_attributes?["privileges"]?["optionalTelemetry"]?["enabled"]?.Value<string>() ?? "";
                richTextBox_Player_Attributes.Text += "\r\nRealms�������ѡ�" + data_player_attributes?["profanityFilterPreferences"]?["profanityFilterOn"]?.Value<string>() ?? "";

                string banId = data_player_attributes?["banStatus"]?["bannedScopes"]?["banId"]?.Value<string>() ?? "";
                if (banId == "")
                {
                    richTextBox_Player_Attributes.Text += "\r\n���״̬��false";
                }
                else
                {
                    richTextBox_Player_Attributes.Text += "\r\n���UUID��" + banId;
                    string expires = data_player_attributes?["banStatus"]?["bannedScopes"]?["expires"]?.Value<string>() ?? "";
                    if (expires == "")
                    {
                        richTextBox_Player_Attributes.Text += "\r\n�������ʱ�䣺������";
                    }
                    else
                    {
                        richTextBox_Player_Attributes.Text += "\r\n�������ʱ�䣺" + expires;
                    }

                    richTextBox_Player_Attributes.Text += "\r\n���ԭ��" + data_player_attributes?["banStatus"]?["bannedScopes"]?["reason"]?.Value<string>() ?? "";
                    richTextBox_Player_Attributes.Text += "\r\n�����Ϣ��" + data_player_attributes?["banStatus"]?["bannedScopes"]?["reasonMessage"]?.Value<string>() ?? "";
                }

            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox_Accees_Token.Text!="")
            {
                Check_Name check_name = await PlayerConfig.CheckName(textBox_Accees_Token.Text, textBox_Name_Check.Text);
                MessageBox.Show(check_name.ToString());
            }
            else
            {
                MessageBox.Show("���Ȼ�ȡAccess_Token��");
            }
        }
    }
}
