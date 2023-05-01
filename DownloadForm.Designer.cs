
namespace TobiiEyeTracker
{
    partial class DownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.heatMapPictureBox = new System.Windows.Forms.PictureBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.saveHeatMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heatMapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.heatMapPictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.downloadButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 533);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // heatMapPictureBox
            // 
            this.heatMapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heatMapPictureBox.Location = new System.Drawing.Point(3, 3);
            this.heatMapPictureBox.Name = "heatMapPictureBox";
            this.heatMapPictureBox.Size = new System.Drawing.Size(882, 445);
            this.heatMapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.heatMapPictureBox.TabIndex = 1;
            this.heatMapPictureBox.TabStop = false;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.downloadButton.Image = global::TobiiEyeTracker.Properties.Resources.download_icon;
            this.downloadButton.Location = new System.Drawing.Point(414, 461);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(60, 61);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // saveHeatMapDialog
            // 
            this.saveHeatMapDialog.DefaultExt = "png";
            this.saveHeatMapDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadForm";
            this.Text = "DownloadForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heatMapPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.PictureBox heatMapPictureBox;
        private System.Windows.Forms.SaveFileDialog saveHeatMapDialog;
    }
}