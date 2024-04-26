using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ImageProcessingApp
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private OpenFileDialog openFileDialog;

        public Form1()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog
            {
                Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*",
                FilterIndex = 1
            };
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var imagePath = openFileDialog.FileName;
                originalImage = new Bitmap(imagePath);
                PictureBox.Image = originalImage;
            }
        }

        private void ApplyFiltersButton_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            var tasks = new Task[4];
            var thresholdedImage = new Bitmap(originalImage);
            var negatedImage = new Bitmap(originalImage);
            var brightenedImage = new Bitmap(originalImage);
            var edgesImage = new Bitmap(originalImage);

            tasks[0] = Task.Run(() => ApplyThresholding(thresholdedImage));
            tasks[1] = Task.Run(() => ApplyNegate(negatedImage));
            tasks[2] = Task.Run(() => ApplyBrightnessAdjustment(brightenedImage, 50));
            tasks[3] = Task.Run(() => ApplyEdgeDetection(edgesImage));

            Task.WaitAll(tasks);

            PictureBoxThresholded.Image = thresholdedImage;
            PictureBoxNegated.Image = negatedImage;
            PictureBoxBrightened.Image = brightenedImage;
            PictureBoxEdges.Image = edgesImage;
        }

        private void ApplyThresholding(Bitmap bitmap, byte threshold = 128)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    var gray = (byte)((color.R + color.G + color.B) / 3);

                    if (gray > threshold)
                    {
                        bitmap.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, Color.Black);
                    }
                }
            }
        }

        private void ApplyNegate(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            for (int x = 0; x< width; x++)
            {
                for (int y = 0;  y < height; y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    var negatedColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
                    bitmap.SetPixel(x, y, negatedColor);
                }
            }
        }

        private void ApplyBrightnessAdjustment(Bitmap bitmap, int adjustment)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    var adjustedColor = Color.FromArgb(
                        Clamp(color.R + adjustment, 0, 255),
                        Clamp(color.G + adjustment, 0, 255),
                        Clamp(color.B + adjustment, 0, 255));
                    bitmap.SetPixel(x, y, adjustedColor);
                }
            }
        }

        private void ApplyEdgeDetection(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            int[,] kernel = new int[,]
            {
                {-1, -1, -1 },
                { -1, 8, -1 },
                {-1, -1, -1 }
            };

            Bitmap tempBitmap = new Bitmap(bitmap);

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            var color = tempBitmap.GetPixel(x + i, y + j);
                            r += color.R * kernel[i + 1, j + 1];
                            g += color.G * kernel[i + 1, j + 1];
                            b += color.B * kernel[i + 1, j + 1];
                        }
                    }

                    var edgeColor = Color.FromArgb(
                        Clamp(r, 0, 255),
                        Clamp(g, 0, 255),
                        Clamp(b, 0, 255));
                    bitmap.SetPixel(x, y, edgeColor);
                }
            }
        }

        private int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }
}
