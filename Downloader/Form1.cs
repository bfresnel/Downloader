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
        private readonly List<FileMetadata> FileMetadataList = new List<FileMetadata>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCheckedBoxList();
            downloadManager = new DownloadManager(downloadProgressBar, downloadLabel);
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            List<FileMetadata> filesToDownload = RetrieveAllCheckedValue();
            if (filesToDownload.Count > 0)
            {
                downloadLabel.Text = "Starting download...";
                Logger.Info("Démarrage du téléchargement du JDK");
                downloadLabel.Visible = true;
                Task task = downloadManager.DownloadFiles(filesToDownload);
                task.ContinueWith(
                    t => MessageBox.Show("Téléchargement terminé", "info", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void LoadCheckedBoxList()
        {
            FileMetadataList.Add(new FileMetadata(UrlLink.adoptOpenJdkName, UrlLink.adoptOpenJdkUrl, UrlLink.adoptOpenJdkFileName));
            FileMetadataList.Add(new FileMetadata(UrlLink.avastName, UrlLink.avastUrl, UrlLink.avastFileName));
            FileMetadataList.Add(new FileMetadata(UrlLink.chromeName, UrlLink.chromeUrl, UrlLink.chromeFileName));
            FileMetadataList.Add(new FileMetadata(UrlLink.steamName, UrlLink.steamUrl, UrlLink.steamFileName));
            foreach (FileMetadata fileMetada in FileMetadataList)
            {
                checkedListBox1.Items.Add(fileMetada);
            }
        }

        private List<FileMetadata> RetrieveAllCheckedValue()
        {
            List<FileMetadata> listToReturn = new List<FileMetadata>();
            foreach (FileMetadata software in checkedListBox1.CheckedItems)
            {
                Logger.Debug("Files to download : {0}", software.Name);
                listToReturn.Add(software);
            }
            return listToReturn;
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (FileMetadata software in FileMetadataList)
            {
                int index = checkedListBox1.Items.IndexOf(software);
                if (checkedListBox1.GetItemCheckState(index) != CheckState.Checked)
                {
                    checkedListBox1.SetItemCheckState(index, CheckState.Checked);
                }
            }
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            foreach (FileMetadata software in FileMetadataList)
            {
                int index = checkedListBox1.Items.IndexOf(software);
                if (checkedListBox1.GetItemCheckState(index) != CheckState.Unchecked)
                {
                    checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
                }
            }
        }
    }
}
