using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace Downloader
{
    class DownloadManager
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private WebClient WebClient;
        private ProgressBar ProgressBar;
        private Label Label;
        private List<string> FilesToDownload;

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

        public void DownloadFile(List<string> filesToDownload)
        {
            FilesToDownload = filesToDownload;
            WebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            WebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            WebClient.DownloadFileAsync(new Uri(UrlLink.adoptOpenJdkUrl), UrlLink.adoptOpenJdkFileName);
            Label.Text = "Téléchargement d'AdoptOpenJDK...";
            Label.Visible = true;
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Label.Text = "Téléchargement d'AdoptOpenJDK..." + e.ProgressPercentage + "%";
            if (ProgressBar != null)
            {
                updateProgressBar(ProgressBar, e.ProgressPercentage);
            }
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Logger.Info("Download completed");
            Logger.Debug("DownloadFileCompleted() -> isBusy ? " + WebClient.IsBusy);
            FilesToDownload.Remove(UrlLink.adoptOpenJdkFileName);
            MessageBox.Show("Téléchargement terminé", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Label.Visible = false;

        }

        private void updateProgressBar(ProgressBar progressBar, int pourcentage)
        {
            progressBar.Value = pourcentage;
        }

    }
}
