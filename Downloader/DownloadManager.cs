﻿using System;
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

        public async Task<bool> DownloadFile(List<string> fileList)
        {
            bool result = false;
            WebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            WebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            foreach (string file in fileList)
            {
                try
                {
                    Logger.Info("Downloading {0}...", file);
                    await WebClient.DownloadFileTaskAsync(new Uri(UrlLink.adoptOpenJdkUrl), UrlLink.adoptOpenJdkFileName);
                    Logger.Info("Download for {0} completed !", file);
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
            Label.Text = "Téléchargement d'AdoptOpenJDK..." + e.ProgressPercentage + "%";
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