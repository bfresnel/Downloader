using System;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader
{
    class DownloadManager
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private WebClient WebClient;
        private ProgressBar ProgressBar;
        private Label Label;
        private Button Button;

        public DownloadManager()
        {
            WebClient = new WebClient();
        }

        public DownloadManager(ProgressBar progressBar, Label label, Button button)
        {
            WebClient = new WebClient();
            ProgressBar = progressBar;
            Label = label;
            Button = button;
        }

        public async Task<bool> DownloadFile(string fileName)
        {
            bool result = false;
            WebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            WebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            try
            {
                Label.Text = "Téléchargement d'AdoptOpenJDK...";
                Label.Visible = true;
                await WebClient.DownloadFileTaskAsync(new Uri(UrlLink.adoptOpenJdkUrl), UrlLink.adoptOpenJdkFileName);
                result = true;

            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception(ex.Message);
            }

            return result;
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
            MessageBox.Show("Téléchargement terminé", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Label.Visible = false;
            Button.Enabled = true;

        }

        private void updateProgressBar(ProgressBar progressBar, int pourcentage)
        {
            progressBar.Value = pourcentage;
        }

    }
}
