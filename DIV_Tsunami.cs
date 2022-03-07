using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.IO.Ports;
using Disaster_information_viewer.Properties;
using System.Threading;
using AngleSharp.Html.Parser;

namespace Disaster_information_viewer
{
    public partial class DIV_Tsunami : Form
    {
        public DIV_Tsunami()
        {
            InitializeComponent();
        }

        private void P2PTsunami_Tick(object sender, EventArgs e)
        {
            WebClient wc_P2PTsunami = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            string P2PTsunami_json;
            //通常
            //P2PTsunami_json = wc_P2PTsunami.DownloadString("https://api.p2pquake.net/v2/jma/tsunami?limit=1");
            //テスト
            P2PTsunami_json = wc_P2PTsunami.DownloadString("https://api.p2pquake.net/v2/jma/tsunami?limit=1&offset=5");



            JSON_P2P_Tsunami P2PTsunami_Json = JsonConvert.DeserializeObject<JSON_P2P_Tsunami>(P2PTsunami_json);


            if (P2PTsunami_Json.Cancelled == false)
            {

                Text1.Text = $"{P2PTsunami_Json.Areas[0].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[0].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[0].Name}";
                Text2.Text = $"{P2PTsunami_Json.Areas[1].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[1].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[1].Name}";
                Text3.Text = $"{P2PTsunami_Json.Areas[2].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[2].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[2].Name}";
                Text4.Text = $"{P2PTsunami_Json.Areas[3].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[3].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[3].Name}";
                Text5.Text = $"{P2PTsunami_Json.Areas[4].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[4].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[4].Name}";








            }

















        }
        public Dictionary<string, string> AreaDictionary = new Dictionary<string, string>
        {
            { "オホーツク海沿岸", "02" },
            { "北海道太平洋沿岸東部", "03" },
            { "北海道太平洋沿岸中部", "04" },
            { "北海道太平洋沿岸西部", "05" },
            { "北海道日本海沿岸北部", "60" },
            { "北海道日本海沿岸南部", "59" },
            { "陸奥湾", "66" },
            { "青森県日本海沿岸", "58" },
            { "青森県太平洋沿岸", "06" },
            { "岩手県", "07" },
            { "宮城県", "08" },
            { "福島県", "09" },
            { "秋田県", "57" },
            { "山形県", "56" },
            { "茨城県", "10" },
            { "千葉県九十九里・外房", "11" },
            { "千葉県内房", "12" },
            { "東京湾内湾", "13" },
            { "伊豆諸島", "14" },
            { "小笠原諸島", "65" },
            { "相模湾・三浦半島", "15" },
            { "静岡県", "16" },
            { "愛知県外海", "17" },
            { "伊勢・三河湾", "18" },
            { "三重県南部", "19" },
            { "新潟県上中下越", "54" },
            { "佐渡", "55" },
            { "富山県", "53" },
            { "石川県能登", "52" },
            { "石川県加賀", "01" },
            { "福井県", "51" },
            { "京都府", "50" },
            { "兵庫県北部", "49" },
            { "兵庫県瀬戸内海沿岸", "22" },
            { "淡路島南部", "23" },
            { "大阪府", "21" },
            { "和歌山県", "20" },
            { "鳥取県", "48" },
            { "島根県出雲・石見", "46" },
            { "隠岐", "47" },
            { "岡山県", "44" },
            { "広島県", "43" },
            { "香川県", "28" },
            { "愛媛県瀬戸内海沿岸", "27" },
            { "愛媛県宇和海沿岸", "26" },
            { "徳島県", "24" },
            { "高知県", "25" },
            { "山口県瀬戸内海沿岸", "42" },
            { "山口県日本海沿岸", "4" },
            { "福岡県瀬戸内海沿岸", "40" },
            { "福岡県日本海沿岸", "39" },
            { "佐賀県北部", "37" },
            { "長崎県西方", "36" },
            { "壱岐・対馬", "55" },
            { "有明・八代海", "34" },
            { "熊本県天草灘沿岸", "35" },
            { "大分県瀬戸内海沿岸", "41" },
            { "大分県豊後水道沿岸", "29" },
            { "宮崎県", "30" },
            { "鹿児島県東部", "31" },
            { "鹿児島県西部", "33" },
            { "種子島・屋久島地方", "32" },
            { "奄美群島・トカラ列島", "61" },
            { "沖縄本島地方", "63" },
            { "宮古島・八重山地方", "64" },
            { "大東島地方", "62" }
        };

        private void Tsunamizyouhou_Click(object sender, EventArgs e)
        {
            WebClient wc_P2PTsunami = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            string P2PTsunami_json;
            //通常
            //P2PTsunami_json = wc_P2PTsunami.DownloadString("https://api.p2pquake.net/v2/jma/tsunami?limit=1");
            //テスト
            P2PTsunami_json = wc_P2PTsunami.DownloadString("https://api.p2pquake.net/v2/jma/tsunami?limit=1&offset=5");



            JSON_P2P_Tsunami P2PTsunami_Json = JsonConvert.DeserializeObject<JSON_P2P_Tsunami>(P2PTsunami_json);


            if (P2PTsunami_Json.Cancelled == false)
            {

                Text1.Text = $"{P2PTsunami_Json.Areas[0].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[0].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[0].Name}";
                Text2.Text = $"{P2PTsunami_Json.Areas[1].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[1].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[1].Name}";
                Text3.Text = $"{P2PTsunami_Json.Areas[2].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[2].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[2].Name}";
                Text4.Text = $"{P2PTsunami_Json.Areas[3].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[3].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[3].Name}";
                Text5.Text = $"{P2PTsunami_Json.Areas[4].Immediate.Replace("true", "!").Replace("false", " ")}{P2PTsunami_Json.Areas[4].Grade.Replace("MajorWarning", "大津波警報").Replace("Warning", " 津波警報").Replace("Watch", "津波注意報").Replace("Unknown", " 不明")}　　{P2PTsunami_Json.Areas[4].Name}";
            }
        }
    }
}