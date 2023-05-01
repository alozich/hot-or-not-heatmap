
namespace TobiiEyeTracker
{
    partial class TrialForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrialForm));
            this.trialPeriodTimer = new System.Windows.Forms.Timer(this.components);
            this.gazePointTimer = new System.Windows.Forms.Timer(this.components);
            this.redCirclePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.redCirclePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trialPeriodTimer
            // 
            this.trialPeriodTimer.Enabled = true;
            this.trialPeriodTimer.Interval = 15000;
            this.trialPeriodTimer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // gazePointTimer
            // 
            this.gazePointTimer.Enabled = true;
            this.gazePointTimer.Interval = 50;
            this.gazePointTimer.Tick += new System.EventHandler(this.gazePointTimer_Tick);
            // 
            // redCirclePictureBox
            // 
            this.redCirclePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.redCirclePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.redCirclePictureBox.Image = global::TobiiEyeTracker.Properties.Resources.Red_circle;
            this.redCirclePictureBox.Location = new System.Drawing.Point(705, 322);
            this.redCirclePictureBox.Name = "redCirclePictureBox";
            this.redCirclePictureBox.Size = new System.Drawing.Size(46, 46);
            this.redCirclePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.redCirclePictureBox.TabIndex = 0;
            this.redCirclePictureBox.TabStop = false;
            // 
            // TrialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.redCirclePictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrialForm";
            this.Text = "TrialForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.redCirclePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer trialPeriodTimer;
        private System.Windows.Forms.Timer gazePointTimer;
        private System.Windows.Forms.PictureBox redCirclePictureBox;
    }
}