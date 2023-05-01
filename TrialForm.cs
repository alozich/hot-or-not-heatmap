using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.StreamEngine;
using System.Windows;
using System.IO;

namespace TobiiEyeTracker
{
    public partial class TrialForm : Form
    {

        IntPtr deviceContext;
        int count;
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        int taskbarHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
        int leftX;
        int rightX;
        int topY;
        int bottomY;
        float scaleX;
        float scaleY;
        PictureGrid picture;
        int dimensions = 12;
        int[,] freq;
        Boolean trailOn;
        string originalFileName;
        public TrialForm(Image img, Boolean trailOn, string originalFileName)
        {
            InitializeComponent();
            Console.WriteLine("TrialForm creating");

            // McVey's suggested code

            if (img.Height > this.ClientSize.Height || img.Width > this.ClientSize.Width) // If the height or width of the image is larger than the screen
            {
                img = ResizedImage(img);
            }

            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Center;
            this.DoubleBuffered = true;

            /*  Visual gaze on or off */
            this.trailOn = trailOn;
            if (!trailOn)
                redCirclePictureBox.Visible = false;

            //  Initializing -- used for tallying up gaze points
            freq = new int[dimensions, dimensions];
            for (int i = 0; i < dimensions; i++)
                for (int j = 0; j < dimensions; j++)
                    freq[i, j] = 0;

            scaleX = (float)this.BackgroundImage.Width / dimensions;
            scaleY = (float)this.BackgroundImage.Height / dimensions;

            //  Create API context
            IntPtr apiContext;
            tobii_error_t result = Interop.tobii_api_create(out apiContext, null);
            Debug.Assert(result == tobii_error_t.TOBII_ERROR_NO_ERROR);

            //Enumerate devices to find connected eye trackers
            List<string> urls;
            result = Interop.tobii_enumerate_local_device_urls(apiContext, out urls);
            Debug.Assert(result == tobii_error_t.TOBII_ERROR_NO_ERROR);
            if (urls.Count == 0)
            {
                Console.WriteLine("Error: No device found");
                return;
            }

            //  Connect to the first tracker found
            //IntPtr deviceContext;
            result = Interop.tobii_device_create(apiContext, urls[0], Interop.tobii_field_of_use_t.TOBII_FIELD_OF_USE_INTERACTIVE, out deviceContext);
            Debug.Assert(result == tobii_error_t.TOBII_ERROR_NO_ERROR);

            IntPtr form = this.Handle;
            result = Interop.tobii_gaze_point_subscribe(deviceContext, OnGazePoint, form);
            Debug.Assert(result == tobii_error_t.TOBII_ERROR_NO_ERROR);

            //  Used later for making the heatmap
            picture = new PictureGrid(img);

            leftX = (screenWidth / 2) - (img.Width / 2);
            rightX = (screenWidth / 2) + (img.Width / 2);
            topY = ((screenHeight - taskbarHeight - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height) / 2) - (img.Height / 2);
            bottomY = ((screenHeight - taskbarHeight - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height) / 2) + (img.Height / 2);

        }

        private void OnGazePoint(ref tobii_gaze_point_t gazePoint, IntPtr userData)
        {
            if (gazePoint.validity == tobii_validity_t.TOBII_VALIDITY_VALID)
            {
                count++;
                float xGazePoint = gazePoint.position.x * screenWidth;
                float yGazePoint = gazePoint.position.y * screenHeight;

                Console.WriteLine($"Gaze point: {xGazePoint}, {yGazePoint}");
                Console.WriteLine($"Raw gaze: {gazePoint.position.x}, {gazePoint.position.y}");

                int imageX = (int)(xGazePoint * scaleX);
                int imageY = (int)(yGazePoint * scaleY);

                Console.WriteLine($"Image coord: {imageX}, {imageY}");


                if (xGazePoint >= leftX && xGazePoint <= rightX) // Check if  x-coordinate of the gaze point is within bounds of image
                    if(yGazePoint >= topY && yGazePoint <= bottomY) // Check if y-coordinate of the gaze point is within bounds of image
                    {
                        // Calculate screen point of
                        //Point screenPoint = new Point((int)xGazePoint - (redCirclePictureBox.Width / 2), (int)yGazePoint - (redCirclePictureBox.Height / 2));
                        Point screenPoint = new Point((int)xGazePoint, (int)yGazePoint);
                        Point clientPoint = this.PointToClient(screenPoint);

                        if (trailOn)
                        {
                            Console.WriteLine("Drawing image at " + (xGazePoint + " and " + yGazePoint));
                            Point circlePoint = new Point((int)xGazePoint - (redCirclePictureBox.Width / 2), (int)yGazePoint - (redCirclePictureBox.Height / 2));
                            redCirclePictureBox.Location = this.PointToClient(circlePoint);
                        }
                        
                        Console.WriteLine("clientPoint: " + clientPoint);

                        //  Tally gaze point in whichever square  
                        int j = (int)((clientPoint.X - leftX) / scaleX);
                        int i = (int)((clientPoint.Y - topY) / scaleY);
                        if (i < 0)
                            i = 0;
                        if (j < 0)
                            j = 0;
                        Console.WriteLine($"Frequencies ** ({i}, {j})");
                        freq[i, j]++;
                    }
            }
        }

        

        //  End of trial event
        //  15 seconds
        //  Stop timers, make the heatmap
        private void Timer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("TrialForm inside Timer_Tick: Trial over");
            Console.WriteLine("Count: " + count);
            gazePointTimer.Stop();
            trialPeriodTimer.Stop();
            picture.CreateHeatMap(freq);
            
            DownloadForm downloadForm = new DownloadForm();
            this.Hide();
            downloadForm.ShowDialog();

            this.Close();
        }

        private void gazePointTimer_Tick(object sender, EventArgs e)
        {
            gatherGazePoints(deviceContext);
        }
        private void gatherGazePoints(IntPtr deviceContext)
        {

            //  Subscribe to gaze data
            Interop.tobii_wait_for_callbacks(new[] { deviceContext });

            // Process callbacks on this thread if data is available
            Interop.tobii_device_process_callbacks(deviceContext);

            /*      Result returns TOBII_ERROR_NOT_SUBSCRIBED
             *      A subscription for digital syncport data was not made beforethecall to unsubscribe
             *      
            result = Interop.tobii_gaze_data_unsubscribe(deviceContext);
            Debug.Assert(result == tobii_error_t.TOBII_ERROR_NO_ERROR);
            */

            //result = Interop.tobii_device_destroy(deviceContext);
            //Debug.Assert(result == tobii_error_t.TOBII_ERROR_NO_ERROR);
            //result = Interop.tobii_api_destroy(apiContext);
            //Debug.Assert(result == tobii_error_t.TOBII_ERROR_NO_ERROR);
        }

        private Image ResizedImage(Image toResizeImg)
        {
            //  Error handling if image does not exist
            if(toResizeImg == null)
            {
                MessageBox.Show("Resizing image error: image received is null");
                return null;
            }

            int newHeight = 0;
            int newWidth = 0;
            if (toResizeImg.Height > this.ClientSize.Height && toResizeImg.Width > this.ClientSize.Width) // If both height and width are bigger than the screen
            {
                newHeight = this.ClientSize.Height;
                newWidth = (toResizeImg.Width * this.ClientSize.Height) / toResizeImg.Height;
                if (newWidth > this.ClientSize.Width) // If width is still bigger than the screen
                {
                    newWidth = this.ClientSize.Width;
                    newHeight = (toResizeImg.Height * this.ClientSize.Width) / toResizeImg.Width;
                }
            }
            else if (toResizeImg.Width > this.ClientSize.Width) // If width is larger than the screen
            {
                newWidth = this.ClientSize.Width;
                newHeight = (toResizeImg.Height * this.ClientSize.Width) / toResizeImg.Width;
            }
            else                                       // If height is larger than the screen
            {
                newHeight = this.ClientSize.Height;
                newWidth = (toResizeImg.Width * this.ClientSize.Height) / toResizeImg.Height;
            }
            Bitmap resizedBmp = new Bitmap(toResizeImg, newWidth, newHeight);
            return resizedBmp;
        }
    }
}
