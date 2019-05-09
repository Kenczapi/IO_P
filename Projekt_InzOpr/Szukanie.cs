using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using YoutubeSearch;
using VideoLibrary;

namespace Projekt_InzOpr
{
    public partial class Szukanie : UserControl
    {
        public String Url;
        public Szukanie()
        {
            InitializeComponent();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            VideoSearch items = new VideoSearch();
            List<Video> list = new List<Video>();
            foreach (var item in items.SearchQuery(textSearch.Text, 1))
            {
                Video video = new Video
                {
                    Title = item.Title,
                    Author = item.Author,
                    Url = item.Url
                };
                byte[] imageBytes = new WebClient().DownloadData(item.Thumbnail);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    video.Thumbnail = Image.FromStream(ms);
                }
                list.Add(video);
            }
            videoBindingSource.DataSource = list;
        }

        private void TextSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                ButtonSearch_Click(null, null);
            }
        }

        public delegate void bez();
        public event bez Clicked;
        
        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string uri = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            var youTube = YouTube.Default;
            try
            {
                var video = youTube.GetVideo(uri);
                Url = video.Uri;
                
                this.Visible = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Nie można odtworzyć tego filmu. Proszę wybrać inny");
            }
            Clicked?.Invoke();
        }
    }
}
