using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader
{
    public partial class Form1 : Form
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private DownloadManager downloadManager;

        /**
         * Permet d'initialiser le dictionnaire
         * Permet aussi d'initialiser la liste box
         */
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LoadDictionnary();
            LoadCheckedBoxList();
            downloadManager = new DownloadManager(progressBar1, label1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            List<string> files = new List<string>
            {
                UrlLink.adoptOpenJdkFileName
            };
            label1.Text = "Téléchargement d'AdoptOpenJDK...";
            label1.Visible = true;
            Logger.Info("Démarrage du téléchargement du JDK");
            Task task = downloadManager.DownloadFile(files);
            task.ContinueWith(
                t => MessageBox.Show("Téléchargement terminé", "info", MessageBoxButtons.OK, MessageBoxIcon.Information));
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void LoadCheckedBoxList()
        {
            checkedListBox1.Items.Add("AdoptOpenJdk");
        }

        private void LoadDictionnary()
        {
            _ = new Dictionary<UrlLink.EnumLinks, string>
            {
                { UrlLink.EnumLinks.ADOPTOPENJDK, UrlLink.adoptOpenJdkUrl }
            };
        }




    }
}
