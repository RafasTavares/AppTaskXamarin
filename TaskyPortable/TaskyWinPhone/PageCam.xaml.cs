using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework.Media;
using Microsoft.Devices;
using Windows.Phone.Media.Capture;

namespace TaskyWinPhone
{
    public partial class PageCam : PhoneApplicationPage
    {
        #region Variáveis
        private PhotoCamera _cam;
        private double _canvasWidth;
        private double _canvasHeight;
        private MediaLibrary _library = new MediaLibrary();
        #endregion

        #region Constructor
        public PageCam()
        {
            InitializeComponent();
        }
        #endregion

        #region On Navigated To
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if ((PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true) ||
                 (PhotoCamera.IsCameraTypeSupported(CameraType.FrontFacing) == true))
            {
                if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary))
                {
                    _cam = new Microsoft.Devices.PhotoCamera(CameraType.Primary);
                    _cam.Initialized += new EventHandler<CameraOperationCompletedEventArgs>(cam_Initialized);
                    _cam.CaptureImageAvailable += new EventHandler<ContentReadyEventArgs>(cam_CaptureImageAvailable);
                    viewfinderBrush.SetSource(_cam);

                    CameraButtons.ShutterKeyPressed += OnButtonFullPress;
                }
            }
        }
        #endregion

        #region Get Camera aspect ratio
        private double GetCameraAspectRatio()
        {
            IEnumerable<Size> resList = _cam.AvailableResolutions;

            if (resList.Count<Size>() > 0)
            {
                Size res = resList.ElementAt<Size>(1);
                return res.Width / res.Height;
            }

            return 1;
        }
        #endregion

        #region Cam Initialized - Define o tamanho da camera
        void cam_Initialized(object sender, Microsoft.Devices.CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                this.Dispatcher.BeginInvoke(delegate()
                {
                  //  _canvasHeight = Application.Current.Host.Content.ActualWidth;
                 //   _canvasWidth = _canvasHeight * GetCameraAspectRatio();

                    viewfinderCanvas.Width = 1000;
                    viewfinderCanvas.Height = 700;
                });
            }
        }
        #endregion

        #region captura da imagem
        void cam_CaptureImageAvailable(object sender, Microsoft.Devices.ContentReadyEventArgs e)
        {
            string fileName = "example.jpg";
            try
            {   
                // Salva a foto na biblioteca da camera
                _library.SavePictureToCameraRoll(fileName, e.ImageStream);
            }
            finally
            {
                // Close image stream
                e.ImageStream.Close();
            }
        }
        #endregion

        #region Disparo do botão da camera
        private void OnButtonFullPress(object sender, EventArgs e)
        {
            if (_cam != null)
            {
                _cam.CaptureImage();
            }
        }
        #endregion

        #region Click Botão da tela
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnButtonFullPress(sender, e);
        }
        #endregion
    }
}