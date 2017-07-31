using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace TestProxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = tbHost.Text;
            string port = tbPort.Text;
            string url = tbURL.Text;
            WebClient wc = new WebClient();
            if (checkBox1.Checked == true)
            {
                wc.Proxy = new WebProxy(host, Convert.ToInt32(port));
                wc.Proxy.Credentials = new NetworkCredential(tbUser.Text, tbPassword.Text);    
            }

            var page = wc.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);
            tbResult.Text = page;
        }
    }
}
