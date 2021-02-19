using System;
using System.Windows.Forms;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;

namespace Downloader
{
    public partial class Form1 : Form
    {
        public enum EnumLinks
        {
            ADOPTOPENJDK = 0,
            STEAM = 1,
            VISUALSTUDIOCODE = 2,
            GIT = 3,
            INTELLIJ = 4
        }
        private Dictionary<EnumLinks, string> linkMap;

        public Form1()
        {
            InitializeComponent();
            LoadDictionnary();
        }

        void wc_DownloadProgressChanged(object s, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void wc_DownloadFileCompleted(object s, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Téléchargement terminé", "info",  MessageBoxButtons.OK);
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Démarrage du téléchargement du JDK");
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            wc.DownloadFileAsync(new Uri(linkMap[EnumLinks.ADOPTOPENJDK]),"OpenJDK11U-jdk_x64_windows_hotspot_11.0.10_9.msi");
            button1.Enabled = false;
        }

        private void LoadDictionnary()
        {
            Dictionary<EnumLinks, string> linkMapLocal = new Dictionary<EnumLinks, string>();
            linkMap.Add(EnumLinks.ADOPTOPENJDK, UrlLink.adoptOpenJdkUrl);
            this.linkMap = linkMapLocal;
        }
    }
}
