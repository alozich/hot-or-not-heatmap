using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TobiiEyeTracker
{
    /*
     * The Main Menu
     *  - Image selection
     *  - Start button
     *  - Turning on visual trail
     */
    public partial class MainForm : Form
    {
        public Image currentImage = null;
        public string originalFileName = "";
        Boolean trailOn = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void startButton_click(object sender, EventArgs e)
        {
            
            if (selectMediaButton.BackgroundImage == null)  //Must have image selected before pressing play
            {
                MessageBox.Show("Please select a media file.");
                return;
            }

            if (!File.Exists(openFileDialog.FileName))  //Double-checking
            {
                MessageBox.Show("Selected file does not exist.");
                return;
            }

            string fileExtension = Path.GetExtension(openFileDialog.FileName);
            fileExtension = fileExtension.ToLower();    //sometimes extension is capitalized

            if (fileExtension != ".bmp" && fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
            {
                MessageBox.Show("Selected file is not a valid image file.");
                return;
            }

            //  Start trial
            //  Pass the selected image, whether to turn on the trail, and the image file's name
            //  TrialForm(Image, bool, string)
            try
            {
                TrialForm trialForm = new TrialForm(currentImage, trailOn, originalFileName);
                trialForm.ShowDialog();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void selectMediaButton_click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentImage = Image.FromFile(openFileDialog.FileName);
                originalFileName = openFileDialog.FileName;

                /* 
                 * Rotating the image if need be
                 * Site w/ standard EXIF tags
                 * https://exiv2.org/tags.html
                */

                try
                {
                    System.Drawing.Imaging.PropertyItem exifOrientation = currentImage.GetPropertyItem(274);    // Orientation property in EXIF = 274
                    int val = BitConverter.ToUInt16(exifOrientation.Value, 0);
                    //currentImage.RotateFlip(Orientation(val));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                selectMediaButton.BackgroundImage = currentImage;
            }
        }

        /*
         * Returns: a RotateFlipType based on an int representing an image orientation
         */
        private RotateFlipType Orientation(int val)
        {
            switch(val)
            {
                case 1:
                    return RotateFlipType.RotateNoneFlipNone;
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
                case 4:
                    return RotateFlipType.RotateNoneFlipY;
                case 5:
                    return RotateFlipType.Rotate90FlipX;
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                case 7:
                    return RotateFlipType.Rotate90FlipY;
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }

        private void trailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (trailCheckBox.Checked)
                trailOn = true;
            else
                trailOn = false;
        }
    }
}
