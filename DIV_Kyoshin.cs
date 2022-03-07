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
using NAudio;
using Disaster_information_viewer.Properties;
using NAudio.Wave;
using System.Threading;

namespace Disaster_information_viewer
{
    public partial class DIV_Kyoshin : Form
    {
        public DIV_Kyoshin()
        {
            InitializeComponent();
            DIV_EEW Form2;
            Form2 = new DIV_EEW();
            Form2.Show();
            DIV_Earthquakes Form3;
            Form3 = new DIV_Earthquakes();
            Form3.Show();
            /*
            DIV_Tsunami Form4;
            Form4 = new DIV_Tsunami();
            Form4.Show();
            */
            PSWave1.Size = new Size(352, 400);
            PSWave2.Size = new Size(352, 400);

        }

        public void Kyoshin_Tick(object sender, EventArgs e)
        {
            try
            {
                WebClient wc_Kyoshin = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                DateTime DataTime1 = DateTime.Now;
                int DataTime2 = DataTime1.Second - 2;
                long AccessTime1 = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                long AccessTime2 = AccessTime1 - 1;//1秒前
                if (DataTime1.Second == 0)//1:00-0:01=0:99になるため
                {
                    AccessTime2 = Convert.ToInt64(Convert.ToString(Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmm")) - 1) + "59");
                    //2秒前の場合""のかわりに　Convert.ToString(58 + DataTime1.Second)
                }
                long AccessTime3 = AccessTime1 / 1000000;
                string AccessTime4 = AccessTime3 + "/" + AccessTime2;

                string Kyoshin1_URL = "http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/jma_s/" + AccessTime4 + ".jma_s.gif";
                //string Kyoshin1_URL = "http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/jma_s/20220218/20220218115600.jma_s.gif";
                Stream Kyoshin11 = wc_Kyoshin.OpenRead(Kyoshin1_URL);
                Bitmap Kyoshin12 = new Bitmap(Kyoshin11);
                Kyoshin11.Close();
                Kyoshin12.MakeTransparent();
                KyoshinMap1.Image = Kyoshin12;

                string Kyoshin2_URL = "https://www.lmoni.bosai.go.jp/monitor/data/data/map_img/RealTimeImg/abrspmx_s/" + AccessTime4 + ".abrspmx_s.gif";
                Stream Kyoshin21 = wc_Kyoshin.OpenRead(Kyoshin2_URL);
                Bitmap Kyoshin22 = new Bitmap(Kyoshin21);
                Kyoshin21.Close();
                Kyoshin22.MakeTransparent();
                KyoshinMap2.Image = Kyoshin22;

                Color KyoshinColor1 = Kyoshin12.GetPixel(Settings.Default.UserPixelX, Settings.Default.UserPixelY);
                string KyoshinColor12 = KyoshinColor1.R + "," + KyoshinColor1.G + "," + KyoshinColor1.B;
                double PointCalcintensity1 = KyoshinIntDictionary1[KyoshinColor12];
                Chitenmei1.Text = "岐阜県　　岐阜　　";
                Chitenshindo1.Text = (Convert.ToString(PointCalcintensity1) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9").Replace("-5.0", "- - -");
                Color KyoshinColor2 = Kyoshin12.GetPixel(145, 87);
                string KyoshinColor22 = KyoshinColor2.R + "," + KyoshinColor2.G + "," + KyoshinColor2.B;
                double PointCalcintensity2 = KyoshinIntDictionary1[KyoshinColor22];
                Chitenmei2.Text = "鹿児島県　笠利　　";
                Chitenshindo2.Text = (Convert.ToString(PointCalcintensity2) + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9").Replace("-5.0", "- - -");

                string PSwave_URL = "http://www.kmoni.bosai.go.jp/data/map_img/PSWaveImg/eew/" + AccessTime4 + ".eew.gif";
                //string PSwave_URL = "http://www.kmoni.bosai.go.jp/data/map_img/PSWaveImg/eew/20220218/20220218115600.eew.gif";
                WebClient wc_PSWave = new WebClient();
                Stream PSwave1 = wc_PSWave.OpenRead(PSwave_URL);

                Bitmap PSwave2 = new Bitmap(PSwave1);
                
                
                PSwave2.MakeTransparent();
                PSWave1.Image = PSwave2;
                KyoshinMap1.Controls.Add(PSWave1);
                PSWave2.Image = PSwave2;
                KyoshinMap2.Controls.Add(PSWave2);
                PSWave1.BackColor = Color.Transparent;
                PSWave2.BackColor = Color.Transparent;

                PSwave1.Close();
                ErrorText.Text = "";
            }
            catch (Exception exception)
            {
                ErrorText.Text = exception.Message;
            }
        }
        public void ShindouLevel_Tick(object sender, EventArgs e)
        {
            try
            {
                string Level_json;
                using (var wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    Level_json = wc.DownloadString("https://kwatch-24h.net/EQLevel.json");
                }
                var Level_jsondata = JsonConvert.DeserializeObject<Level_json>(Level_json);
                Red.Text = $"{Level_jsondata.R}";
                Yellow.Text = $"{Level_jsondata.Y}";
                Green.Text = $"{Level_jsondata.G}";
                Level.Text = $"Lv.{Level_jsondata.L}";

                AudioFileReader Reader = new AudioFileReader($"Sounds\\null.wav");
                WaveOut Waveout = new WaveOut();
                if (Level_jsondata.L >= 300 && Level_jsondata.L < 1000)
                {
                Reader = new AudioFileReader($"Sounds\\Level\\1.wav");

                }
                else if (Level_jsondata.L >= 1000 && Level_jsondata.L < 2000)
                {
                    Reader = new AudioFileReader($"Sounds\\Level\\2.wav");
                }
                else if (Level_jsondata.L >= 2000)
                {
                    Reader = new AudioFileReader($"Sounds\\Level\\3.wav");
                }
                Waveout.Init(Reader);
                Waveout.Play();
                while (Waveout.PlaybackState != PlaybackState.Playing)
                {
                    Waveout.Dispose();
                    Reader.Dispose();
                    Reader.Close();
                }
            }
            catch
            {

            }
        }
        public Dictionary<string, double> KyoshinIntDictionary1 = new Dictionary<string, double>
        {
{"0,0,0",-5.0},
{"0,0,205",-3.0},
{"0,7,209",-2.9},
{"0,14,214",-2.8},
{"0,21,218",-2.7},
{"0,28,223",-2.6},
{"0,36,227",-2.5},
{"0,43,231",-2.4},
{"0,50,236",-2.3},
{"0,57,240",-2.2},
{"0,64,245",-2.1},
{"0,72,250",-2.0},
{"0,85,238",-1.9},
{"0,99,227",-1.8},
{"0,112,216",-1.7},
{"0,126,205",-1.6},
{"0,140,194",-1.5},
{"0,153,183",-1.4},
{"0,167,172",-1.3},
{"0,180,161",-1.2},
{"0,194,150",-1.1},
{"0,208,139",-1.0},
{"6,212,130",-0.9},
{"12,216,121",-0.8},
{"18,220,113",-0.7},
{"25,224,104",-0.6},
{"31,228,96",-0.5},
{"37,233,88",-0.4},
{"44,237,79",-0.3},
{"50,241,71",-0.2},
{"56,245,62",-0.1},
{"63,250,54",0.0},
{"75,250,49",0.1},
{"88,250,45",0.2},
{"100,251,41",0.3},
{"113,251,37",0.4},
{"125,252,33",0.5},
{"138,252,28",0.6},
{"151,253,24",0.7},
{"163,253,20",0.8},
{"176,254,16",0.9},
{"189,255,12",1.0},
{"195,254,10",1.1},
{"202,254,9",1.2},
{"208,254,8",1.3},
{"215,254,7",1.4},
{"222,255,5",1.5},
{"228,254,4",1.6},
{"235,255,3",1.7},
{"241,254,2",1.8},
{"248,255,1",1.9},
{"255,255,0",2.0},
{"254,251,0",2.1},
{"254,248,0",2.2},
{"254,244,0",2.3},
{"254,241,0",2.4},
{"255,238,0",2.5},
{"254,234,0",2.6},
{"255,231,0",2.7},
{"254,227,0",2.8},
{"255,224,0",2.9},
{"255,221,0",3.0},
{"254,213,0",3.1},
{"254,205,0",3.2},
{"254,197,0",3.3},
{"254,190,0",3.4},
{"255,182,0",3.5},
{"254,174,0",3.6},
{"255,167,0",3.7},
{"254,159,0",3.8},
{"255,151,0",3.9},
{"255,144,0",4.0},
{"254,136,0",4.1},
{"254,128,0",4.2},
{"254,121,0",4.3},
{"254,113,0",4.4},
{"255,106,0",4.5},
{"254,98,0",4.6},
{"255,90,0",4.7},
{"254,83,0",4.8},
{"255,75,0",4.9},
{"255,68,0",5.0},
{"254,61,0",5.1},
{"253,54,0",5.2},
{"252,47,0",5.3},
{"251,40,0",5.4},
{"250,33,0",5.5},
{"249,27,0",5.6},
{"248,20,0",5.7},
{"247,13,0",5.8},
{"246,6,0",5.9},
{"245,0,0",6.0},
{"238,0,0",6.1},
{"230,0,0",6.2},
{"223,0,0",6.3},
{"215,0,0",6.4},
{"208,0,0",6.5},
{"200,0,0",6.6},
{"192,0,0",6.7},
{"185,0,0",6.8},
{"177,0,0",6.9},
{"170,0,0",7.0}
        };
    }
}
