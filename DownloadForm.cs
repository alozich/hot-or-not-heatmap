using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TobiiEyeTracker
{
    public partial class DownloadForm : Form
    {
        Image heatMap;
        string originalFileName = "";
        public DownloadForm()
        {
            InitializeComponent();
            heatMap = Image.FromFile("heatMap.png");
            heatMapPictureBox.Image = heatMap;
        }
        public DownloadForm(string originalFileName)
        {
            InitializeComponent();
            heatMap = Image.FromFile("heatMap.png");
            heatMapPictureBox.Image = heatMap;
            this.originalFileName = originalFileName;
        }


        private void downloadButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("inside downloadButton_Click");
            saveHeatMapDialog.FileName = originalFileName;

            if (saveHeatMapDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveHeatMapDialog.FileName;
                Console.WriteLine("fileName: " + fileName);
                heatMap.Save(fileName);
                
            }
        }

        private void DownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            heatMap.Dispose();
            heatMapPictureBox.Dispose();
        }
    }
}
