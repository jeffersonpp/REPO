using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using AForge;
using AForge.Math.Geometry;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision;

namespace WpfPortOfTestingCamera
{
    /// <summary>
    /// Interaction logic for InputSelection.xaml
    /// </summary>
    public partial class InputSelection : Window
    {
        VideoCaptureDevice _captureDevice;
        FilterInfoCollection _videoDevices;

        public VideoCaptureDevice CaptureDevice
        {
            get
            {
                return _captureDevice;
            }
        }
        public InputSelection()
        {
            try
            {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                
            _captureDevice = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            }
            catch (ApplicationException)
            { MessageBox.Show("Sem camera"); }
        }
       
    }
}
