using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
            ConfigureListView();
        }

        private void ConfigureListView()
        {
            listViewHeader.View = View.Details;
            listViewHeader.FullRowSelect = true;
            listViewHeader.Columns.Clear();

            listViewHeader.Columns.Add("STT", 50);
            listViewHeader.Columns.Add("Header", 150);
            listViewHeader.Columns.Add("Value", 150);
        }
        private void bttnClick_Click(object sender, EventArgs e)
        {
            WebClient myClient = new WebClient();
            string host = textBoxURL.Text;

            byte[] respone = myClient.DownloadData(host);
            richTextBoxHTML.Text = Encoding.UTF8.GetString(respone);
            WebHeaderCollection headers = myClient.ResponseHeaders;
            listViewHeader.Items.Clear();
            for (int i = 0; i < headers.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(headers.GetKey(i));
                item.SubItems.Add(headers[i]);
                listViewHeader.Items.Add(item);
            }
        }
    }
}
