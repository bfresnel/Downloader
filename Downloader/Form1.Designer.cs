namespace Downloader
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.downloadButton = new System.Windows.Forms.Button();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 204);
            this.downloadProgressBar.Name = "progressBar1";
            this.downloadProgressBar.Size = new System.Drawing.Size(332, 31);
            this.downloadProgressBar.TabIndex = 0;
            // 
            // button1
            // 
            this.downloadButton.Location = new System.Drawing.Point(98, 241);
            this.downloadButton.Name = "button1";
            this.downloadButton.Size = new System.Drawing.Size(143, 23);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.Text = "Téléchargement";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // label1
            // 
            this.downloadLabel.Location = new System.Drawing.Point(12, 181);
            this.downloadLabel.Name = "label1";
            this.downloadLabel.Size = new System.Drawing.Size(332, 20);
            this.downloadLabel.TabIndex = 2;
            this.downloadLabel.Text = "label1";
            this.downloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.downloadLabel.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(332, 139);
            this.checkedListBox1.Sorted = true;
            this.checkedListBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(354, 298);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.downloadProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

