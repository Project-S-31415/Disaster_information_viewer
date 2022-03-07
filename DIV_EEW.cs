using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Disaster_information_viewer.Properties;
using CoreTweet;
using System.Threading;

namespace Disaster_information_viewer
{
    public partial class DIV_EEW : Form
    {
        public DIV_EEW()
        {
            InitializeComponent();
        }
        public void EEW_Tick(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.UTF8
                };

                bool InfoFlag_NIED = false;
                bool InfoFlag_iedred = false;
                
                DateTime DataTime1_NIED = DateTime.Now;
                int DataTime2_NIED = DataTime1_NIED.Second - 2;
                long AccessTime1_NIED = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                long AccessTime2_NIED = AccessTime1_NIED - 1;//1秒前
                if (DataTime1_NIED.Second == 0)//1:00-0:01=0:99になるため
                {
                    AccessTime2_NIED = Convert.ToInt64(Convert.ToString(Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmm")) - 1) + "59");
                    //2秒前の場合""のかわりに　Convert.ToString(58 + DataTime1.Second)
                }
                string EEW_NIED_AccessURL = "http://www.kmoni.bosai.go.jp/webservice/hypo/eew/" + AccessTime2_NIED + ".json";
                //通常
                string eew_nied_json = wc.DownloadString(EEW_NIED_AccessURL);

                //テスト用 EEW予報　震度2
                //string eew_nied_json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20220123095750.json");

                //テスト用　EEW予報 震度不明
                //string eew_nied_json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20210705012355.json");

                //テスト用　EEW警報　2021福島県沖
                //string eew_nied_json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/hypo/eew/20210213231450.json");

                EEW_NIED_json EEW_NIED_json = JsonConvert.DeserializeObject<EEW_NIED_json>(eew_nied_json);


                if (EEW_NIED_json.Alertflg == "予報" || EEW_NIED_json.Alertflg == "警報")
                {
                    InfoFlag_NIED = true;
                    double Lat_NIED = Convert.ToDouble(EEW_NIED_json.Latitude);
                    double Long_NIED = Convert.ToDouble(EEW_NIED_json.Longitude);
                    int MaxCal_int_NIED = Convert.ToInt32(EEW_NIED_json.Calcintensity.Replace("7", "9").Replace("不明", "0").Replace("5弱", "5").Replace("5強", "6").Replace("6弱", "7").Replace("6強", "8"));
                    string MaxCal_str_NIED = Convert.ToString(EEW_NIED_json.Calcintensity).Replace("不明", "0");
                    string Origin_Time_str_NIED = EEW_NIED_json.Origin_time;






                    long Origin_Time_long_NIED = Convert.ToInt64(EEW_NIED_json.Origin_time);
                    int Depth_int_NIED = Convert.ToInt32(EEW_NIED_json.Depth.Replace("km", ""));

                    string Depth_str_NIED = EEW_NIED_json.Depth;
                    double Magunitude_NIED = Convert.ToDouble(EEW_NIED_json.Magunitude);
                    string Region_name_NIED = EEW_NIED_json.Region_name;
                    int Num_NIED = Convert.ToInt32(EEW_NIED_json.Report_num);
                    string Flg_NIED = EEW_NIED_json.Alertflg;

                    bool Final_NIED = EEW_NIED_json.Is_final == "true";
                    bool Plum_NIED = Magunitude_NIED == 1.0;
                    bool TsunamiWarn1_NIED = Magunitude_NIED <= 6.0 && Depth_int_NIED <= 100;
                    bool TsunamiWarn2_NIED = Magunitude_NIED <= 7.5 && Depth_int_NIED <= 50;


                    double Distance1_NIED = double.Parse(Convert.ToString(Settings.Default.UserLatitude - Lat_NIED).Replace("-", "")) * 111.263;
                    double Distance2_NIED = double.Parse(Convert.ToString(Settings.Default.UserLongitude - Long_NIED).Replace("-", "")) * 40075.01668 * Math.Cos((Settings.Default.UserLatitude + Lat_NIED) / 0.0349) / 360;
                    double Distance3_NIED = Math.Sqrt(Distance1_NIED * Distance1_NIED + Distance2_NIED * Distance2_NIED);//---.-------km
                    int Distance4_NIED = (int)Math.Round(Distance3_NIED * 10) / 10;//---km
                    int Distance5_NIED = (int)Math.Round(Distance3_NIED / 10) * 10;//震央距離x0.1→四捨五入→10倍(--0km)

                    if (Settings.Default.Log_RemainingTimeComputation == true)
                    {
                        RTC_JSON savejson1 = new RTC_JSON()
                        {
                            Distance = Distance5_NIED,
                            Origin_time = Origin_Time_long_NIED,
                            Depth = Depth_int_NIED
                        };
                        string savejson2 = JsonConvert.SerializeObject(savejson1);
                        File.WriteAllText($"RemainingTimeComputation.json", savejson2);
                    }
                   
                    //string EEWShindo_URL = "http://www.kmoni.bosai.go.jp/data/map_img/EstShindoImg/eew/20220122/20220122010851.eew.gif";
                    string EEWShindo_URL = "http://www.kmoni.bosai.go.jp/data/map_img/EstShindoImg/eew/" + DateTime.Now.ToString("yyyyMMdd/") + AccessTime2_NIED + ".eew.gif";

                    Stream EEWShindo1 = wc.OpenRead(EEWShindo_URL);
                    Bitmap EEWShindo2 = new Bitmap(EEWShindo1);
                    Color EEWColor1 = EEWShindo2.GetPixel(Settings.Default.UserPixelX, Settings.Default.UserPixelY);//EEWShindoURLをテストにしないとここでエラー(1x1の画像になるため)
                    string EEWColor2 = EEWColor1.R + "," + EEWColor1.G + "," + EEWColor1.B;
                    double CurrectLocationExpectedCalcintensity1 = KyoshinIntDictionary[EEWColor2];
                    EEWShindo1.Close();
                    CurrectLocationExpectedCalcintensity.Text = "現在地予想震度:" + CurrectLocationExpectedCalcintensity1;
                    Distance.Text = "震央距離 約" + Distance4_NIED + "km";

                    string Final_str = "　　";
                    if (Final_NIED == true)
                    {
                        Final_str = "最終";
                    }


                    EEW1.Text = $"EEW　{Flg_NIED}　第{Num_NIED}報　{Final_str}　{Origin_Time_str_NIED}　　　　";
                    EEW2.Text = $"最大震度";
                    EEW3.Text = $"{MaxCal_str_NIED}";
                    EEW4.Text = $"{Region_name_NIED}";
                    EEW5.Text = $"M{Magunitude_NIED}　{Depth_str_NIED}";

                    if (Plum_NIED == true)
                    {
                        EEW5.Text = "PLUM法による予測";
                    }

                    if (Flg_NIED == "予報")
                    {
                        EEW1.BackColor = Color.FromArgb(25, 100, 25);
                        Warn1.BackColor = Color.FromArgb(200, 200, 0);
                        Warn2.BackColor = Color.FromArgb(30, 30, 60);
                        Warn1.Text = "緊急地震速報(予報)　震源付近では揺れに注意";

                    }
                    else if (Flg_NIED == "警報")
                    {
                        EEW1.BackColor = Color.FromArgb(255, 0, 0);
                        Warn1.BackColor = Color.FromArgb(255, 0, 0);
                        Warn2.BackColor = Color.FromArgb(15, 15, 30);
                        Warn1.Text = "緊急地震速報(警報)　強い揺れに警戒";
                        if (TsunamiWarn1_NIED || TsunamiWarn2_NIED)
                        {
                            TsunamiWarn.Text = "津波発生の\n可能性あり";
                        }
                        else
                        {
                            TsunamiWarn.Text = "";
                            TsunamiWarn.BackColor = Color.FromArgb(60, 60, 90);
                        }
                        if (TsunamiWarn1_NIED)
                        {
                            TsunamiWarn.BackColor = Color.Yellow;
                        }
                        if (TsunamiWarn2_NIED)
                        {
                            TsunamiWarn.BackColor = Color.Red;
                        }
                    }
                    if (MaxCal_int_NIED == 0)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor20;
                        EEW2.BackColor = Settings.Default.ShindoColor10;
                        EEW3.BackColor = Settings.Default.ShindoColor10;
                        EEW4.BackColor = Settings.Default.ShindoColor20;
                        EEW5.BackColor = Settings.Default.ShindoColor20;
                        EEW2.ForeColor = Settings.Default.ShindoColor30;
                        EEW3.ForeColor = Settings.Default.ShindoColor30;
                        EEW4.ForeColor = Settings.Default.ShindoColor30;
                        EEW5.ForeColor = Settings.Default.ShindoColor30;
                    }
                    else if (MaxCal_int_NIED == 1)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor21;
                        EEW2.BackColor = Settings.Default.ShindoColor11;
                        EEW3.BackColor = Settings.Default.ShindoColor11;
                        EEW4.BackColor = Settings.Default.ShindoColor21;
                        EEW5.BackColor = Settings.Default.ShindoColor21;
                        EEW2.ForeColor = Settings.Default.ShindoColor31;
                        EEW3.ForeColor = Settings.Default.ShindoColor31;
                        EEW4.ForeColor = Settings.Default.ShindoColor31;
                        EEW5.ForeColor = Settings.Default.ShindoColor31;
                    }
                    else if (MaxCal_int_NIED == 2)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor22;
                        EEW2.BackColor = Settings.Default.ShindoColor12;
                        EEW3.BackColor = Settings.Default.ShindoColor12;
                        EEW4.BackColor = Settings.Default.ShindoColor22;
                        EEW5.BackColor = Settings.Default.ShindoColor22;
                        EEW2.ForeColor = Settings.Default.ShindoColor32;
                        EEW3.ForeColor = Settings.Default.ShindoColor32;
                        EEW4.ForeColor = Settings.Default.ShindoColor32;
                        EEW5.ForeColor = Settings.Default.ShindoColor32;
                    }
                    else if (MaxCal_int_NIED == 3)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor23;
                        EEW2.BackColor = Settings.Default.ShindoColor13;
                        EEW3.BackColor = Settings.Default.ShindoColor13;
                        EEW4.BackColor = Settings.Default.ShindoColor23;
                        EEW5.BackColor = Settings.Default.ShindoColor23;
                        EEW2.ForeColor = Settings.Default.ShindoColor33;
                        EEW3.ForeColor = Settings.Default.ShindoColor33;
                        EEW4.ForeColor = Settings.Default.ShindoColor33;
                        EEW5.ForeColor = Settings.Default.ShindoColor33;
                    }
                    else if (MaxCal_int_NIED == 4)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor24;
                        EEW2.BackColor = Settings.Default.ShindoColor14;
                        EEW3.BackColor = Settings.Default.ShindoColor14;
                        EEW4.BackColor = Settings.Default.ShindoColor24;
                        EEW5.BackColor = Settings.Default.ShindoColor24;
                        EEW2.ForeColor = Settings.Default.ShindoColor34;
                        EEW3.ForeColor = Settings.Default.ShindoColor34;
                        EEW4.ForeColor = Settings.Default.ShindoColor34;
                        EEW5.ForeColor = Settings.Default.ShindoColor34;
                    }
                    else if (MaxCal_int_NIED == 5)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor25;
                        EEW2.BackColor = Settings.Default.ShindoColor15;
                        EEW3.BackColor = Settings.Default.ShindoColor15;
                        EEW4.BackColor = Settings.Default.ShindoColor25;
                        EEW5.BackColor = Settings.Default.ShindoColor25;
                        EEW2.ForeColor = Settings.Default.ShindoColor35;
                        EEW3.ForeColor = Settings.Default.ShindoColor35;
                        EEW4.ForeColor = Settings.Default.ShindoColor35;
                        EEW5.ForeColor = Settings.Default.ShindoColor35;
                    }
                    else if (MaxCal_int_NIED == 6)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor26;
                        EEW2.BackColor = Settings.Default.ShindoColor16;
                        EEW3.BackColor = Settings.Default.ShindoColor16;
                        EEW4.BackColor = Settings.Default.ShindoColor26;
                        EEW5.BackColor = Settings.Default.ShindoColor26;
                        EEW2.ForeColor = Settings.Default.ShindoColor36;
                        EEW3.ForeColor = Settings.Default.ShindoColor36;
                        EEW4.ForeColor = Settings.Default.ShindoColor36;
                        EEW5.ForeColor = Settings.Default.ShindoColor36;
                    }
                    else if (MaxCal_int_NIED == 7)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor27;
                        EEW2.BackColor = Settings.Default.ShindoColor17;
                        EEW3.BackColor = Settings.Default.ShindoColor17;
                        EEW4.BackColor = Settings.Default.ShindoColor27;
                        EEW5.BackColor = Settings.Default.ShindoColor27;
                        EEW2.ForeColor = Settings.Default.ShindoColor37;
                        EEW3.ForeColor = Settings.Default.ShindoColor37;
                        EEW4.ForeColor = Settings.Default.ShindoColor37;
                        EEW5.ForeColor = Settings.Default.ShindoColor37;
                    }
                    else if (MaxCal_int_NIED == 8)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor28;
                        EEW2.BackColor = Settings.Default.ShindoColor18;
                        EEW3.BackColor = Settings.Default.ShindoColor18;
                        EEW4.BackColor = Settings.Default.ShindoColor28;
                        EEW5.BackColor = Settings.Default.ShindoColor28;
                        EEW2.ForeColor = Settings.Default.ShindoColor38;
                        EEW3.ForeColor = Settings.Default.ShindoColor38;
                        EEW4.ForeColor = Settings.Default.ShindoColor38;
                        EEW5.ForeColor = Settings.Default.ShindoColor38;
                    }
                    else if (MaxCal_int_NIED == 9)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor29;
                        EEW2.BackColor = Settings.Default.ShindoColor19;
                        EEW3.BackColor = Settings.Default.ShindoColor19;
                        EEW4.BackColor = Settings.Default.ShindoColor29;
                        EEW5.BackColor = Settings.Default.ShindoColor29;
                        EEW2.ForeColor = Settings.Default.ShindoColor39;
                        EEW3.ForeColor = Settings.Default.ShindoColor39;
                        EEW4.ForeColor = Settings.Default.ShindoColor39;
                        EEW5.ForeColor = Settings.Default.ShindoColor39;
                    }

                }
                //NIED終わり
                Thread.Sleep(1400);
                
                //通常
                string eew_iedred_json = wc.DownloadString("https://api.iedred7584.com/eew/json/");

                //テスト用　EEW警報
                //string eew_iedred_json = File.ReadAllText($"iedred.warn.json");

                EEW_iedred_JSON EEW_iedred_json = JsonConvert.DeserializeObject<EEW_iedred_JSON>(eew_iedred_json);

                long Origin_Time_long_iedred = Convert.ToInt64(EEW_iedred_json.OriginTime.String.Replace("/", "").Replace(":", "").Replace(" ", ""));
                string Origin_Time_str_iedred = EEW_iedred_json.OriginTime.String;
                long NowTime_iedred = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                long ProgressTime_iedred = NowTime_iedred - Origin_Time_long_iedred;
                if (ProgressTime_iedred < 222)
                {
                    InfoFlag_iedred = true;

                    double Lat_iedred = Convert.ToDouble(EEW_iedred_json.Hypocenter.Location.Lat);
                    double Long_iedred = Convert.ToDouble(EEW_iedred_json.Hypocenter.Location.Long);
                    int MaxCal_int_iedred = Convert.ToInt32(EEW_iedred_json.MaxIntensity.String.Replace("7", "9").Replace("不明", "0").Replace("5弱", "5").Replace("5強", "6").Replace("6弱", "7").Replace("6強", "8"));
                    string MaxCal_str_iedred = Convert.ToString(EEW_iedred_json.MaxIntensity.String);

                    int Depth_int_iedred = EEW_iedred_json.Hypocenter.Location.Depth.Int;

                    string Depth_str_iedred = $"{EEW_iedred_json.Hypocenter.Location.Depth.Int}km";
                    double Magunitude_iedred = Convert.ToDouble(EEW_iedred_json.Hypocenter.Magnitude.Float);
                    string Region_name_iedred = EEW_iedred_json.Hypocenter.Name;
                    int Num_iedred = Convert.ToInt32(EEW_iedred_json.Serial);
                    string Flg_iedred = EEW_iedred_json.Title.String.Replace("緊急地震速報（", "").Replace("）", "");



                    bool Final_iedred = EEW_iedred_json.Type.Detail.IndexOf("最終") != -1;
                    bool Plum_iedred = EEW_iedred_json.Hypocenter.IsAssumption == true;
                    bool TsunamiWarn1_iedred = Magunitude_iedred >= 6.0 && Depth_int_iedred <= 100;
                    bool TsunamiWarn2_iedred = Magunitude_iedred >= 7.5 && Depth_int_iedred <= 50;


                    double Distance1_iedred = double.Parse(Convert.ToString(Settings.Default.UserLatitude - Lat_iedred).Replace("-", "")) * 111.263;
                    double Distance2_iedred = double.Parse(Convert.ToString(Settings.Default.UserLongitude - Long_iedred).Replace("-", "")) * 40075.01668 * Math.Cos((Settings.Default.UserLatitude + Lat_iedred) / 0.0349) / 360;
                    double Distance3_iedred = Math.Sqrt(Distance1_iedred * Distance1_iedred + Distance2_iedred * Distance2_iedred);//---.-------km
                    int Distance4_iedred = (int)Math.Round(Distance3_iedred * 10) / 10;//---km
                    int Distance5_iedred = (int)Math.Round(Distance3_iedred / 10) * 10;//--0km

                    if (Depth_int_iedred > 150)
                    {
                        MaxCal_str_iedred = MaxCal_str_iedred.Replace("不明", "-");
                    }
                    else
                    {
                        MaxCal_str_iedred = MaxCal_str_iedred.Replace("不明", "0");
                    }
                    if (Settings.Default.Log_RemainingTimeComputation == true)
                    {
                        RTC_JSON savejson1 = new RTC_JSON()
                        {
                            Distance = Distance5_iedred,
                            Origin_time = Origin_Time_long_iedred,
                            Depth = Depth_int_iedred
                        };
                        string savejson2 = JsonConvert.SerializeObject(savejson1);
                        File.WriteAllText($"RemainingTimeComputation.json", savejson2);
                    }
                    DateTime DataTime1_iedred = DateTime.Now;
                    long AccessTime1_iedred = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    long AccessTime2_iedred = AccessTime1_iedred - 1;//1秒前
                    if (DataTime1_iedred.Second == 0)//1:00-0:01=0:99になるため
                    {
                        AccessTime2_iedred = Convert.ToInt64(Convert.ToString(Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmm")) - 1) + "59");
                        //2秒前の場合""のかわりに　Convert.ToString(58 + DataTime1.Second)
                    }
                    //string EEWShindo_URL = "http://www.kmoni.bosai.go.jp/data/map_img/EstShindoImg/eew/20220122/20220122010851.eew.gif";
                    string EEWShindo_URL = "http://www.kmoni.bosai.go.jp/data/map_img/EstShindoImg/eew/" + DateTime.Now.ToString("yyyyMMdd/") + AccessTime2_iedred + ".eew.gif";

                    Stream EEWShindo1 = wc.OpenRead(EEWShindo_URL);
                    Bitmap EEWShindo2 = new Bitmap(EEWShindo1);
                    Color EEWColor1 = EEWShindo2.GetPixel(Settings.Default.UserPixelX, Settings.Default.UserPixelY);//EEWShindoURLをテストにしないとここでエラー(1x1の画像になるため)
                    string EEWColor2 = EEWColor1.R + "," + EEWColor1.G + "," + EEWColor1.B;
                    double CurrectLocationExpectedCalcintensity1 = KyoshinIntDictionary[EEWColor2];
                    EEWShindo1.Close();
                    CurrectLocationExpectedCalcintensity.Text = "現在地予想震度:" + CurrectLocationExpectedCalcintensity1;
                    Distance.Text = "震央距離 約" + Distance4_iedred + "km";

                    string Final_str = "　　";
                    if (Final_iedred == true)
                    {
                        Final_str = "最終";
                    }


                    EEW1.Text = $"EEW　{Flg_iedred}　第{Num_iedred}報　{Final_str}　{Origin_Time_str_iedred}　　　　";
                    EEW2.Text = $"最大震度";
                    EEW3.Text = $"{MaxCal_str_iedred}";
                    EEW4.Text = $"{Region_name_iedred}";
                    EEW5.Text = $"M{Magunitude_iedred}　{Depth_str_iedred}";

                    if (Plum_iedred == true)
                    {
                        EEW5.Text = "PLUM法による予測";
                    }

                    if (Flg_iedred == "予報")
                    {
                        EEW1.BackColor = Color.FromArgb(25, 100, 25);
                        Warn1.BackColor = Color.FromArgb(200, 200, 0);
                        Warn2.BackColor = Color.FromArgb(30, 30, 60);
                        Warn1.Text = "緊急地震速報(予報)　震源付近では揺れに注意";

                    }
                    else if (Flg_iedred == "警報")
                    {
                        EEW1.BackColor = Color.FromArgb(255, 0, 0);
                        Warn1.BackColor = Color.FromArgb(255, 0, 0);
                        Warn2.BackColor = Color.FromArgb(15, 15, 30);
                        string WarnArea = "　";
                        foreach (string WarnArea_ in EEW_iedred_json.WarnForecast.District)
                        {
                            if (WarnArea.Count() <= 20)
                            {
                                WarnArea = (WarnArea + WarnArea_ + "　").Replace("　　", "");
                            }
                        }
                        Warn1.Text = "緊急地震速報(警報)　強い揺れに警戒";
                        Warn2.Text = WarnArea;

                        if (NowTime_iedred - Origin_Time_long_iedred <= 20)
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


                            string tokens_json = File.ReadAllText($"Tokens.json");

                            Tokens_JSON Tokens_jsondata = JsonConvert.DeserializeObject<Tokens_JSON>(tokens_json);
                            Tokens tokens = Tokens.Create(Tokens_jsondata.ConsumerKey, Tokens_jsondata.ConsumerSecret, Tokens_jsondata.AccessToken, Tokens_jsondata.AccessSecret);
                            string TweetText = "緊急地震速報(警報) 強い揺れに警戒\n" + WarnArea;
                            CoreTweet.Status status = tokens.Statuses.Update(new { status = TweetText });
                        }//TweetTest
                        /*
                        else if (NowTime_iedred - Origin_Time_iedred >= 9999999)
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            string tokens_json = File.ReadAllText($"Tokens.json");

                            Tokens_JSON Tokens_jsondata = JsonConvert.DeserializeObject<Tokens_JSON>(tokens_json);
                            Tokens tokens = Tokens.Create(Tokens_jsondata.ConsumerKey, Tokens_jsondata.ConsumerSecret, Tokens_jsondata.AccessToken, Tokens_jsondata.AccessSecret);
                            string TweetText = "EEWTweetTest";
                            CoreTweet.Status status = tokens.Statuses.Update(new { status = TweetText });
                        }
                        */
                        if (TsunamiWarn1_iedred || TsunamiWarn2_iedred)
                        {
                            TsunamiWarn.Text = "津波発生の\n可能性あり";
                        }
                        else
                        {
                            TsunamiWarn.Text = "";
                            TsunamiWarn.BackColor = Color.FromArgb(60, 60, 90);
                        }
                        if (TsunamiWarn1_iedred)
                        {
                            TsunamiWarn.BackColor = Color.Yellow;
                        }
                        if (TsunamiWarn2_iedred)
                        {
                            TsunamiWarn.BackColor = Color.Red;
                        }
                    }
                    if (MaxCal_int_iedred == 0)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor20;
                        EEW2.BackColor = Settings.Default.ShindoColor10;
                        EEW3.BackColor = Settings.Default.ShindoColor10;
                        EEW4.BackColor = Settings.Default.ShindoColor20;
                        EEW5.BackColor = Settings.Default.ShindoColor20;
                        EEW2.ForeColor = Settings.Default.ShindoColor30;
                        EEW3.ForeColor = Settings.Default.ShindoColor30;
                        EEW4.ForeColor = Settings.Default.ShindoColor30;
                        EEW5.ForeColor = Settings.Default.ShindoColor30;
                    }
                    else if (MaxCal_int_iedred == 1)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor21;
                        EEW2.BackColor = Settings.Default.ShindoColor11;
                        EEW3.BackColor = Settings.Default.ShindoColor11;
                        EEW4.BackColor = Settings.Default.ShindoColor21;
                        EEW5.BackColor = Settings.Default.ShindoColor21;
                        EEW2.ForeColor = Settings.Default.ShindoColor31;
                        EEW3.ForeColor = Settings.Default.ShindoColor31;
                        EEW4.ForeColor = Settings.Default.ShindoColor31;
                        EEW5.ForeColor = Settings.Default.ShindoColor31;
                    }
                    else if (MaxCal_int_iedred == 2)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor22;
                        EEW2.BackColor = Settings.Default.ShindoColor12;
                        EEW3.BackColor = Settings.Default.ShindoColor12;
                        EEW4.BackColor = Settings.Default.ShindoColor22;
                        EEW5.BackColor = Settings.Default.ShindoColor22;
                        EEW2.ForeColor = Settings.Default.ShindoColor32;
                        EEW3.ForeColor = Settings.Default.ShindoColor32;
                        EEW4.ForeColor = Settings.Default.ShindoColor32;
                        EEW5.ForeColor = Settings.Default.ShindoColor32;
                    }
                    else if (MaxCal_int_iedred == 3)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor23;
                        EEW2.BackColor = Settings.Default.ShindoColor13;
                        EEW3.BackColor = Settings.Default.ShindoColor13;
                        EEW4.BackColor = Settings.Default.ShindoColor23;
                        EEW5.BackColor = Settings.Default.ShindoColor23;
                        EEW2.ForeColor = Settings.Default.ShindoColor33;
                        EEW3.ForeColor = Settings.Default.ShindoColor33;
                        EEW4.ForeColor = Settings.Default.ShindoColor33;
                        EEW5.ForeColor = Settings.Default.ShindoColor33;
                    }
                    else if (MaxCal_int_iedred == 4)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor24;
                        EEW2.BackColor = Settings.Default.ShindoColor14;
                        EEW3.BackColor = Settings.Default.ShindoColor14;
                        EEW4.BackColor = Settings.Default.ShindoColor24;
                        EEW5.BackColor = Settings.Default.ShindoColor24;
                        EEW2.ForeColor = Settings.Default.ShindoColor34;
                        EEW3.ForeColor = Settings.Default.ShindoColor34;
                        EEW4.ForeColor = Settings.Default.ShindoColor34;
                        EEW5.ForeColor = Settings.Default.ShindoColor34;
                    }
                    else if (MaxCal_int_iedred == 5)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor25;
                        EEW2.BackColor = Settings.Default.ShindoColor15;
                        EEW3.BackColor = Settings.Default.ShindoColor15;
                        EEW4.BackColor = Settings.Default.ShindoColor25;
                        EEW5.BackColor = Settings.Default.ShindoColor25;
                        EEW2.ForeColor = Settings.Default.ShindoColor35;
                        EEW3.ForeColor = Settings.Default.ShindoColor35;
                        EEW4.ForeColor = Settings.Default.ShindoColor35;
                        EEW5.ForeColor = Settings.Default.ShindoColor35;
                    }
                    else if (MaxCal_int_iedred == 6)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor26;
                        EEW2.BackColor = Settings.Default.ShindoColor16;
                        EEW3.BackColor = Settings.Default.ShindoColor16;
                        EEW4.BackColor = Settings.Default.ShindoColor26;
                        EEW5.BackColor = Settings.Default.ShindoColor26;
                        EEW2.ForeColor = Settings.Default.ShindoColor36;
                        EEW3.ForeColor = Settings.Default.ShindoColor36;
                        EEW4.ForeColor = Settings.Default.ShindoColor36;
                        EEW5.ForeColor = Settings.Default.ShindoColor36;
                    }
                    else if (MaxCal_int_iedred == 7)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor27;
                        EEW2.BackColor = Settings.Default.ShindoColor17;
                        EEW3.BackColor = Settings.Default.ShindoColor17;
                        EEW4.BackColor = Settings.Default.ShindoColor27;
                        EEW5.BackColor = Settings.Default.ShindoColor27;
                        EEW2.ForeColor = Settings.Default.ShindoColor37;
                        EEW3.ForeColor = Settings.Default.ShindoColor37;
                        EEW4.ForeColor = Settings.Default.ShindoColor37;
                        EEW5.ForeColor = Settings.Default.ShindoColor37;
                    }
                    else if (MaxCal_int_iedred == 8)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor28;
                        EEW2.BackColor = Settings.Default.ShindoColor18;
                        EEW3.BackColor = Settings.Default.ShindoColor18;
                        EEW4.BackColor = Settings.Default.ShindoColor28;
                        EEW5.BackColor = Settings.Default.ShindoColor28;
                        EEW2.ForeColor = Settings.Default.ShindoColor38;
                        EEW3.ForeColor = Settings.Default.ShindoColor38;
                        EEW4.ForeColor = Settings.Default.ShindoColor38;
                        EEW5.ForeColor = Settings.Default.ShindoColor38;
                    }
                    else if (MaxCal_int_iedred == 9)
                    {
                        EEW0.BackColor = Settings.Default.ShindoColor29;
                        EEW2.BackColor = Settings.Default.ShindoColor19;
                        EEW3.BackColor = Settings.Default.ShindoColor19;
                        EEW4.BackColor = Settings.Default.ShindoColor29;
                        EEW5.BackColor = Settings.Default.ShindoColor29;
                        EEW2.ForeColor = Settings.Default.ShindoColor39;
                        EEW3.ForeColor = Settings.Default.ShindoColor39;
                        EEW4.ForeColor = Settings.Default.ShindoColor39;
                        EEW5.ForeColor = Settings.Default.ShindoColor39;
                    }


                }
                if (InfoFlag_NIED == false && InfoFlag_iedred == false)
                {
                    EEW1.Text = $"緊急地震速報　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　";
                    EEW2.Text = $"";
                    EEW3.Text = $"";
                    EEW4.Text = $"";
                    EEW5.Text = $"";
                    RemainingTime.Text = "";
                    Distance.Text = "";
                    EEW0.BackColor = Color.FromArgb(30, 30, 60);
                    EEW1.BackColor = Color.FromArgb(45, 45, 90);
                    EEW2.BackColor = Color.FromArgb(30, 30, 60);
                    EEW3.BackColor = Color.FromArgb(30, 30, 60);
                    EEW4.BackColor = Color.FromArgb(30, 30, 60);
                    EEW5.BackColor = Color.FromArgb(30, 30, 60);
                    EEW1.ForeColor = Color.White;
                    Warn1.BackColor = Color.FromArgb(30, 30, 60);
                    Warn2.BackColor = Color.FromArgb(30, 30, 60);
                }
            }
            catch (WebException)
            {
            }
        }



        public Dictionary<string, double> KyoshinIntDictionary = new Dictionary<string, double>
        {

{"0,0,0",-3.0},
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
