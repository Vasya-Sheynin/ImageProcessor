using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;



namespace PKG_v17
{
    public partial class MainWindow : System.Windows.Window
    {
        Mat image;
        private string imagePath = "";
        private int blurSizeVal = 1;
        private int morphSizeVal = 1;
        private MorphShapes shape = MorphShapes.Rect;
        
        public MainWindow()
        {
            InitializeComponent();

            ResizeMode = ResizeMode.NoResize;

            for (int i = 1; i < 100; i += 2) {
                blurBox.Items.Add(i);
            }

            for (int i = 1; i < 100; i++)
            {
                sizeBox.Items.Add(i);
            }

            shapeBox.Items.Add("Rectangle");
            shapeBox.Items.Add("Ellipse");
            shapeBox.Items.Add("Cross");

            blurBox.SelectedIndex = 0;
            blurBtn.IsEnabled = false;

            sizeBox.SelectedIndex = 0;
            shapeBox.SelectedIndex = 0;

            erodeBtn.IsEnabled = false;
            dilateBtn.IsEnabled = false;
            openBtn.IsEnabled = false;
            closeBtn.IsEnabled = false;
        }

        private void selectImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
            }

            if (!string.IsNullOrEmpty(imagePath))
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));

                img.Source = bitmapImage;

                blurBtn.IsEnabled = true;
                erodeBtn.IsEnabled = true;
                dilateBtn.IsEnabled = true;
                openBtn.IsEnabled = true;
                closeBtn.IsEnabled = true;

                image = Cv2.ImRead(imagePath);
            }
        }

        private void blurBtn_Click(object sender, RoutedEventArgs e)
        {
            ApplySmoothingFilter();
        }

        private void blurBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            blurSizeVal = int.Parse(blurBox.SelectedItem.ToString());
        }

        private void sizeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            morphSizeVal = int.Parse(sizeBox.SelectedItem.ToString());
        }

        private void shapeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (shapeBox.SelectedItem.ToString() == MorphShapes.Ellipse.ToString())
            {
                shape = MorphShapes.Ellipse;
            }

            if (shapeBox.SelectedItem.ToString() == MorphShapes.Rect.ToString())
            {
                shape = MorphShapes.Rect;
            }

            if (shapeBox.SelectedItem.ToString() == MorphShapes.Cross.ToString())
            {
                shape = MorphShapes.Cross;
            }
        }

        private void ApplySmoothingFilter()
        {
            Mat bluredImage = new Mat();
            Cv2.GaussianBlur(image, bluredImage, new OpenCvSharp.Size(blurSizeVal, blurSizeVal), 0);
            Cv2.ImShow("Blured image", bluredImage);
            Cv2.WaitKey();
        }

        private void erodeBtn_Click(object sender, RoutedEventArgs e)
        {
            Mat structuringElement = Cv2.GetStructuringElement(shape, new OpenCvSharp.Size(morphSizeVal, morphSizeVal), new OpenCvSharp.Point(-1, -1));
            Mat erodedImage = new Mat();
            Cv2.Erode(image, erodedImage, structuringElement);
            Cv2.ImShow("Eroded image", erodedImage);
            Cv2.WaitKey();
        }

        private void dilateBtn_Click(object sender, RoutedEventArgs e)
        {
            Mat structuringElement = Cv2.GetStructuringElement(shape, new OpenCvSharp.Size(morphSizeVal, morphSizeVal), new OpenCvSharp.Point(-1, -1));
            Mat dilatedImage = new Mat();
            Cv2.Dilate(image, dilatedImage, structuringElement);
            Cv2.ImShow("Dilated image", dilatedImage);
            Cv2.WaitKey();
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            Mat structuringElement = Cv2.GetStructuringElement(shape, new OpenCvSharp.Size(morphSizeVal, morphSizeVal), new OpenCvSharp.Point(-1, -1));
            Mat openedImage = new Mat();
            Cv2.MorphologyEx(image, openedImage, MorphTypes.Open, structuringElement);
            Cv2.ImShow("Opened image", openedImage);
            Cv2.WaitKey();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Mat structuringElement = Cv2.GetStructuringElement(shape, new OpenCvSharp.Size(morphSizeVal, morphSizeVal), new OpenCvSharp.Point(-1, -1));
            Mat closedImage = new Mat();
            Cv2.MorphologyEx(image, closedImage, MorphTypes.Close, structuringElement);
            Cv2.ImShow("Closed image", closedImage);
            Cv2.WaitKey();
        }
    }
}


