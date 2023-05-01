
namespace TobiiEyeTracker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.selectMediaButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.trailCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" +
    "s (*.*)|*.*";
            // 
            // selectMediaButton
            // 
            this.selectMediaButton.BackgroundImage = global::TobiiEyeTracker.Properties.Resources.gallery_image_landscape_mobile_museum_open_line_icon_13201830490201859241;
            this.selectMediaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.selectMediaButton.Location = new System.Drawing.Point(146, 144);
            this.selectMediaButton.Name = "selectMediaButton";
            this.selectMediaButton.Size = new System.Drawing.Size(300, 300);
            this.selectMediaButton.TabIndex = 1;
            this.selectMediaButton.UseVisualStyleBackColor = true;
            this.selectMediaButton.Click += new System.EventHandler(this.selectMediaButton_click);
            // 
            // startButton
            // 
            this.startButton.BackgroundImage = global::TobiiEyeTracker.Properties.Resources.play_button_28245;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startButton.Location = new System.Drawing.Point(594, 144);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(300, 300);
            this.startButton.TabIndex = 0;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_click);
            // 
            // trailCheckBox
            // 
            this.trailCheckBox.AutoSize = true;
            this.trailCheckBox.Location = new System.Drawing.Point(928, 180);
            this.trailCheckBox.Name = "trailCheckBox";
            this.trailCheckBox.Size = new System.Drawing.Size(77, 17);
            this.trailCheckBox.TabIndex = 2;
            this.trailCheckBox.Text = "Visual Trail";
            this.trailCheckBox.UseVisualStyleBackColor = true;
            this.trailCheckBox.CheckedChanged += new System.EventHandler(this.trailCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1031, 609);
            this.Controls.Add(this.trailCheckBox);
            this.Controls.Add(this.selectMediaButton);
            this.Controls.Add(this.startButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Eye Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button selectMediaButton;
        private System.Windows.Forms.CheckBox trailCheckBox;
    }
}

