using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader
{
    public partial class Form1 : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private Dictionary<UrlLink.EnumLinks, string> LinkMap;
        private DownloadManager downloadManager;
        private DialogResult dr;

        public Form1()
        {
            InitializeComponent();
            LoadDictionnary();
            downloadManager = new DownloadManager(progressBar1, label1, button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            List<string> files = new List<string>();
            files.Add(UrlLink.adoptOpenJdkFileName);
            files.Add(UrlLink.adoptOpenJdkFileName);
            label1.Text = "Téléchargement d'AdoptOpenJDK...";
            label1.Visible = true;
            Logger.Info("Démarrage du téléchargement du JDK");
            Task task = downloadManager.DownloadFile(files);
            task.ContinueWith(
                t => MessageBox.Show("Téléchargement terminé", "info", MessageBoxButtons.OK, MessageBoxIcon.Information));
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
