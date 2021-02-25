using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Downloader
{
    public partial class Form1 : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private Dictionary<UrlLink.EnumLinks, string> LinkMap;
        private DownloadManager downloadManager;

        public Form1()
        {
            InitializeComponent();
            LoadDictionnary();
            downloadManager = new DownloadManager(progressBar1, label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            files.Add(UrlLink.adoptOpenJdkFileName);
            Logger.Info("Démarrage du téléchargement du JDK");
            downloadManager.DownloadFile(files);
        }

        private void LoadDictionnary()
        {
            Dictionary<UrlLink.EnumLinks, string> linkMapLocal = new Dictionary<UrlLink.EnumLinks, string>
            {
                { UrlLink.EnumLinks.ADOPTOPENJDK, UrlLink.adoptOpenJdkUrl }
            };
            LinkMap = linkMapLocal;
        }
    }
}
