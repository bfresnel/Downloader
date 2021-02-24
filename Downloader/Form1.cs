using System;
using System.Windows.Forms;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;

namespace Downloader
{
    public partial class Form1 : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private bool CanStartAnotherDownload = false;

        public enum EnumLinks
        {
            ADOPTOPENJDK = 0,
            AVAST=1
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
            label1.Text = "Téléchargement d'AdoptOpenJDK..." + e.ProgressPercentage;
        }

        void wc_DownloadFileCompleted(object s, AsyncCompletedEventArgs e)
        {
            label1.Visible = false;
            MessageBox.Show("Téléchargement terminé", "info",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Enabled = true;
            this.CanStartAnotherDownload = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Info("Démarrage du téléchargement du JDK");
            label1.Text = "Téléchargement d'AdoptOpenJDK...";
            label1.Visible = true;
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            wc.DownloadFileAsync(new Uri(UrlLink.adoptOpenJdkUrl), "jdk_x64_windows_hotspot_11.0.10_9.msi");
            this.CanStartAnotherDownload = false;
        }

        private void LoadDictionnary()
        {
            Dictionary<EnumLinks, string> linkMapLocal = new Dictionary<EnumLinks, string>
            {
                { EnumLinks.ADOPTOPENJDK, UrlLink.adoptOpenJdkUrl }
            };
            this.linkMap = linkMapLocal;
        }
    }
}
