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
using Disaster_information_viewer_json_P2P;

namespace Disaster_information_viewer
{
    public partial class DIV_Earthquakes : Form
    {
        public DIV_Earthquakes()
        {
            InitializeComponent();
        }
        /*
        List x _ y _ z
x=1 Japan
  y = 1~8 new ~old
     z=1^5 1=Back 2=Time 3=Shingen 4=Depth Magnitude
x = 2 Hi-net
    y = 1~2 1=Hinet 2=AQUA real
    z=1 1=
x=3 USGS
  y = 1~ new ~old
     z=1 
*/
        private void P2PQuake_Tick(object sender, EventArgs e)
        {
            //try
            {
                WebClient wc_P2PQuake = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                string P2Pquake_json;
                //通常
                P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake");
              　//山梨県東部・富士五湖
                //P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?order=1&since_date=20211203");
                //胆振東部
                //P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?order=1&since_date=20180906");
                //ケルデマック
                //P2Pquake_json = wc_P2PQuake.DownloadString(" https://api.p2pquake.net/v2/jma/quake?order=1&since_date=20210305");


                List<Quake_P2P_JSON1> P2PQuake_json = JsonConvert.DeserializeObject<List<Quake_P2P_JSON1>>(P2Pquake_json);

                List1_1_2.Text = Convert.ToString(P2PQuake_json[0].Earthquake.Time).Remove(16, 3);
                List1_1_3.Text = P2PQuake_json[0].Earthquake.Hypocenter.Name;
                List1_1_4.Text = P2PQuake_json[0].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[0].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_2_2.Text = Convert.ToString(P2PQuake_json[1].Earthquake.Time).Remove(16, 3);
                List1_2_3.Text = P2PQuake_json[1].Earthquake.Hypocenter.Name;
                List1_2_4.Text = P2PQuake_json[1].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[1].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_3_2.Text = Convert.ToString(P2PQuake_json[2].Earthquake.Time).Remove(16, 3);
                List1_3_3.Text = P2PQuake_json[2].Earthquake.Hypocenter.Name;
                List1_3_4.Text = P2PQuake_json[2].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[2].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_4_2.Text = Convert.ToString(P2PQuake_json[3].Earthquake.Time).Remove(16, 3);
                List1_4_3.Text = P2PQuake_json[3].Earthquake.Hypocenter.Name;
                List1_4_4.Text = P2PQuake_json[3].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[3].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_5_2.Text = Convert.ToString(P2PQuake_json[4].Earthquake.Time).Remove(16, 3);
                List1_5_3.Text = P2PQuake_json[4].Earthquake.Hypocenter.Name;
                List1_5_4.Text = P2PQuake_json[4].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[4].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_6_2.Text = Convert.ToString(P2PQuake_json[5].Earthquake.Time).Remove(16, 3);
                List1_6_3.Text = P2PQuake_json[5].Earthquake.Hypocenter.Name;
                List1_6_4.Text = P2PQuake_json[5].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[5].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_7_2.Text = Convert.ToString(P2PQuake_json[6].Earthquake.Time).Remove(16, 3);
                List1_7_3.Text = P2PQuake_json[6].Earthquake.Hypocenter.Name;
                List1_7_4.Text = P2PQuake_json[6].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[6].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_8_2.Text = Convert.ToString(P2PQuake_json[7].Earthquake.Time).Remove(16, 3);
                List1_8_3.Text = P2PQuake_json[7].Earthquake.Hypocenter.Name;
                List1_8_4.Text = P2PQuake_json[7].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[7].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_9_2.Text = Convert.ToString(P2PQuake_json[8].Earthquake.Time).Remove(16, 3);
                List1_9_3.Text = P2PQuake_json[8].Earthquake.Hypocenter.Name;
                List1_9_4.Text = P2PQuake_json[8].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[8].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                List1_10_2.Text = Convert.ToString(P2PQuake_json[9].Earthquake.Time).Remove(16, 3);
                List1_10_3.Text = P2PQuake_json[9].Earthquake.Hypocenter.Name;
                List1_10_4.Text = P2PQuake_json[9].Earthquake.Hypocenter.Depth + "km　　　M" + (Convert.ToString(P2PQuake_json[9].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9");

                if (P2PQuake_json[0].Issue.Type == "ScalePrompt")
                {
                    List1_1_3.Text = "《震度速報》";
                    List1_1_4.Text = "";
                }
                if (P2PQuake_json[1].Issue.Type == "ScalePrompt")
                {
                    List1_2_3.Text = "《震度速報》";
                    List1_2_4.Text = "";
                }
                if (P2PQuake_json[2].Issue.Type == "ScalePrompt")
                {
                    List1_3_3.Text = "《震度速報》";
                    List1_3_4.Text = "";
                }
                if (P2PQuake_json[3].Issue.Type == "ScalePrompt")
                {
                    List1_4_3.Text = "《震度速報》";
                    List1_4_4.Text = "";
                }
                if (P2PQuake_json[4].Issue.Type == "ScalePrompt")
                {
                    List1_5_3.Text = "《震度速報》";
                    List1_5_4.Text = "";
                }
                if (P2PQuake_json[5].Issue.Type == "ScalePrompt")
                {
                    List1_6_3.Text = "《震度速報》";
                    List1_6_4.Text = "";
                }
                if (P2PQuake_json[6].Issue.Type == "ScalePrompt")
                {
                    List1_7_3.Text = "《震度速報》";
                    List1_7_4.Text = "";
                }
                if (P2PQuake_json[7].Issue.Type == "ScalePrompt")
                {
                    List1_8_3.Text = "《震度速報》";
                    List1_8_4.Text = "";
                }
                if (P2PQuake_json[8].Issue.Type == "ScalePrompt")
                {
                    List1_9_3.Text = "《震度速報》";
                    List1_9_4.Text = "";
                }
                if (P2PQuake_json[9].Issue.Type == "ScalePrompt")
                {
                    List1_10_3.Text = "《震度速報》";
                    List1_10_4.Text = "";
                }
                if (P2PQuake_json[0].Issue.Type == "Destination")
                {
                    List1_1_4.Text =Convert.ToString(P2PQuake_json[0].Earthquake.DomesticTsunami).Replace("None","津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[1].Issue.Type == "Destination")
                {
                    List1_2_4.Text =Convert.ToString(P2PQuake_json[1].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[2].Issue.Type == "Destination")
                {
                    List1_3_4.Text = Convert.ToString(P2PQuake_json[2].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[3].Issue.Type == "Destination")
                {
                    List1_4_4.Text = Convert.ToString(P2PQuake_json[3].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[4].Issue.Type == "Destination")
                {
                    List1_5_4.Text = Convert.ToString(P2PQuake_json[4].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[5].Issue.Type == "Destination")
                {
                    List1_6_4.Text = Convert.ToString(P2PQuake_json[5].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[6].Issue.Type == "Destination")
                {
                    List1_7_4.Text = Convert.ToString(P2PQuake_json[6].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[7].Issue.Type == "Destination")
                {
                    List1_8_4.Text = Convert.ToString(P2PQuake_json[7].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[8].Issue.Type == "Destination")
                {
                    List1_9_4.Text = Convert.ToString(P2PQuake_json[8].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[9].Issue.Type == "Destination")
                {
                    List1_10_4.Text = Convert.ToString(P2PQuake_json[9].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[0].Issue.Type == "Foreign")
                {
                    List1_1_4.Text = "M" + (Convert.ToString(P2PQuake_json[0].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[0].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[1].Issue.Type == "Foreign")
                {
                    List1_2_4.Text = "M" + (Convert.ToString(P2PQuake_json[1].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[1].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[2].Issue.Type == "Foreign")
                {
                    List1_3_4.Text = "M" + (Convert.ToString(P2PQuake_json[2].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[2].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[3].Issue.Type == "Foreign")
                {
                    List1_4_4.Text = "M" + (Convert.ToString(P2PQuake_json[3].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[3].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[4].Issue.Type == "Foreign")
                {
                    List1_5_4.Text = "M" + (Convert.ToString(P2PQuake_json[4].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[4].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[5].Issue.Type == "Foreign")
                {
                    List1_6_4.Text = "M" + (Convert.ToString(P2PQuake_json[5].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[5].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[6].Issue.Type == "Foreign")
                {
                    List1_7_4.Text = "M" + (Convert.ToString(P2PQuake_json[6].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[6].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[7].Issue.Type == "Foreign")
                {
                    List1_8_4.Text = "M" + (Convert.ToString(P2PQuake_json[7].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[7].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[8].Issue.Type == "Foreign")
                {
                    List1_9_4.Text = "M" + (Convert.ToString(P2PQuake_json[8].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[8].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[9].Issue.Type == "Foreign")
                {
                    List1_10_4.Text = "M" + (Convert.ToString(P2PQuake_json[9].Earthquake.Hypocenter.Magnitude) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9") + "　" + Convert.ToString(P2PQuake_json[9].Earthquake.DomesticTsunami).Replace("None", "津波の心配なし").Replace("Unknown", "津波不明").Replace("Checking", "津波調査中").Replace("NonEffective", "若干の海面変動").Replace("Watch", "津波注意報発表中").Replace("Warning", "津波情報発表中");
                }
                if (P2PQuake_json[0].Earthquake.MaxScale == 10)
                {
                    List1_1_1.Image = Resources.quakeback1;
                    List1_1_2.BackColor = Settings.Default.ShindoColor21;
                    List1_1_3.BackColor = Settings.Default.ShindoColor21;
                    List1_1_4.BackColor = Settings.Default.ShindoColor21;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[0].Earthquake.MaxScale == 20)
                {
                    List1_1_1.Image = Resources.quakeback2;
                    List1_1_2.BackColor = Settings.Default.ShindoColor22;
                    List1_1_3.BackColor = Settings.Default.ShindoColor22;
                    List1_1_4.BackColor = Settings.Default.ShindoColor22;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[0].Earthquake.MaxScale == 30)
                {
                    List1_1_1.Image = Resources.quakeback3;
                    List1_1_2.BackColor = Settings.Default.ShindoColor23;
                    List1_1_3.BackColor = Settings.Default.ShindoColor23;
                    List1_1_4.BackColor = Settings.Default.ShindoColor23;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[0].Earthquake.MaxScale == 40)
                {
                    List1_1_1.Image = Resources.quakeback4;
                    List1_1_2.BackColor = Settings.Default.ShindoColor24;
                    List1_1_3.BackColor = Settings.Default.ShindoColor24;
                    List1_1_4.BackColor = Settings.Default.ShindoColor24;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[0].Earthquake.MaxScale == 45)
                {
                    List1_1_1.Image = Resources.quakeback5;
                    List1_1_2.BackColor = Settings.Default.ShindoColor25;
                    List1_1_3.BackColor = Settings.Default.ShindoColor25;
                    List1_1_4.BackColor = Settings.Default.ShindoColor25;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[0].Earthquake.MaxScale == 50)
                {
                    List1_1_1.Image = Resources.quakeback6;
                    List1_1_2.BackColor = Settings.Default.ShindoColor26;
                    List1_1_3.BackColor = Settings.Default.ShindoColor26;
                    List1_1_4.BackColor = Settings.Default.ShindoColor26;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[0].Earthquake.MaxScale == 55)
                {
                    List1_1_1.Image = Resources.quakeback7;
                    List1_1_2.BackColor = Settings.Default.ShindoColor27;
                    List1_1_3.BackColor = Settings.Default.ShindoColor27;
                    List1_1_4.BackColor = Settings.Default.ShindoColor27;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[0].Earthquake.MaxScale == 60)
                {
                    List1_1_1.Image = Resources.quakeback8;
                    List1_1_2.BackColor = Settings.Default.ShindoColor28;
                    List1_1_3.BackColor = Settings.Default.ShindoColor28;
                    List1_1_4.BackColor = Settings.Default.ShindoColor28;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[0].Earthquake.MaxScale == 70)
                {
                    List1_1_1.Image = Resources.quakeback9;
                    List1_1_2.BackColor = Settings.Default.ShindoColor29;
                    List1_1_3.BackColor = Settings.Default.ShindoColor29;
                    List1_1_4.BackColor = Settings.Default.ShindoColor29;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_1_1.Image = Resources.quakeback0;
                    List1_1_2.BackColor = Settings.Default.ShindoColor20;
                    List1_1_3.BackColor = Settings.Default.ShindoColor20;
                    List1_1_4.BackColor = Settings.Default.ShindoColor20;
                    List1_1_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_1_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_1_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[1].Earthquake.MaxScale == 10)
                {
                    List1_2_1.Image = Resources.quakeback1;
                    List1_2_2.BackColor = Settings.Default.ShindoColor21;
                    List1_2_3.BackColor = Settings.Default.ShindoColor21;
                    List1_2_4.BackColor = Settings.Default.ShindoColor21;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[1].Earthquake.MaxScale == 20)
                {
                    List1_2_1.Image = Resources.quakeback2;
                    List1_2_2.BackColor = Settings.Default.ShindoColor22;
                    List1_2_3.BackColor = Settings.Default.ShindoColor22;
                    List1_2_4.BackColor = Settings.Default.ShindoColor22;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[1].Earthquake.MaxScale == 30)
                {
                    List1_2_1.Image = Resources.quakeback3;
                    List1_2_2.BackColor = Settings.Default.ShindoColor23;
                    List1_2_3.BackColor = Settings.Default.ShindoColor23;
                    List1_2_4.BackColor = Settings.Default.ShindoColor23;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[1].Earthquake.MaxScale == 40)
                {
                    List1_2_1.Image = Resources.quakeback4;
                    List1_2_2.BackColor = Settings.Default.ShindoColor24;
                    List1_2_3.BackColor = Settings.Default.ShindoColor24;
                    List1_2_4.BackColor = Settings.Default.ShindoColor24;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[1].Earthquake.MaxScale == 45)
                {
                    List1_2_1.Image = Resources.quakeback5;
                    List1_2_2.BackColor = Settings.Default.ShindoColor25;
                    List1_2_3.BackColor = Settings.Default.ShindoColor25;
                    List1_2_4.BackColor = Settings.Default.ShindoColor25;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[1].Earthquake.MaxScale == 50)
                {
                    List1_2_1.Image = Resources.quakeback6;
                    List1_2_2.BackColor = Settings.Default.ShindoColor26;
                    List1_2_3.BackColor = Settings.Default.ShindoColor26;
                    List1_2_4.BackColor = Settings.Default.ShindoColor26;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[1].Earthquake.MaxScale == 55)
                {
                    List1_2_1.Image = Resources.quakeback7;
                    List1_2_2.BackColor = Settings.Default.ShindoColor27;
                    List1_2_3.BackColor = Settings.Default.ShindoColor27;
                    List1_2_4.BackColor = Settings.Default.ShindoColor27;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[1].Earthquake.MaxScale == 60)
                {
                    List1_2_1.Image = Resources.quakeback8;
                    List1_2_2.BackColor = Settings.Default.ShindoColor28;
                    List1_2_3.BackColor = Settings.Default.ShindoColor28;
                    List1_2_4.BackColor = Settings.Default.ShindoColor28;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[1].Earthquake.MaxScale == 70)
                {
                    List1_2_1.Image = Resources.quakeback9;
                    List1_2_2.BackColor = Settings.Default.ShindoColor29;
                    List1_2_3.BackColor = Settings.Default.ShindoColor29;
                    List1_2_4.BackColor = Settings.Default.ShindoColor29;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_2_1.Image = Resources.quakeback0;
                    List1_2_2.BackColor = Settings.Default.ShindoColor20;
                    List1_2_3.BackColor = Settings.Default.ShindoColor20;
                    List1_2_4.BackColor = Settings.Default.ShindoColor20;
                    List1_2_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_2_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_2_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[2].Earthquake.MaxScale == 10)
                {
                    List1_3_1.Image = Resources.quakeback1;
                    List1_3_2.BackColor = Settings.Default.ShindoColor21;
                    List1_3_3.BackColor = Settings.Default.ShindoColor21;
                    List1_3_4.BackColor = Settings.Default.ShindoColor21;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[2].Earthquake.MaxScale == 20)
                {
                    List1_3_1.Image = Resources.quakeback2;
                    List1_3_2.BackColor = Settings.Default.ShindoColor22;
                    List1_3_3.BackColor = Settings.Default.ShindoColor22;
                    List1_3_4.BackColor = Settings.Default.ShindoColor22;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[2].Earthquake.MaxScale == 30)
                {
                    List1_3_1.Image = Resources.quakeback3;
                    List1_3_2.BackColor = Settings.Default.ShindoColor23;
                    List1_3_3.BackColor = Settings.Default.ShindoColor23;
                    List1_3_4.BackColor = Settings.Default.ShindoColor23;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[2].Earthquake.MaxScale == 40)
                {
                    List1_3_1.Image = Resources.quakeback4;
                    List1_3_2.BackColor = Settings.Default.ShindoColor24;
                    List1_3_3.BackColor = Settings.Default.ShindoColor24;
                    List1_3_4.BackColor = Settings.Default.ShindoColor24;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[2].Earthquake.MaxScale == 45)
                {
                    List1_3_1.Image = Resources.quakeback5;
                    List1_3_2.BackColor = Settings.Default.ShindoColor25;
                    List1_3_3.BackColor = Settings.Default.ShindoColor25;
                    List1_3_4.BackColor = Settings.Default.ShindoColor25;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[2].Earthquake.MaxScale == 50)
                {
                    List1_3_1.Image = Resources.quakeback6;
                    List1_3_2.BackColor = Settings.Default.ShindoColor26;
                    List1_3_3.BackColor = Settings.Default.ShindoColor26;
                    List1_3_4.BackColor = Settings.Default.ShindoColor26;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[2].Earthquake.MaxScale == 55)
                {
                    List1_3_1.Image = Resources.quakeback7;
                    List1_3_2.BackColor = Settings.Default.ShindoColor27;
                    List1_3_3.BackColor = Settings.Default.ShindoColor27;
                    List1_3_4.BackColor = Settings.Default.ShindoColor27;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[2].Earthquake.MaxScale == 60)
                {
                    List1_3_1.Image = Resources.quakeback8;
                    List1_3_2.BackColor = Settings.Default.ShindoColor28;
                    List1_3_3.BackColor = Settings.Default.ShindoColor28;
                    List1_3_4.BackColor = Settings.Default.ShindoColor28;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[2].Earthquake.MaxScale == 70)
                {
                    List1_3_1.Image = Resources.quakeback9;
                    List1_3_2.BackColor = Settings.Default.ShindoColor29;
                    List1_3_3.BackColor = Settings.Default.ShindoColor29;
                    List1_3_4.BackColor = Settings.Default.ShindoColor29;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_3_1.Image = Resources.quakeback0;
                    List1_3_2.BackColor = Settings.Default.ShindoColor20;
                    List1_3_3.BackColor = Settings.Default.ShindoColor20;
                    List1_3_4.BackColor = Settings.Default.ShindoColor20;
                    List1_3_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_3_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_3_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[3].Earthquake.MaxScale == 10)
                {
                    List1_4_1.Image = Resources.quakeback1;
                    List1_4_2.BackColor = Settings.Default.ShindoColor21;
                    List1_4_3.BackColor = Settings.Default.ShindoColor21;
                    List1_4_4.BackColor = Settings.Default.ShindoColor21;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[3].Earthquake.MaxScale == 20)
                {
                    List1_4_1.Image = Resources.quakeback2;
                    List1_4_2.BackColor = Settings.Default.ShindoColor22;
                    List1_4_3.BackColor = Settings.Default.ShindoColor22;
                    List1_4_4.BackColor = Settings.Default.ShindoColor22;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[3].Earthquake.MaxScale == 30)
                {
                    List1_4_1.Image = Resources.quakeback3;
                    List1_4_2.BackColor = Settings.Default.ShindoColor23;
                    List1_4_3.BackColor = Settings.Default.ShindoColor23;
                    List1_4_4.BackColor = Settings.Default.ShindoColor23;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[3].Earthquake.MaxScale == 40)
                {
                    List1_4_1.Image = Resources.quakeback4;
                    List1_4_2.BackColor = Settings.Default.ShindoColor24;
                    List1_4_3.BackColor = Settings.Default.ShindoColor24;
                    List1_4_4.BackColor = Settings.Default.ShindoColor24;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[3].Earthquake.MaxScale == 45)
                {
                    List1_4_1.Image = Resources.quakeback5;
                    List1_4_2.BackColor = Settings.Default.ShindoColor25;
                    List1_4_3.BackColor = Settings.Default.ShindoColor25;
                    List1_4_4.BackColor = Settings.Default.ShindoColor25;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[3].Earthquake.MaxScale == 50)
                {
                    List1_4_1.Image = Resources.quakeback6;
                    List1_4_2.BackColor = Settings.Default.ShindoColor26;
                    List1_4_3.BackColor = Settings.Default.ShindoColor26;
                    List1_4_4.BackColor = Settings.Default.ShindoColor26;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[3].Earthquake.MaxScale == 55)
                {
                    List1_4_1.Image = Resources.quakeback7;
                    List1_4_2.BackColor = Settings.Default.ShindoColor27;
                    List1_4_3.BackColor = Settings.Default.ShindoColor27;
                    List1_4_4.BackColor = Settings.Default.ShindoColor27;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[3].Earthquake.MaxScale == 60)
                {
                    List1_4_1.Image = Resources.quakeback8;
                    List1_4_2.BackColor = Settings.Default.ShindoColor28;
                    List1_4_3.BackColor = Settings.Default.ShindoColor28;
                    List1_4_4.BackColor = Settings.Default.ShindoColor28;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[3].Earthquake.MaxScale == 70)
                {
                    List1_4_1.Image = Resources.quakeback9;
                    List1_4_2.BackColor = Settings.Default.ShindoColor29;
                    List1_4_3.BackColor = Settings.Default.ShindoColor29;
                    List1_4_4.BackColor = Settings.Default.ShindoColor29;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_4_1.Image = Resources.quakeback0;
                    List1_4_2.BackColor = Settings.Default.ShindoColor20;
                    List1_4_3.BackColor = Settings.Default.ShindoColor20;
                    List1_4_4.BackColor = Settings.Default.ShindoColor20;
                    List1_4_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_4_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_4_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[4].Earthquake.MaxScale == 10)
                {
                    List1_5_1.Image = Resources.quakeback1;
                    List1_5_2.BackColor = Settings.Default.ShindoColor21;
                    List1_5_3.BackColor = Settings.Default.ShindoColor21;
                    List1_5_4.BackColor = Settings.Default.ShindoColor21;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[4].Earthquake.MaxScale == 20)
                {
                    List1_5_1.Image = Resources.quakeback2;
                    List1_5_2.BackColor = Settings.Default.ShindoColor22;
                    List1_5_3.BackColor = Settings.Default.ShindoColor22;
                    List1_5_4.BackColor = Settings.Default.ShindoColor22;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[4].Earthquake.MaxScale == 30)
                {
                    List1_5_1.Image = Resources.quakeback3;
                    List1_5_2.BackColor = Settings.Default.ShindoColor23;
                    List1_5_3.BackColor = Settings.Default.ShindoColor23;
                    List1_5_4.BackColor = Settings.Default.ShindoColor23;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[4].Earthquake.MaxScale == 40)
                {
                    List1_5_1.Image = Resources.quakeback4;
                    List1_5_2.BackColor = Settings.Default.ShindoColor24;
                    List1_5_3.BackColor = Settings.Default.ShindoColor24;
                    List1_5_4.BackColor = Settings.Default.ShindoColor24;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[4].Earthquake.MaxScale == 45)
                {
                    List1_5_1.Image = Resources.quakeback5;
                    List1_5_2.BackColor = Settings.Default.ShindoColor25;
                    List1_5_3.BackColor = Settings.Default.ShindoColor25;
                    List1_5_4.BackColor = Settings.Default.ShindoColor25;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[4].Earthquake.MaxScale == 50)
                {
                    List1_5_1.Image = Resources.quakeback6;
                    List1_5_2.BackColor = Settings.Default.ShindoColor26;
                    List1_5_3.BackColor = Settings.Default.ShindoColor26;
                    List1_5_4.BackColor = Settings.Default.ShindoColor26;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[4].Earthquake.MaxScale == 55)
                {
                    List1_5_1.Image = Resources.quakeback7;
                    List1_5_2.BackColor = Settings.Default.ShindoColor27;
                    List1_5_3.BackColor = Settings.Default.ShindoColor27;
                    List1_5_4.BackColor = Settings.Default.ShindoColor27;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[4].Earthquake.MaxScale == 60)
                {
                    List1_5_1.Image = Resources.quakeback8;
                    List1_5_2.BackColor = Settings.Default.ShindoColor28;
                    List1_5_3.BackColor = Settings.Default.ShindoColor28;
                    List1_5_4.BackColor = Settings.Default.ShindoColor28;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[4].Earthquake.MaxScale == 70)
                {
                    List1_5_1.Image = Resources.quakeback9;
                    List1_5_2.BackColor = Settings.Default.ShindoColor29;
                    List1_5_3.BackColor = Settings.Default.ShindoColor29;
                    List1_5_4.BackColor = Settings.Default.ShindoColor29;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_5_1.Image = Resources.quakeback0;
                    List1_5_2.BackColor = Settings.Default.ShindoColor20;
                    List1_5_3.BackColor = Settings.Default.ShindoColor20;
                    List1_5_4.BackColor = Settings.Default.ShindoColor20;
                    List1_5_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_5_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_5_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[5].Earthquake.MaxScale == 10)
                {
                    List1_6_1.Image = Resources.quakeback1;
                    List1_6_2.BackColor = Settings.Default.ShindoColor21;
                    List1_6_3.BackColor = Settings.Default.ShindoColor21;
                    List1_6_4.BackColor = Settings.Default.ShindoColor21;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[5].Earthquake.MaxScale == 20)
                {
                    List1_6_1.Image = Resources.quakeback2;
                    List1_6_2.BackColor = Settings.Default.ShindoColor22;
                    List1_6_3.BackColor = Settings.Default.ShindoColor22;
                    List1_6_4.BackColor = Settings.Default.ShindoColor22;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[5].Earthquake.MaxScale == 30)
                {
                    List1_6_1.Image = Resources.quakeback3;
                    List1_6_2.BackColor = Settings.Default.ShindoColor23;
                    List1_6_3.BackColor = Settings.Default.ShindoColor23;
                    List1_6_4.BackColor = Settings.Default.ShindoColor23;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[5].Earthquake.MaxScale == 40)
                {
                    List1_6_1.Image = Resources.quakeback4;
                    List1_6_2.BackColor = Settings.Default.ShindoColor24;
                    List1_6_3.BackColor = Settings.Default.ShindoColor24;
                    List1_6_4.BackColor = Settings.Default.ShindoColor24;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[5].Earthquake.MaxScale == 45)
                {
                    List1_6_1.Image = Resources.quakeback5;
                    List1_6_2.BackColor = Settings.Default.ShindoColor25;
                    List1_6_3.BackColor = Settings.Default.ShindoColor25;
                    List1_6_4.BackColor = Settings.Default.ShindoColor25;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[5].Earthquake.MaxScale == 50)
                {
                    List1_6_1.Image = Resources.quakeback6;
                    List1_6_2.BackColor = Settings.Default.ShindoColor26;
                    List1_6_3.BackColor = Settings.Default.ShindoColor26;
                    List1_6_4.BackColor = Settings.Default.ShindoColor26;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[5].Earthquake.MaxScale == 55)
                {
                    List1_6_1.Image = Resources.quakeback7;
                    List1_6_2.BackColor = Settings.Default.ShindoColor27;
                    List1_6_3.BackColor = Settings.Default.ShindoColor27;
                    List1_6_4.BackColor = Settings.Default.ShindoColor27;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[5].Earthquake.MaxScale == 60)
                {
                    List1_6_1.Image = Resources.quakeback8;
                    List1_6_2.BackColor = Settings.Default.ShindoColor28;
                    List1_6_3.BackColor = Settings.Default.ShindoColor28;
                    List1_6_4.BackColor = Settings.Default.ShindoColor28;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[5].Earthquake.MaxScale == 70)
                {
                    List1_6_1.Image = Resources.quakeback9;
                    List1_6_2.BackColor = Settings.Default.ShindoColor29;
                    List1_6_3.BackColor = Settings.Default.ShindoColor29;
                    List1_6_4.BackColor = Settings.Default.ShindoColor29;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_6_1.Image = Resources.quakeback0;
                    List1_6_2.BackColor = Settings.Default.ShindoColor20;
                    List1_6_3.BackColor = Settings.Default.ShindoColor20;
                    List1_6_4.BackColor = Settings.Default.ShindoColor20;
                    List1_6_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_6_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_6_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[6].Earthquake.MaxScale == 10)
                {
                    List1_7_1.Image = Resources.quakeback1;
                    List1_7_2.BackColor = Settings.Default.ShindoColor21;
                    List1_7_3.BackColor = Settings.Default.ShindoColor21;
                    List1_7_4.BackColor = Settings.Default.ShindoColor21;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[6].Earthquake.MaxScale == 20)
                {
                    List1_7_1.Image = Resources.quakeback2;
                    List1_7_2.BackColor = Settings.Default.ShindoColor22;
                    List1_7_3.BackColor = Settings.Default.ShindoColor22;
                    List1_7_4.BackColor = Settings.Default.ShindoColor22;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[6].Earthquake.MaxScale == 30)
                {
                    List1_7_1.Image = Resources.quakeback3;
                    List1_7_2.BackColor = Settings.Default.ShindoColor23;
                    List1_7_3.BackColor = Settings.Default.ShindoColor23;
                    List1_7_4.BackColor = Settings.Default.ShindoColor23;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[6].Earthquake.MaxScale == 40)
                {
                    List1_7_1.Image = Resources.quakeback4;
                    List1_7_2.BackColor = Settings.Default.ShindoColor24;
                    List1_7_3.BackColor = Settings.Default.ShindoColor24;
                    List1_7_4.BackColor = Settings.Default.ShindoColor24;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[6].Earthquake.MaxScale == 45)
                {
                    List1_7_1.Image = Resources.quakeback5;
                    List1_7_2.BackColor = Settings.Default.ShindoColor25;
                    List1_7_3.BackColor = Settings.Default.ShindoColor25;
                    List1_7_4.BackColor = Settings.Default.ShindoColor25;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[6].Earthquake.MaxScale == 50)
                {
                    List1_7_1.Image = Resources.quakeback6;
                    List1_7_2.BackColor = Settings.Default.ShindoColor26;
                    List1_7_3.BackColor = Settings.Default.ShindoColor26;
                    List1_7_4.BackColor = Settings.Default.ShindoColor26;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[6].Earthquake.MaxScale == 55)
                {
                    List1_7_1.Image = Resources.quakeback7;
                    List1_7_2.BackColor = Settings.Default.ShindoColor27;
                    List1_7_3.BackColor = Settings.Default.ShindoColor27;
                    List1_7_4.BackColor = Settings.Default.ShindoColor27;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[6].Earthquake.MaxScale == 60)
                {
                    List1_7_1.Image = Resources.quakeback8;
                    List1_7_2.BackColor = Settings.Default.ShindoColor28;
                    List1_7_3.BackColor = Settings.Default.ShindoColor28;
                    List1_7_4.BackColor = Settings.Default.ShindoColor28;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[6].Earthquake.MaxScale == 70)
                {
                    List1_7_1.Image = Resources.quakeback9;
                    List1_7_2.BackColor = Settings.Default.ShindoColor29;
                    List1_7_3.BackColor = Settings.Default.ShindoColor29;
                    List1_7_4.BackColor = Settings.Default.ShindoColor29;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_7_1.Image = Resources.quakeback0;
                    List1_7_2.BackColor = Settings.Default.ShindoColor20;
                    List1_7_3.BackColor = Settings.Default.ShindoColor20;
                    List1_7_4.BackColor = Settings.Default.ShindoColor20;
                    List1_7_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_7_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_7_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[7].Earthquake.MaxScale == 10)
                {
                    List1_8_1.Image = Resources.quakeback1;
                    List1_8_2.BackColor = Settings.Default.ShindoColor21;
                    List1_8_3.BackColor = Settings.Default.ShindoColor21;
                    List1_8_4.BackColor = Settings.Default.ShindoColor21;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[7].Earthquake.MaxScale == 20)
                {
                    List1_8_1.Image = Resources.quakeback2;
                    List1_8_2.BackColor = Settings.Default.ShindoColor22;
                    List1_8_3.BackColor = Settings.Default.ShindoColor22;
                    List1_8_4.BackColor = Settings.Default.ShindoColor22;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[7].Earthquake.MaxScale == 30)
                {
                    List1_8_1.Image = Resources.quakeback3;
                    List1_8_2.BackColor = Settings.Default.ShindoColor23;
                    List1_8_3.BackColor = Settings.Default.ShindoColor23;
                    List1_8_4.BackColor = Settings.Default.ShindoColor23;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[7].Earthquake.MaxScale == 40)
                {
                    List1_8_1.Image = Resources.quakeback4;
                    List1_8_2.BackColor = Settings.Default.ShindoColor24;
                    List1_8_3.BackColor = Settings.Default.ShindoColor24;
                    List1_8_4.BackColor = Settings.Default.ShindoColor24;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[7].Earthquake.MaxScale == 45)
                {
                    List1_8_1.Image = Resources.quakeback5;
                    List1_8_2.BackColor = Settings.Default.ShindoColor25;
                    List1_8_3.BackColor = Settings.Default.ShindoColor25;
                    List1_8_4.BackColor = Settings.Default.ShindoColor25;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[7].Earthquake.MaxScale == 50)
                {
                    List1_8_1.Image = Resources.quakeback6;
                    List1_8_2.BackColor = Settings.Default.ShindoColor26;
                    List1_8_3.BackColor = Settings.Default.ShindoColor26;
                    List1_8_4.BackColor = Settings.Default.ShindoColor26;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[7].Earthquake.MaxScale == 55)
                {
                    List1_8_1.Image = Resources.quakeback7;
                    List1_8_2.BackColor = Settings.Default.ShindoColor27;
                    List1_8_3.BackColor = Settings.Default.ShindoColor27;
                    List1_8_4.BackColor = Settings.Default.ShindoColor27;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[7].Earthquake.MaxScale == 60)
                {
                    List1_8_1.Image = Resources.quakeback8;
                    List1_8_2.BackColor = Settings.Default.ShindoColor28;
                    List1_8_3.BackColor = Settings.Default.ShindoColor28;
                    List1_8_4.BackColor = Settings.Default.ShindoColor28;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[7].Earthquake.MaxScale == 70)
                {
                    List1_8_1.Image = Resources.quakeback9;
                    List1_8_2.BackColor = Settings.Default.ShindoColor29;
                    List1_8_3.BackColor = Settings.Default.ShindoColor29;
                    List1_8_4.BackColor = Settings.Default.ShindoColor29;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_8_1.Image = Resources.quakeback0;
                    List1_8_2.BackColor = Settings.Default.ShindoColor20;
                    List1_8_3.BackColor = Settings.Default.ShindoColor20;
                    List1_8_4.BackColor = Settings.Default.ShindoColor20;
                    List1_8_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_8_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_8_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[8].Earthquake.MaxScale == 10)
                {
                    List1_9_1.Image = Resources.quakeback1;
                    List1_9_2.BackColor = Settings.Default.ShindoColor21;
                    List1_9_3.BackColor = Settings.Default.ShindoColor21;
                    List1_9_4.BackColor = Settings.Default.ShindoColor21;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[8].Earthquake.MaxScale == 20)
                {
                    List1_9_1.Image = Resources.quakeback2;
                    List1_9_2.BackColor = Settings.Default.ShindoColor22;
                    List1_9_3.BackColor = Settings.Default.ShindoColor22;
                    List1_9_4.BackColor = Settings.Default.ShindoColor22;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[8].Earthquake.MaxScale == 30)
                {
                    List1_9_1.Image = Resources.quakeback3;
                    List1_9_2.BackColor = Settings.Default.ShindoColor23;
                    List1_9_3.BackColor = Settings.Default.ShindoColor23;
                    List1_9_4.BackColor = Settings.Default.ShindoColor23;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[8].Earthquake.MaxScale == 40)
                {
                    List1_9_1.Image = Resources.quakeback4;
                    List1_9_2.BackColor = Settings.Default.ShindoColor24;
                    List1_9_3.BackColor = Settings.Default.ShindoColor24;
                    List1_9_4.BackColor = Settings.Default.ShindoColor24;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[8].Earthquake.MaxScale == 45)
                {
                    List1_9_1.Image = Resources.quakeback5;
                    List1_9_2.BackColor = Settings.Default.ShindoColor25;
                    List1_9_3.BackColor = Settings.Default.ShindoColor25;
                    List1_9_4.BackColor = Settings.Default.ShindoColor25;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[8].Earthquake.MaxScale == 50)
                {
                    List1_9_1.Image = Resources.quakeback6;
                    List1_9_2.BackColor = Settings.Default.ShindoColor26;
                    List1_9_3.BackColor = Settings.Default.ShindoColor26;
                    List1_9_4.BackColor = Settings.Default.ShindoColor26;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[8].Earthquake.MaxScale == 55)
                {
                    List1_9_1.Image = Resources.quakeback7;
                    List1_9_2.BackColor = Settings.Default.ShindoColor27;
                    List1_9_3.BackColor = Settings.Default.ShindoColor27;
                    List1_9_4.BackColor = Settings.Default.ShindoColor27;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[8].Earthquake.MaxScale == 60)
                {
                    List1_9_1.Image = Resources.quakeback8;
                    List1_9_2.BackColor = Settings.Default.ShindoColor28;
                    List1_9_3.BackColor = Settings.Default.ShindoColor28;
                    List1_9_4.BackColor = Settings.Default.ShindoColor28;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[8].Earthquake.MaxScale == 70)
                {
                    List1_9_1.Image = Resources.quakeback9;
                    List1_9_2.BackColor = Settings.Default.ShindoColor29;
                    List1_9_3.BackColor = Settings.Default.ShindoColor29;
                    List1_9_4.BackColor = Settings.Default.ShindoColor29;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_9_1.Image = Resources.quakeback0;
                    List1_9_2.BackColor = Settings.Default.ShindoColor20;
                    List1_9_3.BackColor = Settings.Default.ShindoColor20;
                    List1_9_4.BackColor = Settings.Default.ShindoColor20;
                    List1_9_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_9_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_9_4.ForeColor = Settings.Default.ShindoColor30;
                }
                if (P2PQuake_json[9].Earthquake.MaxScale == 10)
                {
                    List1_10_1.Image = Resources.quakeback1;
                    List1_10_2.BackColor = Settings.Default.ShindoColor21;
                    List1_10_3.BackColor = Settings.Default.ShindoColor21;
                    List1_10_4.BackColor = Settings.Default.ShindoColor21;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor31;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor31;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor31;
                }
                else if (P2PQuake_json[9].Earthquake.MaxScale == 20)
                {
                    List1_10_1.Image = Resources.quakeback2;
                    List1_10_2.BackColor = Settings.Default.ShindoColor22;
                    List1_10_3.BackColor = Settings.Default.ShindoColor22;
                    List1_10_4.BackColor = Settings.Default.ShindoColor22;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor32;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor32;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor32;
                }
                else if (P2PQuake_json[9].Earthquake.MaxScale == 30)
                {
                    List1_10_1.Image = Resources.quakeback3;
                    List1_10_2.BackColor = Settings.Default.ShindoColor23;
                    List1_10_3.BackColor = Settings.Default.ShindoColor23;
                    List1_10_4.BackColor = Settings.Default.ShindoColor23;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor33;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor33;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor33;
                }
                else if (P2PQuake_json[9].Earthquake.MaxScale == 40)
                {
                    List1_10_1.Image = Resources.quakeback4;
                    List1_10_2.BackColor = Settings.Default.ShindoColor24;
                    List1_10_3.BackColor = Settings.Default.ShindoColor24;
                    List1_10_4.BackColor = Settings.Default.ShindoColor24;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor34;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor34;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor34;
                }
                else if (P2PQuake_json[9].Earthquake.MaxScale == 45)
                {
                    List1_10_1.Image = Resources.quakeback5;
                    List1_10_2.BackColor = Settings.Default.ShindoColor25;
                    List1_10_3.BackColor = Settings.Default.ShindoColor25;
                    List1_10_4.BackColor = Settings.Default.ShindoColor25;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor35;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor35;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor35;
                }
                else if (P2PQuake_json[9].Earthquake.MaxScale == 50)
                {
                    List1_10_1.Image = Resources.quakeback6;
                    List1_10_2.BackColor = Settings.Default.ShindoColor26;
                    List1_10_3.BackColor = Settings.Default.ShindoColor26;
                    List1_10_4.BackColor = Settings.Default.ShindoColor26;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor36;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor36;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor36;
                }
                else if (P2PQuake_json[9].Earthquake.MaxScale == 55)
                {
                    List1_10_1.Image = Resources.quakeback7;
                    List1_10_2.BackColor = Settings.Default.ShindoColor27;
                    List1_10_3.BackColor = Settings.Default.ShindoColor27;
                    List1_10_4.BackColor = Settings.Default.ShindoColor27;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor37;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor37;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor37;

                }
                else if (P2PQuake_json[9].Earthquake.MaxScale == 60)
                {
                    List1_10_1.Image = Resources.quakeback8;
                    List1_10_2.BackColor = Settings.Default.ShindoColor28;
                    List1_10_3.BackColor = Settings.Default.ShindoColor28;
                    List1_10_4.BackColor = Settings.Default.ShindoColor28;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor38;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor38;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor38;
                }
                else if (P2PQuake_json[9].Earthquake.MaxScale == 70)
                {
                    List1_10_1.Image = Resources.quakeback9;
                    List1_10_2.BackColor = Settings.Default.ShindoColor29;
                    List1_10_3.BackColor = Settings.Default.ShindoColor29;
                    List1_10_4.BackColor = Settings.Default.ShindoColor29;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor39;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor39;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor39;
                }
                else
                {
                    List1_10_1.Image = Resources.quakeback0;
                    List1_10_2.BackColor = Settings.Default.ShindoColor20;
                    List1_10_3.BackColor = Settings.Default.ShindoColor20;
                    List1_10_4.BackColor = Settings.Default.ShindoColor20;
                    List1_10_2.ForeColor = Settings.Default.ShindoColor30;
                    List1_10_3.ForeColor = Settings.Default.ShindoColor30;
                    List1_10_4.ForeColor = Settings.Default.ShindoColor30;
                }

            }
            //catch
            {

            }
        }

        private void Hinet_Tick(object sender, EventArgs e)
        {

        }

        private void USGS_Tick(object sender, EventArgs e)
        {

        }
    }
}

