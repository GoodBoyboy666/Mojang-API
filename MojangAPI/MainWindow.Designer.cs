namespace MojangAPI
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewGroup listViewGroup3 = new ListViewGroup("Skins", HorizontalAlignment.Left);
            ListViewGroup listViewGroup4 = new ListViewGroup("Capes", HorizontalAlignment.Left);
            label_Player_Name = new Label();
            textBox_Player_Name = new TextBox();
            label_Player_UUID = new Label();
            textBox_UUID = new TextBox();
            btn_GetUUID = new Button();
            label_Skin = new Label();
            label_Cape = new Label();
            textBox_Skin_Url = new TextBox();
            textBox_Cape_Url = new TextBox();
            GetSkinAndCape = new Button();
            label_Accees_Token = new Label();
            textBox_Accees_Token = new TextBox();
            button_Get_Access_Token = new Button();
            label_Microsoft_authorization_code = new Label();
            textBox_Microsoft_authorization_code = new TextBox();
            button_Get_Microsoft_authorization_code = new Button();
            label_Microsoft_Client_ID = new Label();
            textBox_Microsoft_Client_ID = new TextBox();
            label_WebSite = new Label();
            textBox_WebSite = new TextBox();
            button_Initiate_authorization = new Button();
            textBox_Microsoft_Access_Token = new TextBox();
            label_Microsoft_Access_Token = new Label();
            textBox_Xbox_Live_Token = new TextBox();
            label_Xbox_Live_Token = new Label();
            textBox_XSTS_Token = new TextBox();
            label_XSTS_Token = new Label();
            label_Own_Minecraft = new Label();
            textBox_Own_Minecraft = new TextBox();
            button_Get_Player_Info = new Button();
            label1 = new Label();
            listView_Skin_Cape = new ListView();
            id = new ColumnHeader();
            state = new ColumnHeader();
            url = new ColumnHeader();
            variant_alias = new ColumnHeader();
            richTextBox_Player_Attributes = new RichTextBox();
            label_Name_Check = new Label();
            textBox_Name_Check = new TextBox();
            button_Name_Check = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label_Player_Name
            // 
            label_Player_Name.AutoSize = true;
            label_Player_Name.Location = new Point(32, 35);
            label_Player_Name.Name = "label_Player_Name";
            label_Player_Name.Size = new Size(100, 24);
            label_Player_Name.TabIndex = 0;
            label_Player_Name.Text = "玩家名称：";
            // 
            // textBox_Player_Name
            // 
            textBox_Player_Name.Location = new Point(138, 32);
            textBox_Player_Name.Name = "textBox_Player_Name";
            textBox_Player_Name.Size = new Size(257, 30);
            textBox_Player_Name.TabIndex = 1;
            // 
            // label_Player_UUID
            // 
            label_Player_UUID.AutoSize = true;
            label_Player_UUID.Location = new Point(32, 85);
            label_Player_UUID.Name = "label_Player_UUID";
            label_Player_UUID.Size = new Size(73, 24);
            label_Player_UUID.TabIndex = 2;
            label_Player_UUID.Text = "UUID：";
            // 
            // textBox_UUID
            // 
            textBox_UUID.Location = new Point(138, 82);
            textBox_UUID.Name = "textBox_UUID";
            textBox_UUID.Size = new Size(257, 30);
            textBox_UUID.TabIndex = 3;
            // 
            // btn_GetUUID
            // 
            btn_GetUUID.Location = new Point(425, 32);
            btn_GetUUID.Name = "btn_GetUUID";
            btn_GetUUID.Size = new Size(146, 80);
            btn_GetUUID.TabIndex = 4;
            btn_GetUUID.Text = "获取UUID";
            btn_GetUUID.UseVisualStyleBackColor = true;
            btn_GetUUID.Click += btn_GetUUID_Click;
            // 
            // label_Skin
            // 
            label_Skin.AutoSize = true;
            label_Skin.Location = new Point(32, 152);
            label_Skin.Name = "label_Skin";
            label_Skin.Size = new Size(64, 24);
            label_Skin.TabIndex = 5;
            label_Skin.Text = "Skin：";
            // 
            // label_Cape
            // 
            label_Cape.AutoSize = true;
            label_Cape.Location = new Point(32, 198);
            label_Cape.Name = "label_Cape";
            label_Cape.Size = new Size(72, 24);
            label_Cape.TabIndex = 6;
            label_Cape.Text = "Cape：";
            // 
            // textBox_Skin_Url
            // 
            textBox_Skin_Url.Location = new Point(138, 149);
            textBox_Skin_Url.Name = "textBox_Skin_Url";
            textBox_Skin_Url.Size = new Size(257, 30);
            textBox_Skin_Url.TabIndex = 7;
            // 
            // textBox_Cape_Url
            // 
            textBox_Cape_Url.Location = new Point(138, 195);
            textBox_Cape_Url.Name = "textBox_Cape_Url";
            textBox_Cape_Url.Size = new Size(257, 30);
            textBox_Cape_Url.TabIndex = 8;
            // 
            // GetSkinAndCape
            // 
            GetSkinAndCape.Location = new Point(425, 149);
            GetSkinAndCape.Name = "GetSkinAndCape";
            GetSkinAndCape.Size = new Size(146, 80);
            GetSkinAndCape.TabIndex = 9;
            GetSkinAndCape.Text = "获取皮肤与披风";
            GetSkinAndCape.UseVisualStyleBackColor = true;
            GetSkinAndCape.Click += GetSkinAndCape_Click;
            // 
            // label_Accees_Token
            // 
            label_Accees_Token.AutoSize = true;
            label_Accees_Token.Location = new Point(31, 607);
            label_Accees_Token.Name = "label_Accees_Token";
            label_Accees_Token.Size = new Size(147, 24);
            label_Accees_Token.TabIndex = 10;
            label_Accees_Token.Text = "Accees_Token：";
            // 
            // textBox_Accees_Token
            // 
            textBox_Accees_Token.Location = new Point(219, 607);
            textBox_Accees_Token.Name = "textBox_Accees_Token";
            textBox_Accees_Token.Size = new Size(341, 30);
            textBox_Accees_Token.TabIndex = 11;
            // 
            // button_Get_Access_Token
            // 
            button_Get_Access_Token.Location = new Point(591, 607);
            button_Get_Access_Token.Name = "button_Get_Access_Token";
            button_Get_Access_Token.Size = new Size(213, 34);
            button_Get_Access_Token.TabIndex = 12;
            button_Get_Access_Token.Text = "获取Access Token";
            button_Get_Access_Token.UseVisualStyleBackColor = true;
            button_Get_Access_Token.Click += button_Get_Access_Token_Click;
            // 
            // label_Microsoft_authorization_code
            // 
            label_Microsoft_authorization_code.AutoSize = true;
            label_Microsoft_authorization_code.Location = new Point(32, 368);
            label_Microsoft_authorization_code.Name = "label_Microsoft_authorization_code";
            label_Microsoft_authorization_code.Size = new Size(182, 24);
            label_Microsoft_authorization_code.TabIndex = 13;
            label_Microsoft_authorization_code.Text = "Microsoft授权代码：";
            // 
            // textBox_Microsoft_authorization_code
            // 
            textBox_Microsoft_authorization_code.Location = new Point(220, 368);
            textBox_Microsoft_authorization_code.Name = "textBox_Microsoft_authorization_code";
            textBox_Microsoft_authorization_code.Size = new Size(340, 30);
            textBox_Microsoft_authorization_code.TabIndex = 14;
            // 
            // button_Get_Microsoft_authorization_code
            // 
            button_Get_Microsoft_authorization_code.Location = new Point(591, 366);
            button_Get_Microsoft_authorization_code.Name = "button_Get_Microsoft_authorization_code";
            button_Get_Microsoft_authorization_code.Size = new Size(213, 34);
            button_Get_Microsoft_authorization_code.TabIndex = 15;
            button_Get_Microsoft_authorization_code.Text = "获取Microsoft授权代码";
            button_Get_Microsoft_authorization_code.UseVisualStyleBackColor = true;
            button_Get_Microsoft_authorization_code.Click += button1_Click;
            // 
            // label_Microsoft_Client_ID
            // 
            label_Microsoft_Client_ID.AutoSize = true;
            label_Microsoft_Client_ID.Location = new Point(32, 268);
            label_Microsoft_Client_ID.Name = "label_Microsoft_Client_ID";
            label_Microsoft_Client_ID.Size = new Size(189, 24);
            label_Microsoft_Client_ID.TabIndex = 16;
            label_Microsoft_Client_ID.Text = "Microsoft Client ID：";
            // 
            // textBox_Microsoft_Client_ID
            // 
            textBox_Microsoft_Client_ID.Location = new Point(219, 268);
            textBox_Microsoft_Client_ID.Name = "textBox_Microsoft_Client_ID";
            textBox_Microsoft_Client_ID.Size = new Size(341, 30);
            textBox_Microsoft_Client_ID.TabIndex = 17;
            textBox_Microsoft_Client_ID.Text = "00000000402b5328";
            // 
            // label_WebSite
            // 
            label_WebSite.AutoSize = true;
            label_WebSite.Location = new Point(32, 318);
            label_WebSite.Name = "label_WebSite";
            label_WebSite.Size = new Size(208, 24);
            label_WebSite.TabIndex = 18;
            label_WebSite.Text = "粘贴完成授权后的网址：";
            // 
            // textBox_WebSite
            // 
            textBox_WebSite.Location = new Point(246, 318);
            textBox_WebSite.Name = "textBox_WebSite";
            textBox_WebSite.Size = new Size(314, 30);
            textBox_WebSite.TabIndex = 19;
            // 
            // button_Initiate_authorization
            // 
            button_Initiate_authorization.Location = new Point(591, 313);
            button_Initiate_authorization.Name = "button_Initiate_authorization";
            button_Initiate_authorization.Size = new Size(213, 34);
            button_Initiate_authorization.TabIndex = 20;
            button_Initiate_authorization.Text = "发起授权";
            button_Initiate_authorization.UseVisualStyleBackColor = true;
            button_Initiate_authorization.Click += button_Initiate_authorization_Click;
            // 
            // textBox_Microsoft_Access_Token
            // 
            textBox_Microsoft_Access_Token.Location = new Point(273, 424);
            textBox_Microsoft_Access_Token.Name = "textBox_Microsoft_Access_Token";
            textBox_Microsoft_Access_Token.Size = new Size(287, 30);
            textBox_Microsoft_Access_Token.TabIndex = 22;
            // 
            // label_Microsoft_Access_Token
            // 
            label_Microsoft_Access_Token.AutoSize = true;
            label_Microsoft_Access_Token.Location = new Point(32, 427);
            label_Microsoft_Access_Token.Name = "label_Microsoft_Access_Token";
            label_Microsoft_Access_Token.Size = new Size(235, 24);
            label_Microsoft_Access_Token.TabIndex = 21;
            label_Microsoft_Access_Token.Text = "Microsoft_Access_Token：";
            // 
            // textBox_Xbox_Live_Token
            // 
            textBox_Xbox_Live_Token.Location = new Point(220, 485);
            textBox_Xbox_Live_Token.Name = "textBox_Xbox_Live_Token";
            textBox_Xbox_Live_Token.Size = new Size(340, 30);
            textBox_Xbox_Live_Token.TabIndex = 24;
            // 
            // label_Xbox_Live_Token
            // 
            label_Xbox_Live_Token.AutoSize = true;
            label_Xbox_Live_Token.Location = new Point(32, 487);
            label_Xbox_Live_Token.Name = "label_Xbox_Live_Token";
            label_Xbox_Live_Token.Size = new Size(146, 24);
            label_Xbox_Live_Token.TabIndex = 23;
            label_Xbox_Live_Token.Text = "Xbox Live令牌：";
            // 
            // textBox_XSTS_Token
            // 
            textBox_XSTS_Token.Location = new Point(220, 546);
            textBox_XSTS_Token.Name = "textBox_XSTS_Token";
            textBox_XSTS_Token.Size = new Size(340, 30);
            textBox_XSTS_Token.TabIndex = 26;
            // 
            // label_XSTS_Token
            // 
            label_XSTS_Token.AutoSize = true;
            label_XSTS_Token.Location = new Point(32, 547);
            label_XSTS_Token.Name = "label_XSTS_Token";
            label_XSTS_Token.Size = new Size(106, 24);
            label_XSTS_Token.TabIndex = 25;
            label_XSTS_Token.Text = "XSTS令牌：";
            // 
            // label_Own_Minecraft
            // 
            label_Own_Minecraft.AutoSize = true;
            label_Own_Minecraft.Location = new Point(990, 38);
            label_Own_Minecraft.Name = "label_Own_Minecraft";
            label_Own_Minecraft.Size = new Size(183, 24);
            label_Own_Minecraft.TabIndex = 27;
            label_Own_Minecraft.Text = "是否拥有Minecraft：";
            // 
            // textBox_Own_Minecraft
            // 
            textBox_Own_Minecraft.Location = new Point(1179, 38);
            textBox_Own_Minecraft.Name = "textBox_Own_Minecraft";
            textBox_Own_Minecraft.Size = new Size(217, 30);
            textBox_Own_Minecraft.TabIndex = 28;
            // 
            // button_Get_Player_Info
            // 
            button_Get_Player_Info.Location = new Point(1610, 629);
            button_Get_Player_Info.Name = "button_Get_Player_Info";
            button_Get_Player_Info.Size = new Size(117, 104);
            button_Get_Player_Info.TabIndex = 29;
            button_Get_Player_Info.Text = "获取玩家详细信息";
            button_Get_Player_Info.UseVisualStyleBackColor = true;
            button_Get_Player_Info.Click += button_Get_Player_Info_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(990, 100);
            label1.Name = "label1";
            label1.Size = new Size(154, 24);
            label1.TabIndex = 31;
            label1.Text = "皮肤与披风列表：";
            // 
            // listView_Skin_Cape
            // 
            listView_Skin_Cape.Columns.AddRange(new ColumnHeader[] { id, state, url, variant_alias });
            listViewGroup3.Header = "Skins";
            listViewGroup3.Name = "Skins";
            listViewGroup4.Header = "Capes";
            listViewGroup4.Name = "Capes";
            listView_Skin_Cape.Groups.AddRange(new ListViewGroup[] { listViewGroup3, listViewGroup4 });
            listView_Skin_Cape.Location = new Point(991, 152);
            listView_Skin_Cape.Name = "listView_Skin_Cape";
            listView_Skin_Cape.Size = new Size(736, 240);
            listView_Skin_Cape.TabIndex = 32;
            listView_Skin_Cape.UseCompatibleStateImageBehavior = false;
            listView_Skin_Cape.View = View.Details;
            // 
            // id
            // 
            id.Text = "id";
            id.Width = 200;
            // 
            // state
            // 
            state.Text = "state";
            state.Width = 100;
            // 
            // url
            // 
            url.Text = "url";
            url.Width = 300;
            // 
            // variant_alias
            // 
            variant_alias.Text = "variant/alias";
            variant_alias.Width = 150;
            // 
            // richTextBox_Player_Attributes
            // 
            richTextBox_Player_Attributes.Location = new Point(990, 413);
            richTextBox_Player_Attributes.Name = "richTextBox_Player_Attributes";
            richTextBox_Player_Attributes.Size = new Size(737, 186);
            richTextBox_Player_Attributes.TabIndex = 33;
            richTextBox_Player_Attributes.Text = "";
            // 
            // label_Name_Check
            // 
            label_Name_Check.AutoSize = true;
            label_Name_Check.Location = new Point(31, 669);
            label_Name_Check.Name = "label_Name_Check";
            label_Name_Check.Size = new Size(154, 24);
            label_Name_Check.TabIndex = 34;
            label_Name_Check.Text = "名称有效性检查：";
            // 
            // textBox_Name_Check
            // 
            textBox_Name_Check.Location = new Point(220, 666);
            textBox_Name_Check.Name = "textBox_Name_Check";
            textBox_Name_Check.Size = new Size(340, 30);
            textBox_Name_Check.TabIndex = 35;
            // 
            // button_Name_Check
            // 
            button_Name_Check.Location = new Point(591, 664);
            button_Name_Check.Name = "button_Name_Check";
            button_Name_Check.Size = new Size(213, 34);
            button_Name_Check.TabIndex = 36;
            button_Name_Check.Text = "检查";
            button_Name_Check.UseVisualStyleBackColor = true;
            button_Name_Check.Click += button1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(591, 271);
            label2.Name = "label2";
            label2.Size = new Size(207, 24);
            label2.TabIndex = 37;
            label2.Text = "Tips：该项一般无需更改";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1762, 774);
            Controls.Add(label2);
            Controls.Add(button_Name_Check);
            Controls.Add(textBox_Name_Check);
            Controls.Add(label_Name_Check);
            Controls.Add(richTextBox_Player_Attributes);
            Controls.Add(listView_Skin_Cape);
            Controls.Add(label1);
            Controls.Add(button_Get_Player_Info);
            Controls.Add(textBox_Own_Minecraft);
            Controls.Add(label_Own_Minecraft);
            Controls.Add(textBox_XSTS_Token);
            Controls.Add(label_XSTS_Token);
            Controls.Add(textBox_Xbox_Live_Token);
            Controls.Add(label_Xbox_Live_Token);
            Controls.Add(textBox_Microsoft_Access_Token);
            Controls.Add(label_Microsoft_Access_Token);
            Controls.Add(button_Initiate_authorization);
            Controls.Add(textBox_WebSite);
            Controls.Add(label_WebSite);
            Controls.Add(textBox_Microsoft_Client_ID);
            Controls.Add(label_Microsoft_Client_ID);
            Controls.Add(button_Get_Microsoft_authorization_code);
            Controls.Add(textBox_Microsoft_authorization_code);
            Controls.Add(label_Microsoft_authorization_code);
            Controls.Add(button_Get_Access_Token);
            Controls.Add(textBox_Accees_Token);
            Controls.Add(label_Accees_Token);
            Controls.Add(GetSkinAndCape);
            Controls.Add(textBox_Cape_Url);
            Controls.Add(textBox_Skin_Url);
            Controls.Add(label_Cape);
            Controls.Add(label_Skin);
            Controls.Add(btn_GetUUID);
            Controls.Add(textBox_UUID);
            Controls.Add(label_Player_UUID);
            Controls.Add(textBox_Player_Name);
            Controls.Add(label_Player_Name);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "MojangAPI Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Player_Name;
        private TextBox textBox_Player_Name;
        private Label label_Player_UUID;
        private TextBox textBox_UUID;
        private Button btn_GetUUID;
        private Label label_Skin;
        private Label label_Cape;
        private TextBox textBox_Skin_Url;
        private TextBox textBox_Cape_Url;
        private Button GetSkinAndCape;
        private Label label_Accees_Token;
        private TextBox textBox_Accees_Token;
        private Button button_Get_Access_Token;
        private Label label_Microsoft_authorization_code;
        private TextBox textBox_Microsoft_authorization_code;
        private Button button_Get_Microsoft_authorization_code;
        private Label label_Microsoft_Client_ID;
        private TextBox textBox_Microsoft_Client_ID;
        private Label label_WebSite;
        private TextBox textBox_WebSite;
        private Button button_Initiate_authorization;
        private TextBox textBox_Microsoft_Access_Token;
        private Label label_Microsoft_Access_Token;
        private TextBox textBox_Xbox_Live_Token;
        private Label label_Xbox_Live_Token;
        private TextBox textBox_XSTS_Token;
        private Label label_XSTS_Token;
        private Label label_Own_Minecraft;
        private TextBox textBox_Own_Minecraft;
        private Button button_Get_Player_Info;
        private Label label1;
        private ListView listView_Skin_Cape;
        private ColumnHeader id;
        private ColumnHeader state;
        private ColumnHeader url;
        private ColumnHeader variant_alias;
        private RichTextBox richTextBox_Player_Attributes;
        private Label label_Name_Check;
        private TextBox textBox_Name_Check;
        private Button button_Name_Check;
        private Label label2;
    }
}
