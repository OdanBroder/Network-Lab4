using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Bai2 : Form
    {
        private ChromiumWebBrowser browser;
        private string userAgentToUse = "";

        private readonly Dictionary<string, (string userAgent, int width, int height)> deviceProfiles = new Dictionary<string, (string, int, int)>
        {
            ["iPhone 14"] = ("Mozilla/5.0 (iPhone; CPU iPhone OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.0 Mobile/15E148 Safari/604.1", 428, 844),
            ["Android"] = ("Mozilla/5.0 (Linux; Android 12; Pixel 6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Mobile Safari/537.36", 412, 915),
            ["iPad"] = ("Mozilla/5.0 (iPad; CPU OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1", 768, 1024),
            ["Desktop"] = ("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36", 1280, 800)
        };

        public Bai2()
        {
            InitializeComponent();
            InitializeDeviceSelection();
        }

        private void InitializeCef(string userAgent)
        {
            var settings = new CefSettings
            {
                UserAgent = userAgent
            };
            Cef.Initialize(settings);
        }

        private void InitializeDeviceSelection()
        {
            comboBoxDevice.Items.AddRange(deviceProfiles.Keys.ToArray());
            comboBoxDevice.SelectedIndex = 0;
            comboBoxDevice.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void buttonGo_Click(object sender, EventArgs e)
        {
            var selectedDevice = comboBoxDevice.SelectedItem.ToString();
            var (userAgent, width, height) = deviceProfiles[selectedDevice];
            userAgentToUse = userAgent;

            textBoxUrl.Hide();
            buttonGo.Hide();
            comboBoxDevice.Hide();

            if (!Cef.IsInitialized.GetValueOrDefault())
            {
                InitializeCef(userAgentToUse); 
            }

            await LoadBrowserAsync(width, height);
        }

        private async Task LoadBrowserAsync(int width, int height)
        {
            string url = PrepareUrl(textBoxUrl.Text.Trim());

            CleanupBrowser();
            ResizePanel(width, height);
            await CreateBrowserAsync(url);
        }

        private string PrepareUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return "https://www.google.com";

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "https://" + url;

            return url;
        }

        private void CleanupBrowser()
        {
            if (browser != null)
            {
                panelBrowser.Controls.Remove(browser);
                browser.Dispose();
                browser = null;
            }
        }

        private Task CreateBrowserAsync(string url)
        {
            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill
            };

            browser.LoadingStateChanged += Browser_LoadingStateChanged;
            browser.TitleChanged += Browser_TitleChanged;

            panelBrowser.Controls.Add(browser);
            return Task.CompletedTask;
        }

        private void ResizePanel(int width, int height)
        {
            panelBrowser.Width = width;
            panelBrowser.Height = height;

            this.Width = width + 40;
            this.Height = height + 80;

            panelBrowser.Left = (this.ClientSize.Width - panelBrowser.Width) / 2;
            panelBrowser.Top = (this.ClientSize.Height - panelBrowser.Height) / 2;
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                buttonGo.Enabled = !e.IsLoading;
            }));
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                this.Text = e.Title + " - Device Browser Emulator";
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Cef.Shutdown();
        }

        private void Bai2_Load(object sender, EventArgs e)
        {

        }
    }
}
