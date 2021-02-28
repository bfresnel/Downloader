using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader
{
    class DownloadManager
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly WebClient WebClient;
        private readonly ProgressBar ProgressBar;
        private readonly Label Label;
        private string CurrentFile;

        public DownloadManager()
        {
            WebClient = new WebClient();
        }

        public DownloadManager(ProgressBar progressBar, Label label)
        {
            WebClient = new WebClient();
            ProgressBar = progressBar;
            Label = label;
        }

        public async Task<bool> DownloadFiles(List<FileMetadata> filesToDownload)
        {
            bool result = false;
            WebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            WebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            foreach (FileMetadata filemetadata in filesToDownload)
            {
                try
                {
                    CurrentFile = filemetadata.Name;
                    Logger.Info("Downloading {0}...", filemetadata.Filename);
                    await WebClient.DownloadFileTaskAsync(filemetadata.Url, filemetadata.Filename);
                    Logger.Info("Download for {0} completed !", filemetadata.Filename);
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    throw new Exception(ex.Message);
                }
            }
            return result;
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Label.Text = "Téléchargement de " + CurrentFile + "..." + e.ProgressPercentage + "%";
            if (ProgressBar != null)
            {
                UpdateProgressBar(ProgressBar, e.ProgressPercentage);
            }
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Logger.Debug("Download completed");
        }

        private void UpdateProgressBar(ProgressBar progressBar, int pourcentage)
        {
            progressBar.Value = pourcentage;
        }

    }
}
