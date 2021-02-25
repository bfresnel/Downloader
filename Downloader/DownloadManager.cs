using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace Downloader
{
    class DownloadManager
    {

        private WebClient WebClient;
        private DownloadProgressChangedEventHandler DownloadProgressChangedEventHandler;
        private AsyncCompletedEventHandler AsyncCompletedEventHandler;

        public DownloadManager()
        {
            WebClient = new WebClient();
        }

        public void DownloadFileAsync()
        {
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            wc.DownloadFileAsync(new Uri(UrlLink.adoptOpenJdkUrl), UrlLink.adoptOpenJdkFileName);
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            MessageBox.Show("Téléchargement terminé", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

    }
}
