using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;

namespace Lab4
{
    public partial class Bai4 : Form
    {
        private ChromiumWebBrowser browser;
        private string userAgentToUse = "";
        //private string lastHtml = "";
        //private WebHeaderCollection lastResponseHeaders;
        //private WebHeaderCollection lastRequestHeaders;

        private readonly Dictionary<string, (string userAgent, int width, int height)> deviceProfiles = new Dictionary<string, (string, int, int)>
        {
            //["iPhone 14"] = ("Mozilla/5.0 (iPhone; CPU iPhone OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/16.0 Mobile/15E148 Safari/604.1", 428, 844),
            //["Android"] = ("Mozilla/5.0 (Linux; Android 12; Pixel 6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Mobile Safari/537.36", 412, 915),
            //["iPad"] = ("Mozilla/5.0 (iPad; CPU OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1", 768, 1024),
            ["Desktop"] = ("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36", 1280, 800)
        };
        public Bai4()
        {
            InitializeComponent();
            this.Load += Bai4_Load;
        }
        private async void Bai4_Load(object sender, EventArgs e)
        {
            var (userAgent, width, height) = deviceProfiles["Desktop"];
            userAgentToUse = userAgent;

            if (!Cef.IsInitialized.GetValueOrDefault())
            {
                InitializeCef(userAgentToUse);
            }

            ResizePanel(width, height);
            await LoadBrowserAsync(width, height);
        }
        private void InitializeCef(string userAgent)
        {
            var settings = new CefSettings
            {
                UserAgent = userAgent
            };
            Cef.Initialize(settings);
        }
        private async Task LoadBrowserAsync(int width, int height)
        {
            string url = "https://www.google.com";

            ResizePanel(width, height);
            await CreateBrowserAsync(url);
        }
        private async void BtnDownloadAll_Click(object sender, EventArgs e)
        {
            if (browser == null) return;

            string html = await browser.GetSourceAsync();
            string url = browser.Address;

            string folderPath = Path.Combine(Application.StartupPath, "Download");
            Directory.CreateDirectory(folderPath);

            string htmlPath = Path.Combine(folderPath, "index.html");
            File.WriteAllText(htmlPath, html);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", userAgentToUse);

            await DownloadAllResources(doc, url, folderPath, client);

            MessageBox.Show("Đã tải toàn bộ mã nguồn và tài nguyên liên quan vào thư mục Download.");
        }
        private async Task DownloadAllResources(HtmlAgilityPack.HtmlDocument doc, string baseUrl, string folderPath, WebClient client)
        {
            var imgNodes = doc.DocumentNode.SelectNodes("//img[@src]") ?? Enumerable.Empty<HtmlNode>();
            var linkNodes = doc.DocumentNode.SelectNodes("//link[@href]") ?? Enumerable.Empty<HtmlNode>();
            var scriptNodes = doc.DocumentNode.SelectNodes("//script[@src]") ?? Enumerable.Empty<HtmlNode>();

            foreach (var img in imgNodes)
            {
                string src = img.GetAttributeValue("src", "");
                await DownloadResourceAsync(src, baseUrl, folderPath, client);
            }

            foreach (var link in linkNodes)
            {
                string href = link.GetAttributeValue("href", "");
                await DownloadResourceAsync(href, baseUrl, folderPath, client);
            }

            foreach (var script in scriptNodes)
            {
                string src = script.GetAttributeValue("src", "");
                await DownloadResourceAsync(src, baseUrl, folderPath, client);
            }
        }
        private async Task DownloadResourceAsync(string resourceUrl, string baseUrl, string folderPath, WebClient client)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(resourceUrl)) return;
                if (resourceUrl.StartsWith("data:") || resourceUrl.StartsWith("javascript:")) return;
                if (resourceUrl.Contains("/xjs/") || resourceUrl.Contains("xjs=") || resourceUrl.Contains("/gen_204")) return;

                Uri baseUri = new Uri(baseUrl);
                Uri fullUri = new Uri(baseUri, resourceUrl);

                string fileName = Path.GetFileName(fullUri.LocalPath);
                if (string.IsNullOrEmpty(fileName)) return;

                string filePath = Path.Combine(folderPath, fileName);

                await client.DownloadFileTaskAsync(fullUri, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Không tải được: {resourceUrl}\n→ Lý do: {ex.Message}\n");
            }
        }
        private Task CreateBrowserAsync(string url)
        {
            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill
            };

            //browser.LoadingStateChanged += Browser_LoadingStateChanged;
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

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                this.Text = e.Title + " - Device Browser Emulator";
            }));
        }
        private async void BtnViewSource_Click(object sender, EventArgs e)
        {
            if (browser == null) return;

            string url = browser.Address;
            string html = await browser.GetSourceAsync();

            WebHeaderCollection responseHeaders = null;
            WebHeaderCollection requestHeaders = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", userAgentToUse);
                    requestHeaders = client.Headers;

                    client.DownloadString(url); 
                    responseHeaders = client.ResponseHeaders;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy header: " + ex.Message);
            }

            Form viewer = new Form
            {
                Text = "Xem mã nguồn và Header",
                Width = 900,
                Height = 600
            };

            TabControl tabs = new TabControl { Dock = DockStyle.Fill };

            TabPage tabHtml = new TabPage("HTML");
            TextBox txtHtml = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Text = html
            };
            tabHtml.Controls.Add(txtHtml);
            tabs.TabPages.Add(tabHtml);

            TabPage tabResp = new TabPage("Header Response");
            TextBox txtResp = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                ReadOnly = true
            };
            if (responseHeaders != null)
            {
                foreach (string key in responseHeaders.AllKeys)
                {
                    txtResp.AppendText($"{key}: {responseHeaders[key]}\r\n");
                }
            }
            tabResp.Controls.Add(txtResp);
            tabs.TabPages.Add(tabResp);

            TabPage tabReq = new TabPage("Header Request");
            TextBox txtReq = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                ReadOnly = true
            };
            if (requestHeaders != null)
            {
                foreach (string key in requestHeaders.AllKeys)
                {
                    txtReq.AppendText($"{key}: {requestHeaders[key]}\r\n");
                }
            }
            tabReq.Controls.Add(txtReq);
            tabs.TabPages.Add(tabReq);

            viewer.Controls.Add(tabs);
            viewer.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Cef.Shutdown();
        }
    }
}
