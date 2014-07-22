using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading;
namespace TaskyWinPhone
{
    public partial class PageAssinatura : PhoneApplicationPage
    {
        #region Constructor
        public PageAssinatura()
        {
            InitializeComponent();
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }
        #endregion

        #region Variáveis
        // preXArray and preYArray are used to store the start point 
        // for each touch point. currently silverlight support 4 muliti-touch
        // here declare as 10 points for further needs. 
        double[] preXArray = new double[10];
        double[] preYArray = new double[10];
        #endregion

        #region Touch_FrameReported
        /// <summary>
        /// Toda ação de toque vai subir esse manipulador de eventos. 
        /// </summary>
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            int pointsNumber = e.GetTouchPoints(drawCanvas).Count;
            TouchPointCollection pointCollection = e.GetTouchPoints(drawCanvas);

            for (int i = 0; i < pointsNumber; i++)
            {
                if (pointCollection[i].Action == TouchAction.Down)
                {
                    preXArray[i] = pointCollection[i].Position.X;
                    preYArray[i] = pointCollection[i].Position.Y;
                }
                if (pointCollection[i].Action == TouchAction.Move)
                {
                    Line line = new Line();

                    line.X1 = preXArray[i];
                    line.Y1 = preYArray[i];
                    line.X2 = pointCollection[i].Position.X;
                    line.Y2 = pointCollection[i].Position.Y;

                    line.Stroke = new SolidColorBrush(Colors.Black);
                    line.Fill = new SolidColorBrush(Colors.Black);
                    drawCanvas.Children.Add(line);

                    preXArray[i] = pointCollection[i].Position.X;
                    preYArray[i] = pointCollection[i].Position.Y;
                }
            }
        }
        #endregion

        #region Salve Click
        /// <summary>
        /// Salva a imagem na biblioteca de imagens
        /// </summary>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MediaLibrary library = new MediaLibrary();
            WriteableBitmap bitMap = new WriteableBitmap(drawCanvas, null);
            MemoryStream ms = new MemoryStream();
            Extensions.SaveJpeg(bitMap, ms, bitMap.PixelWidth,
                                bitMap.PixelHeight, 0, 100);
            ms.Seek(0, SeekOrigin.Begin);
            library.SavePicture(string.Format("Images\\{0}.jpg",
                                               Guid.NewGuid()), ms);
            New_Click(sender, e);
        }
        #endregion

        #region Novo Click
        private void New_Click(object sender, RoutedEventArgs e)
        {
            drawCanvas.Children.Clear();
        } 
        #endregion
    }
}