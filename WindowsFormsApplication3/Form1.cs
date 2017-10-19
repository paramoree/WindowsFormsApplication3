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
using System.Xml;
using System.Xml.Linq;
using System.IO;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {   
            WebClient webClient = new WebClient();

            var xml = "";
            using (var client = new System.Net.WebClient())
            {
                client.Encoding = Encoding.UTF8;
                xml = client.DownloadString("https://www.aftonbladet.se/rss.xml");
                  // xml = client.DownloadString("" + textBox1.Text);

                var dom = new System.Xml.XmlDocument();
                dom.LoadXml(xml);

                foreach (System.Xml.XmlNode item in dom.DocumentElement.SelectNodes("channel/item"))
                {
                    var title = item.SelectSingleNode("title");
                    Console.WriteLine(title.InnerText);
                }


                     richTextBox1.Text = webClient.DownloadString("https://www.aftonbladet.se/rss.xml");
               // richTextBox1.Text = xml;
            }
        
            //Nytt försök


        }

        private void button1_Click(object sender, EventArgs e)
        {   

        }


        public class RSScontent
        {
            public string Title { get; set; }
            public string pubDate { get; set; }
            public string Description { get; set; }
        }



    }
}
