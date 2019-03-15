using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odds_Grabber___sg88win
{
    public partial class Main_Form : Form
    {
        private string __app = "Odds Grabber";
        private string __app_type = "{edit this}";
        private string __brand_code = "{edit this}";
        private string __brand_color = "#4F0005";
        private string __url = "www.sg88win.com";
        private string __website_name = "sg88win";
        private string __app__website_name = "";
        private string __api_key = "youdieidie";
        private string __running_01 = "s";
        private string __running_02 = "m";
        private string __running_11 = "S-Sports";
        private string __running_22 = "M-Sports";
        private int __send = 0;
        private int __r = 79;
        private int __g = 0;
        private int __b = 5;
        private bool __is_close;
        private bool __is_login = false;
        private bool __is_send = true;
        Form __mainFormHandler;

        // Drag Header to Move
        private bool m_aeroEnabled;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        // ----- Drag Header to Move

        // Form Shadow
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int CS_DBLCLKS = 0x8;
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
                m.Result = (IntPtr)HTCAPTION;
        }
        // ----- Form Shadow

        public Main_Form()
        {
            InitializeComponent();

            timer_landing.Start();
        }

        // Drag to Move
        private void panel_header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBox_loader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_brand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel_landing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBox_landing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // ----- Drag to Move

        // Click Close
        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Exit the program?", __app__website_name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                __is_close = true;
                //Environment.Exit(0);
            }
        }

        // Click Minimize
        private void pictureBox_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer_landing_Tick(object sender, EventArgs e)
        {
            panel_landing.Visible = false;
            webBrowser.Visible = false;
            pictureBox_loader.Visible = true;
            label_page_count.Visible = true;
            label_currentrecord.Visible = true;
            __mainFormHandler = Application.OpenForms[0];
            __mainFormHandler.Size = new Size(466, 168);
            timer_landing.Stop();
        }

        private void SendMyBot(string message)
        {
            try
            {
                string datetime = DateTime.Now.ToString("dd MMM HH:mm:ss");
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "772918363:AAHn2ufmP3ocLEilQ1V-IHcqYMcSuFJHx5g";
                string chatId = "@allandrake";
                string text = "-----" + __app__website_name + "-----%0A%0AIP:%20ABC PC%0ALocation:%20Pacific%20Star%0ADate%20and%20Time:%20[" + datetime + "]%0AMessage:%20" + message;
                urlString = String.Format(urlString, apiToken, chatId, text);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs);
                string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    __is_close = false;
                    //Process.Start(Application.ExecutablePath);
                    //Environment.Exit(0);
                }
                else
                {
                    __is_close = false;
                    //Environment.Exit(0);
                }
            }
        }
        
        private void SendABCTeam(string message)
        {
            try
            {
                string datetime = DateTime.Now.ToString("dd MMM HH:mm:ss");
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "651945130:AAGMFj-C4wX0yElG2dBU1SRbfrNZi75jPHg";
                string chatId = "@odds_bot_abc_team";
                string text = "Bot:%20-----SG88WIN-----%0ADate%20and%20Time:%20[" + datetime + "]%0AMessage:%20<b>" + message + "</>&parse_mode=html";
                urlString = String.Format(urlString, apiToken, chatId, text);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs);
                string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    __is_close = false;
                    //Process.Start(Application.ExecutablePath);
                    //Environment.Exit(0);
                }
                else
                {
                    __is_close = false;
                    //Environment.Exit(0);
                }
            }
        }

        private void label_player_last_bill_no_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Visible = true;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Visible = false;
        }

        private void timer_flush_memory_Tick(object sender, EventArgs e)
        {
            ___FlushMemory();
        }

        public static void ___FlushMemory()
        {
            Process prs = Process.GetCurrentProcess();
            try
            {
                prs.MinWorkingSet = (IntPtr)(300000);
            }
            catch (Exception err)
            {
                // leave blank
            }
        }

        private void timer_detect_running_Tick(object sender, EventArgs e)
        {
            //___DetectRunning();
        }

        private void ___DetectRunning()
        {
            try
            {
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string password = __brand_code + datetime + "youdieidie";
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string token = BitConverter.ToString(hash)
                   .Replace("-", string.Empty)
                   .ToLower();

                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection
                    {
                        ["brand_code"] = __brand_code,
                        ["app_type"] = __app_type,
                        ["last_update"] = datetime,
                        ["token"] = token
                    };

                    var response = wb.UploadValues("http://192.168.10.252:8080/API/updateAppStatus", "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                }
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    SendMyBot(err.ToString());
                    
                    __is_close = false;
                    //Process.Start(Application.ExecutablePath);
                    //Environment.Exit(0);
                }
                else
                {
                    __is_close = false;
                    //Environment.Exit(0);
                }
            }
        }

        private void ___DetectRunning2()
        {
            try
            {
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string password = __brand_code + datetime + "youdieidie";
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string token = BitConverter.ToString(hash)
                   .Replace("-", string.Empty)
                   .ToLower();

                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection
                    {
                        ["brand_code"] = __brand_code,
                        ["app_type"] = __app_type,
                        ["last_update"] = datetime,
                        ["token"] = token
                    };

                    var response = wb.UploadValues("http://zeus.ssitex.com:8080/API/updateAppStatus", "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                }
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    SendMyBot(err.ToString());

                    __is_close = false;
                    //Process.Start(Application.ExecutablePath);
                    //Environment.Exit(0);
                }
                else
                {
                    __is_close = false;
                    //Environment.Exit(0);
                }
            }
        }
        
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            if (__is_send)
            {
                __is_send = false;
                MessageBox.Show("Telegram Notification is Disabled.", __brand_code + " " + __app, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                __is_send = true;
                MessageBox.Show("Telegram Notification is Enabled.", __brand_code + " " + __app, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ___WaitNSeconds(int sec)
        {
            if (sec < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(sec);
            while (DateTime.Now < _desired)
            {
                Application.DoEvents();
            }
        }

        // Form Closing
        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!__is_close)
            {
                DialogResult dr = MessageBox.Show("Exit the program?", __app__website_name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    //Environment.Exit(0);
                }
            }
            else
            {
                //Environment.Exit(0);
            }
        }

        // Form Load
        private void Main_Form_Load(object sender, EventArgs e)
        {
            __app__website_name = __app + " - " + __website_name;
            panel1.BackColor = Color.FromArgb(__r, __g, __b);
            panel2.BackColor = Color.FromArgb(__r, __g, __b);
            label_brand.BackColor = Color.FromArgb(__r, __g, __b);
            Text = __app__website_name;
            label_title.Text = __app__website_name;

            webBrowser.Navigate(__url);
        }

        // WebBrowser
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = true;

            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                if (e.Url == webBrowser.Url)
                {
                    try
                    {
                        if (webBrowser.Url.ToString().Equals("http://sg88win.com/"))
                        {
                            //if (__is_login)
                            //{
                            //    pictureBox_loader.Visible = false;
                            //    label_page_count.Visible = false;
                            //    label_currentrecord.Visible = false;
                            //    __mainFormHandler = Application.OpenForms[0];
                            //    __mainFormHandler.Size = new Size(466, 468);

                            //    SendMyBot("The application have been logout, please re-login again.");
                            //    __send = 0;
                            //}

                            __is_login = false;
                            timer.Stop();
                            HtmlElementCollection htmlcol = webBrowser.Document.GetElementsByTagName("input");
                            for (int i = 0; i < htmlcol.Count; i++)
                            {
                                if (htmlcol[i].OuterHtml.Contains("UserID"))
                                {
                                    htmlcol[i].SetAttribute("value", "nasrii042318");
                                }
                                
                                if (htmlcol[i].OuterHtml.Contains("Password"))
                                {
                                    htmlcol[i].SetAttribute("value", "AAaa1111");
                                }
                            }
                            webBrowser.Visible = true;
                            webBrowser.WebBrowserShortcutsEnabled = true;
                            webBrowser.Document.GetElementById("remoteloginformsubmit").InvokeMember("Click");
                        }
                        
                        if (webBrowser.Url.ToString().Equals("http://mem.sghuatchai.com/Member/?lang=en") || webBrowser.Url.ToString().Equals("http://mem.sghuatchai.com/Public/Maintenance"))
                        {
                            //label_brand.Visible = true;
                            //pictureBox_loader.Visible = true;
                            //label_page_count.Visible = true;
                            //label_currentrecord.Visible = true;
                            //__mainFormHandler = Application.OpenForms[0];
                            //__mainFormHandler.Size = new Size(466, 168);

                            if (!__is_login)
                            {
                                if (webBrowser.Url.ToString().Equals("http://mem.sghuatchai.com/Public/Maintenance"))
                                {
                                    SendABCTeam("Under Maintenance!");
                                }


                                __is_login = true;
                                webBrowser.Visible = false;
                                pictureBox_loader.Visible = true;
                                webBrowser.WebBrowserShortcutsEnabled = false;

                                SendABCTeam("Firing up!");


                                Task task_01 = new Task(delegate { ___SSPORTS_RUNNINGAsync(); });
                                task_01.Start();
                                Task task_02 = new Task(delegate { ___MSPORTS_RUNNINGAsync(); });
                                task_02.Start();
                            }
                        }

                        if (webBrowser.Url.ToString().ToLower().Contains("error"))
                        {
                            SendMyBot("Website Error.");

                            __is_close = false;
                            //Environment.Exit(0);
                        }
                    }
                    catch (Exception err)
                    {
                        if (___CheckForInternetConnection())
                        {
                            SendMyBot(err.ToString());

                            __is_close = false;
                            //Process.Start(Application.ExecutablePath);
                            //Environment.Exit(0);
                        }
                        else
                        {
                            __is_close = false;
                            //Environment.Exit(0);
                        }
                    }
                }
            }
        }
        
        // S-SPORTS -----
        private void ___SSPORTS_RUNNINGAsync()
        {
            Invoke(new Action(() =>
            {
                panel3.BackColor = Color.FromArgb(0, 255, 0);
            }));

            try
            {
                string source_name = __website_name + __running_01;
                var cookie = Cookie.GetCookieInternal(webBrowser.Url, false);
                WebClient wc = new WebClient();
                wc.Headers.Add("Cookie", cookie);
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                int _epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                
                byte[] result = wc.DownloadData("https://hv.link333.com/odds/GetOtherSportOdds?=" + _epoch + "&uid=m0101nasrii042318&sportID=1&sortbyTime=false&leagues=&matches=&dateAdd=&oddsGroup=A&marketID=1&fixDate=true&lang=en");
                string responsebody = Encoding.UTF8.GetString(result);
                var deserialize_object = JsonConvert.DeserializeObject(responsebody);
                JObject _jo = JObject.Parse(deserialize_object.ToString());
                JToken _count = _jo.SelectToken("$.RunningMatches");

                if (_count.Count() > 0)
                {
                    for (int i = 0; i < _count.Count(); i++)
                    {
                        JToken LeagueName = _jo.SelectToken("$.RunningMatches[" + i + "].LeagueName").ToString();
                        JToken AwayScore = _jo.SelectToken("$.RunningMatches[" + i + "].AwayScore").ToString();
                        JToken AwayTeamName = _jo.SelectToken("$.RunningMatches[" + i + "].AwayTeamName").ToString();
                        JToken HomeScore = _jo.SelectToken("$.RunningMatches[" + i + "].HomeScore").ToString();
                        JToken HomeTeamName = _jo.SelectToken("$.RunningMatches[" + i + "].HomeTeamName").ToString();
                        JToken StatementDate = _jo.SelectToken("$.RunningMatches[" + i + "].StatementDate").ToString();
                        JToken MatchID = _jo.SelectToken("$.RunningMatches[" + i + "].MatchID").ToString();
                        DateTime StatementDate_Replace = DateTime.ParseExact(StatementDate.ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).AddHours(20);
                        StatementDate = StatementDate_Replace.ToString("yyyy-MM-dd HH:mm:ss");

                        JToken FTHDP = _jo.SelectToken("$.RunningMatches[" + i + "].FTHDP").ToString();
                        JToken FTH = _jo.SelectToken("$.RunningMatches[" + i + "].FTH").ToString();
                        JToken FTA = _jo.SelectToken("$.RunningMatches[" + i + "].FTA").ToString();
                        JToken BetIDFTOU = _jo.SelectToken("$.RunningMatches[" + i + "].BetIDFTOU").ToString();
                        JToken FTOU = _jo.SelectToken("$.RunningMatches[" + i + "].FTOU").ToString();
                        JToken FTO = _jo.SelectToken("$.RunningMatches[" + i + "].FTO").ToString();
                        JToken FTU = _jo.SelectToken("$.RunningMatches[" + i + "].FTU").ToString();
                        JToken BetIDFTOE = _jo.SelectToken("$.RunningMatches[" + i + "].BetIDFTOE").ToString();
                        JToken FTOdd = _jo.SelectToken("$.RunningMatches[" + i + "].FTOdd").ToString();
                        JToken FTEven = _jo.SelectToken("$.RunningMatches[" + i + "].FTEven").ToString();
                        JToken BetIDFT1X2 = _jo.SelectToken("$.RunningMatches[" + i + "].BetIDFT1X2").ToString();
                        JToken FT1 = _jo.SelectToken("$.RunningMatches[" + i + "].FT1").ToString();
                        JToken FTX = _jo.SelectToken("$.RunningMatches[" + i + "].FTX").ToString();
                        JToken FT2 = _jo.SelectToken("$.RunningMatches[" + i + "].FT2").ToString();
                        JToken SpecialGame = _jo.SelectToken("$.RunningMatches[" + i + "].SpecialGame").ToString();
                        JToken FHHDP = _jo.SelectToken("$.RunningMatches[" + i + "].FHHDP").ToString();
                        JToken FHH = _jo.SelectToken("$.RunningMatches[" + i + "].FHH").ToString();
                        JToken FHA = _jo.SelectToken("$.RunningMatches[" + i + "].FHA").ToString();
                        JToken FHOU = _jo.SelectToken("$.RunningMatches[" + i + "].FHOU").ToString();
                        JToken FHO = _jo.SelectToken("$.RunningMatches[" + i + "].FHO").ToString();
                        JToken FHU = _jo.SelectToken("$.RunningMatches[" + i + "].FHU").ToString();
                        JToken FHOdd = _jo.SelectToken("$.RunningMatches[" + i + "].FHOdd").ToString();
                        JToken FHEven = _jo.SelectToken("$.RunningMatches[" + i + "].FHEven").ToString();
                        JToken FH1 = _jo.SelectToken("$.RunningMatches[" + i + "].FH1").ToString();
                        JToken FHX = _jo.SelectToken("$.RunningMatches[" + i + "].FHX").ToString();
                        JToken FH2 = _jo.SelectToken("$.RunningMatches[" + i + "].FH2").ToString();

                        string password = __website_name + __running_01 + __api_key;
                        byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                        byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                        string token = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

                        var reqparm_ = new NameValueCollection
                        {
                            {"source_id", "1"},
                            {"sport_name", "Soccer"},
                            {"league_name", LeagueName.ToString()},
                            {"home_team", HomeTeamName.ToString()},
                            {"away_team", AwayTeamName.ToString()},
                            {"ref_match_id", MatchID.ToString()},
                            {"token_api", token},
                        };

                        byte[] result_ = wc.UploadValues("http://oddsgrabber.ssitex.com/API/sendOdds", "POST", reqparm_);
                        string responsebody_ = Encoding.UTF8.GetString(result_);
                    }
                }
                else
                {
                    Properties.Settings.Default.______odds_iswaiting_01 = true;
                    Properties.Settings.Default.Save();
                }

                ___SSPORTS_NOTRUNNINGAsync();
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    Properties.Settings.Default.______odds_iswaiting_01 = true;
                    Properties.Settings.Default.Save();
                    
                    if (err.ToString().Contains("(50"))
                    {
                        string datetime = DateTime.Now.AddHours(1).ToString("HH");
                        
                        if (Properties.Settings.Default.______odds_nextalert_01 == "")
                        {
                            Properties.Settings.Default.______odds_nextalert_01 = datetime;
                            Properties.Settings.Default.Save();
                            SendABCTeam(__running_11 + " Under Maintenance.");
                        }
                        else
                        {
                            DateTime _date_from;
                            DateTime _date_to;
                            Properties.Settings.Default.______odds_nextalert_01 = datetime + ":00:00";
                            Properties.Settings.Default.Save();
                            string _date_from_ = Properties.Settings.Default.______odds_nextalert_01;
                            string _date_to_ = DateTime.Now.ToString("HH:00:00");

                            if (DateTime.TryParse(_date_from_, out _date_from) && DateTime.TryParse(_date_to_, out _date_to))
                            {
                                TimeSpan _ts = _date_to - _date_from;
                                int _hour = _ts.Hours;
                                if (Convert.ToInt32(_hour.ToString("0")) == 0 || Convert.ToInt32(_hour.ToString("0")) > 0)
                                {
                                    Properties.Settings.Default.______odds_nextalert_01 = datetime;
                                    Properties.Settings.Default.Save();
                                    SendABCTeam(__running_11 + " Under Maintenance.");
                                }
                            }
                        }

                        ___SSPORTS_RUNNINGAsync();
                    }

                    SendMyBot(err.ToString());

                    __is_close = false;
                    //Process.Start(Application.ExecutablePath);
                    //Environment.Exit(0);
                }
                else
                {
                    __is_close = false;
                    //Environment.Exit(0);
                }
            }
        }

        private async void ___SSPORTS_NOTRUNNINGAsync()
        {
            try
            {
                string source_name = __website_name + __running_01;
                var cookie = Cookie.GetCookieInternal(webBrowser.Url, false);
                WebClient wc = new WebClient();
                wc.Headers.Add("Cookie", cookie);
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                int _epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                
                byte[] result = wc.DownloadData("https://hv.link333.com/odds/GetOtherSportTodayOdds?=" + _epoch + "&uid=m0101nasrii042318&sportID=1&sortbyTime=false&leagues=&matches=&runningLeagues=&oddsGroup=A&lang=en");
                string responsebody = Encoding.UTF8.GetString(result);
                var deserialize_object = JsonConvert.DeserializeObject(responsebody);
                JObject _jo = JObject.Parse(deserialize_object.ToString());
                JToken _count = _jo.SelectToken("$.Matches");

                if (_count.Count() > 0)
                {
                    for (int i = 0; i < _count.Count(); i++)
                    {
                        JToken LeagueName = _jo.SelectToken("$.Matches[" + i + "].LeagueName").ToString();
                        JToken AwayScore = _jo.SelectToken("$.Matches[" + i + "].AwayScore").ToString();
                        JToken AwayTeamName = _jo.SelectToken("$.Matches[" + i + "].AwayTeamName").ToString();
                        JToken HomeScore = _jo.SelectToken("$.Matches[" + i + "].HomeScore").ToString();
                        JToken HomeTeamName = _jo.SelectToken("$.Matches[" + i + "].HomeTeamName").ToString();
                        JToken StatementDate = _jo.SelectToken("$.Matches[" + i + "].StatementDate").ToString();
                        JToken MatchID = _jo.SelectToken("$.RunningMatches[" + i + "].MatchID").ToString();
                        DateTime StatementDate_Replace = DateTime.ParseExact(StatementDate.ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).AddHours(20);
                        StatementDate = StatementDate_Replace.ToString("yyyy-MM-dd HH:mm:ss");

                        JToken FTHDP = _jo.SelectToken("$.Matches[" + i + "].FTHDP").ToString();
                        JToken FTH = _jo.SelectToken("$.Matches[" + i + "].FTH").ToString();
                        JToken FTA = _jo.SelectToken("$.Matches[" + i + "].FTA").ToString();
                        JToken BetIDFTOU = _jo.SelectToken("$.Matches[" + i + "].BetIDFTOU").ToString();
                        JToken FTOU = _jo.SelectToken("$.Matches[" + i + "].FTOU").ToString();
                        JToken FTO = _jo.SelectToken("$.Matches[" + i + "].FTO").ToString();
                        JToken FTU = _jo.SelectToken("$.Matches[" + i + "].FTU").ToString();
                        JToken BetIDFTOE = _jo.SelectToken("$.Matches[" + i + "].BetIDFTOE").ToString();
                        JToken FTOdd = _jo.SelectToken("$.Matches[" + i + "].FTOdd").ToString();
                        JToken FTEven = _jo.SelectToken("$.Matches[" + i + "].FTEven").ToString();
                        JToken BetIDFT1X2 = _jo.SelectToken("$.Matches[" + i + "].BetIDFT1X2").ToString();
                        JToken FT1 = _jo.SelectToken("$.Matches[" + i + "].FT1").ToString();
                        JToken FTX = _jo.SelectToken("$.Matches[" + i + "].FTX").ToString();
                        JToken FT2 = _jo.SelectToken("$.Matches[" + i + "].FT2").ToString();
                        JToken SpecialGame = _jo.SelectToken("$.Matches[" + i + "].SpecialGame").ToString();
                        JToken FHHDP = _jo.SelectToken("$.Matches[" + i + "].FHHDP").ToString();
                        JToken FHH = _jo.SelectToken("$.Matches[" + i + "].FHH").ToString();
                        JToken FHA = _jo.SelectToken("$.Matches[" + i + "].FHA").ToString();
                        JToken FHOU = _jo.SelectToken("$.Matches[" + i + "].FHOU").ToString();
                        JToken FHO = _jo.SelectToken("$.Matches[" + i + "].FHO").ToString();
                        JToken FHU = _jo.SelectToken("$.Matches[" + i + "].FHU").ToString();
                        JToken FHOdd = _jo.SelectToken("$.Matches[" + i + "].FHOdd").ToString();
                        JToken FHEven = _jo.SelectToken("$.Matches[" + i + "].FHEven").ToString();
                        JToken FH1 = _jo.SelectToken("$.Matches[" + i + "].FH1").ToString();
                        JToken FHX = _jo.SelectToken("$.Matches[" + i + "].FHX").ToString();
                        JToken FH2 = _jo.SelectToken("$.Matches[" + i + "].FH2").ToString();

                        string password = __website_name + __running_01 + __api_key;
                        byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                        byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                        string token = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

                        var reqparm_ = new NameValueCollection
                        {
                            {"source_id", "1"},
                            {"sport_name", "Soccer"},
                            {"league_name", LeagueName.ToString()},
                            {"home_team", HomeTeamName.ToString()},
                            {"away_team", AwayTeamName.ToString()},
                            {"ref_match_id", MatchID.ToString()},
                            {"token_api", token},
                        };

                        byte[] result_ = wc.UploadValues("http://oddsgrabber.ssitex.com/API/sendOdds", "POST", reqparm_);
                        string responsebody_ = Encoding.UTF8.GetString(result_);
                    }
                }
                else
                {
                    Properties.Settings.Default.______odds_iswaiting_01 = true;
                    Properties.Settings.Default.Save();
                }

                // send ssports 
                if (Properties.Settings.Default.______odds_nextalert_01 != "")
                {
                    if (!Properties.Settings.Default.______odds_iswaiting_01)
                    {
                        Properties.Settings.Default.______odds_nextalert_01 = "";
                        Properties.Settings.Default.Save();
                        SendABCTeam(__running_11 + " Back to Normal.");
                    }
                }

                Properties.Settings.Default.______odds_iswaiting_01 = false;
                Properties.Settings.Default.Save();
                
                Invoke(new Action(() =>
                {
                    panel3.BackColor = Color.FromArgb(16, 90, 101);
                }));
                await ___TaskWait();
                ___SSPORTS_RUNNINGAsync();
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    Properties.Settings.Default.______odds_iswaiting_01 = true;
                    Properties.Settings.Default.Save();

                    if (err.ToString().Contains("(50"))
                    {
                        string datetime = DateTime.Now.AddHours(1).ToString("HH");

                        if (Properties.Settings.Default.______odds_nextalert_01 == "")
                        {
                            Properties.Settings.Default.______odds_nextalert_01 = datetime;
                            Properties.Settings.Default.Save();
                            SendABCTeam(__running_11 + " Under Maintenance.");
                        }
                        else
                        {
                            DateTime _date_from;
                            DateTime _date_to;
                            Properties.Settings.Default.______odds_nextalert_01 = datetime + ":00:00";
                            Properties.Settings.Default.Save();
                            string _date_from_ = Properties.Settings.Default.______odds_nextalert_01;
                            string _date_to_ = DateTime.Now.ToString("HH:00:00");

                            if (DateTime.TryParse(_date_from_, out _date_from) && DateTime.TryParse(_date_to_, out _date_to))
                            {
                                TimeSpan _ts = _date_to - _date_from;
                                int _hour = _ts.Hours;
                                if (Convert.ToInt32(_hour.ToString("0")) == 0 || Convert.ToInt32(_hour.ToString("0")) > 0)
                                {
                                    Properties.Settings.Default.______odds_nextalert_01 = datetime;
                                    Properties.Settings.Default.Save();
                                    SendABCTeam(__running_11 + " Under Maintenance.");
                                }
                            }
                        }

                        ___SSPORTS_NOTRUNNINGAsync();
                    }
                    
                    SendMyBot(err.ToString());

                    __is_close = false;
                    //Process.Start(Application.ExecutablePath);
                    //Environment.Exit(0);
                }
                else
                {
                    __is_close = false;
                    //Environment.Exit(0);
                }
            }
        }

        // M-SPORTS -----
        private void ___MSPORTS_RUNNINGAsync()
        {
            Invoke(new Action(() =>
            {
                panel4.BackColor = Color.FromArgb(0, 255, 0);
            }));

            try
            {
                string source_name = __website_name + "m";
                var cookie = Cookie.GetCookieInternal(webBrowser.Url, false);
                WebClient wc = new WebClient();
                wc.Headers.Add("Cookie", cookie);
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Headers["X-Requested-With"] = "XMLHttpRequest";
                int _epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

                var reqparm = new NameValueCollection
                {
                    {"ov", "0"},
                    {"ot", "r"},
                    {"tf", "-1"},
                    {"TFStatus", "0"},
                    {"update", "false"},
                    {"r", "414130387"},
                    {"mt", "0"},
                    {"wd", ""},
                    {"ia", "0"},
                    {"t", _epoch.ToString()},
                };
                
                byte[] result = wc.UploadValues("https://jcak002d.mywinday.com/_view/Odds2GenRun.aspx?", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(result);

                ___MSPORTS_NOTRUNNINGAsync();
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    Properties.Settings.Default.______odds_iswaiting_01 = true;
                    Properties.Settings.Default.Save();

                    if (err.ToString().Contains("(50"))
                    {
                        string datetime = DateTime.Now.AddHours(1).ToString("HH");

                        if (Properties.Settings.Default.______odds_nextalert_02 == "")
                        {
                            Properties.Settings.Default.______odds_nextalert_02 = datetime;
                            Properties.Settings.Default.Save();
                            SendABCTeam(__running_22 + " Under Maintenance.");
                        }
                        else
                        {
                            DateTime _date_from;
                            DateTime _date_to;
                            Properties.Settings.Default.______odds_nextalert_02 = datetime + ":00:00";
                            Properties.Settings.Default.Save();
                            string _date_from_ = Properties.Settings.Default.______odds_nextalert_02;
                            string _date_to_ = DateTime.Now.ToString("HH:00:00");

                            if (DateTime.TryParse(_date_from_, out _date_from) && DateTime.TryParse(_date_to_, out _date_to))
                            {
                                TimeSpan _ts = _date_to - _date_from;
                                int _hour = _ts.Hours;
                                if (Convert.ToInt32(_hour.ToString("0")) == 0 || Convert.ToInt32(_hour.ToString("0")) > 0)
                                {
                                    Properties.Settings.Default.______odds_nextalert_02 = datetime;
                                    Properties.Settings.Default.Save();
                                    SendABCTeam(__running_22 + " Under Maintenance.");
                                }
                            }
                        }

                        ___MSPORTS_RUNNINGAsync();
                    }

                    SendMyBot(err.ToString());

                    __is_close = false;
                    //Process.Start(Application.ExecutablePath);
                    //Environment.Exit(0);
                }
                else
                {
                    __is_close = false;
                    //Environment.Exit(0);
                }
            }
        }
        
        private async void ___MSPORTS_NOTRUNNINGAsync()
        {
            try
            {
                string source_name = __website_name + "m";
                var cookie = Cookie.GetCookieInternal(webBrowser.Url, false);
                WebClient wc = new WebClient();
                wc.Headers.Add("Cookie", cookie);
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Headers["X-Requested-With"] = "XMLHttpRequest";
                int _epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

                var reqparm = new NameValueCollection
                {
                    {"ov", "0"},
                    {"ot", "t"},
                    {"tf", "-1"},
                    {"TFStatus", "0"},
                    {"update", "false"},
                    {"r", "414130387"},
                    {"mt", "0"},
                    {"wd", ""},
                    {"ia", "0"},
                    {"t", _epoch.ToString()},
                };
                
                byte[] result = wc.UploadValues("https://jcak002d.mywinday.com/_view/Odds2Gen.aspx?", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(result);

                // send msports

                if (Properties.Settings.Default.______odds_nextalert_02 != "")
                {
                    if (!Properties.Settings.Default.______odds_iswaiting_02)
                    {
                        Properties.Settings.Default.______odds_nextalert_02 = "";
                        Properties.Settings.Default.Save();
                        SendABCTeam(__running_22 + " Back to Normal.");
                    }
                }

                Properties.Settings.Default.______odds_iswaiting_02 = false;
                Properties.Settings.Default.Save();

                Invoke(new Action(() =>
                {
                    panel4.BackColor = Color.FromArgb(16, 90, 101);
                }));
                await ___TaskWait();
                ___MSPORTS_RUNNINGAsync();
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    Properties.Settings.Default.______odds_iswaiting_01 = true;
                    Properties.Settings.Default.Save();

                    if (err.ToString().Contains("(50"))
                    {
                        string datetime = DateTime.Now.AddHours(1).ToString("HH");

                        if (Properties.Settings.Default.______odds_nextalert_02 == "")
                        {
                            Properties.Settings.Default.______odds_nextalert_02 = datetime;
                            Properties.Settings.Default.Save();
                            SendABCTeam(__running_22 + " Under Maintenance.");
                        }
                        else
                        {
                            DateTime _date_from;
                            DateTime _date_to;
                            Properties.Settings.Default.______odds_nextalert_02 = datetime + ":00:00";
                            Properties.Settings.Default.Save();
                            string _date_from_ = Properties.Settings.Default.______odds_nextalert_02;
                            string _date_to_ = DateTime.Now.ToString("HH:00:00");

                            if (DateTime.TryParse(_date_from_, out _date_from) && DateTime.TryParse(_date_to_, out _date_to))
                            {
                                TimeSpan _ts = _date_to - _date_from;
                                int _hour = _ts.Hours;
                                if (Convert.ToInt32(_hour.ToString("0")) == 0 || Convert.ToInt32(_hour.ToString("0")) > 0)
                                {
                                    Properties.Settings.Default.______odds_nextalert_02 = datetime;
                                    Properties.Settings.Default.Save();
                                    SendABCTeam(__running_22 + " Under Maintenance.");
                                }
                            }
                        }

                        ___MSPORTS_NOTRUNNINGAsync();
                    }

                    SendMyBot(err.ToString());
                    
                    __is_close = false;
                    //Process.Start(Application.ExecutablePath);
                    //Environment.Exit(0);
                }
                else
                {
                    __is_close = false;
                    //Environment.Exit(0);
                }
            }
        }

        async Task ___TaskWait()
        {
            Random _random = new Random();
            int _random_number = _random.Next(1, 4);
            string _randowm_number_replace = _random_number.ToString() + "000";
            await Task.Delay(Convert.ToInt32(_randowm_number_replace));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();

            string password = __website_name + __running_01 + __api_key;
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string token = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

            var reqparm_ = new NameValueCollection
            {
                {"source_id", "1"},
                {"sport_name", "Soccer"},
                {"league_name", "Test asd League"},
                {"home_team", "SSI"},
                {"away_team", "GLBS"},
                {"ref_match_id", "2333"},
                {"token_api", token},
            };

            byte[] result_ = wc.UploadValues("http://oddsgrabber.ssitex.com/API/sendOdds", "POST", reqparm_);
            string responsebody_ = Encoding.UTF8.GetString(result_);
            MessageBox.Show(responsebody_);
            
            // restart ---
            //__is_close = true;
            ////Process.Start(Application.ExecutablePath);
            ////Environment.Exit(0);
        }
        
        public static bool ___CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        const UInt32 WM_CLOSE = 0x0010;

        void ___CloseMessageBox()
        {
            IntPtr windowPtr = FindWindowByCaption(IntPtr.Zero, "Message from webpage");

            if (windowPtr == IntPtr.Zero)
            {
                return;
            }

            SendMessage(windowPtr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        private void timer_close_message_box_Tick(object sender, EventArgs e)
        {
            ___CloseMessageBox();
        }

        private void pictureBox_header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
