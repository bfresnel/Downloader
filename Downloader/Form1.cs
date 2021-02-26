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

        /**
         * Permet d'initialiser le dictionnaire
         * Permet aussi d'initialiser la liste box
         */
        public Form1()
        {
            InitializeComponent();
            LoadDictionnary();
            LoadCheckedBoxList();
            downloadManager = new DownloadManager(progressBar1, label1);
        }

        private void LoadCheckedBoxList()
        {
            checkedListBox1.Items.Add("AdoptOpenJdk");
            checkedListBox1.Items.Add("Avast");
            checkedListBox1.Items.Add("Steam");
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
