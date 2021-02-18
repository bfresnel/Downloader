﻿using System;
using System.Windows.Forms;
using System.Net;
using System.ComponentModel;

namespace Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void wc_DownloadProgressChanged(object s, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void wc_DownloadFileCompleted(object s, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Téléchargement terminé", "info",  MessageBoxButtons.OK);
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Démarrage du téléchargement du JDK");
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            wc.DownloadFileAsync(new Uri("https://github.com/AdoptOpenJDK/openjdk11-binaries/releases/download/jdk-11.0.10%2B9/OpenJDK11U-jdk_x64_windows_hotspot_11.0.10_9.msi"),
                "OpenJDK11U-jdk_x64_windows_hotspot_11.0.10_9.msi");
            button1.Enabled = false;
        }
    }
}