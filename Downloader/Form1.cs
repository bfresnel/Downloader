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
        private List<FileMetadata> FileMetadataList = new List<FileMetadata>();

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
            LoadCheckedBoxList();
            downloadManager = new DownloadManager(progressBar1, label1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Text = "Téléchargement d'AdoptOpenJDK...";
            label1.Visible = true;
            Logger.Info("Démarrage du téléchargement du JDK");
            Task task = downloadManager.DownloadFile(FileMetadataList);
            task.ContinueWith(
                t => MessageBox.Show("Téléchargement terminé", "info", MessageBoxButtons.OK, MessageBoxIcon.Information));
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void LoadCheckedBoxList()
        {
            FileMetadataList.Add(new FileMetadata(UrlLink.adoptOpenJdkName, UrlLink.adoptOpenJdkUrl, UrlLink.adoptOpenJdkFileName));
            FileMetadataList.Add(new FileMetadata(UrlLink.avastName,UrlLink.avastUrl, UrlLink.avastFileName));
            foreach (FileMetadata fileMetada in FileMetadataList)
            {
                checkedListBox1.Items.Add(fileMetada.Name);
            }
        }
    }
}
