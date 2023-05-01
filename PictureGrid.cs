using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TobiiEyeTracker
{
    public class PictureGrid
    {
        public int[,] grid;
        private Image picture;
        private int width;
        private int height;
        public int cellSize;
        private int boxAmt = 12;

        public PictureGrid(Image picture)
        {
            Console.WriteLine("Inside PictureGrid");
            this.picture = picture;

            this.width = picture.Width;
            this.height = picture.Height;

            if (this.width >= this.height)
            {
                this.cellSize = this.width / this.boxAmt;
            }
            else
            {
                this.cellSize = this.height / this.boxAmt;
            }

            Console.WriteLine("Cellsize:" + this.cellSize);
            this.grid = new int[boxAmt, boxAmt];
        }

        public Image GetImage()
        {
            return picture;
        }

        public void CreateHeatMap(int[,] fields)
        {
            Bitmap bmp = new Bitmap(picture);
            Graphics heatMap = Graphics.FromImage(bmp);
            SolidBrush brush = new SolidBrush(Color.FromArgb(5, 255, 0, 0));

            int totalNumPoints = 0;
            int numNonzeroPoints = 0;
            int max = 0;

            // Counting up the non-zero points to get the avg
            foreach (int square in fields)
            {
                totalNumPoints += square;
                if(square != 0)
                {
                    numNonzeroPoints++;
                    if(square > max)
                    {
                        max = square;
                    }
                }
            }

            double avg = totalNumPoints / numNonzeroPoints;
            int factor = 7; //   used to dramatize results

            Console.WriteLine($"max: {max}");
            Console.WriteLine($"avg: {avg}");

            //int colorSectionAmount = totalNumPoints / 2;
            for (int x = 0; x < fields.GetLength(0); x++)
            {
                for (int y = 0; y < fields.GetLength(1); y++)
                {
                    int red = 255;
                    int green, blue;
                    Console.WriteLine($"fields[x, y] {fields[x, y]}");

                    //  If the tally < than average, then should look between white and yellow
                    if (fields[x, y] < avg)
                    {
                        green = 255;
                        blue = 255 - factor * fields[x, y];
                        if (blue < 0)
                            blue = 0;
                    }
                    //  If tally is  >= than averge, should look between orange and red
                    else
                    {
                        green = 255 - factor * fields[x, y];
                        if (green < 0)
                            green = 0;
                        blue = 0;
                    }

                    brush.Color = Color.FromArgb(150, red, green, blue);

                    //  Only coloring fields that were looked at
                    if (fields[x, y] != 0)
                    {
                        heatMap.FillRectangle(brush, (width / boxAmt) * y, (height / boxAmt) * x, width / boxAmt, height / boxAmt);
                    }
                }
            }
            try
            {
                using(FileStream stream = new FileStream("heatMap.png", FileMode.Create))
                {
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (System.Runtime.InteropServices.ExternalException e)
            {
                MessageBox.Show("An error occurred while saving the image: " + e.Message);
            }


            bmp.Dispose();
            heatMap.Dispose();
        }
    }
}
