using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace Downloader
{
    public partial class Form1 : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private bool CanStartAnotherDownload = false;
        private Dictionary<UrlLink.EnumLinks, string> LinkMap;
        //private ResourceManager rm = new ResourceManager();

        public Form1()
        {
            InitializeComponent();
            LoadDictionnary();
        }

        void wc_DownloadProgressChanged(object s, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = "Téléchargement d'AdoptOpenJDK..." + e.ProgressPercentage + "%";
        }

        void wc_DownloadFileCompleted(object s, AsyncCompletedEventArgs e)
        {
            label1.Visible = false;
            MessageBox.Show("Téléchargement terminé", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Enabled = true;
            CanStartAnotherDownload = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Info("Démarrage du téléchargement du JDK");
            label1.Text = "Téléchargement d'AdoptOpenJDK...";
            label1.Visible = true;
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            wc.DownloadFileAsync(new Uri(UrlLink.adoptOpenJdkUrl), UrlLink.adoptOpenJdkFileName);
            CanStartAnotherDownload = false;
        }

        private void LoadDictionnary()
        {
            Dictionary<UrlLink.EnumLinks, string> linkMapLocal = new Dictionary<UrlLink.EnumLinks, string>
            {
                { UrlLink.EnumLinks.ADOPTOPENJDK, UrlLink.adoptOpenJdkUrl }
            };
            LinkMap = linkMapLocal;
        }

        private void DownloadSoftware(List<string> softwareList)
        {
            if (softwareList.Count > 0)
            {
                foreach (string software in softwareList)
                {
                    WebClient wc = new WebClient();
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                    wc.DownloadFileAsync(new Uri(UrlLink.adoptOpenJdkUrl), UrlLink.adoptOpenJdkFileName);
                }
            }
        }
    }
}
