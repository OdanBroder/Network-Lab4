using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
            ConfigureListView();
        }

        private void ConfigureListView()
        {
            listViewPost.View = View.Details;
            listViewPost.GridLines = true;
            listViewPost.FullRowSelect = true;

            listViewPost.Columns.Add("userID", 50);
            listViewPost.Columns.Add("id", 50);
            listViewPost.Columns.Add("Title", 150);
            listViewPost.Columns.Add("Content", 200);
        }

        private async void bttnClick_Click(object sender, EventArgs e)
        {
            await LoadPostsAsync();
        }

        private async Task LoadPostsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "https://jsonplaceholder.typicode.com/posts";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();

                    var posts = JsonSerializer.Deserialize<List<Post>>(json);

                    listViewPost.Items.Clear();
                    foreach (var post in posts)
                    {
                        ListViewItem item = new ListViewItem(post.userId.ToString());
                        item.SubItems.Add(post.id.ToString());
                        item.SubItems.Add(post.title);
                        item.SubItems.Add(post.body);
                        listViewPost.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading posts: " + ex.Message);
                }
            }
        }

        public class Post
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }
    }
}
