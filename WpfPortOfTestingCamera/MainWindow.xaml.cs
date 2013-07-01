using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Windows.Threading;
using AForge;
using AForge.Math.Geometry;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision;
using System.Runtime.InteropServices;


namespace WpfPortOfTestingCamera
{
    public partial class MainWindow : Window
    {
        //Private
        ImageProcessor CamProc;
        VideoCaptureDevice captureDevice;

        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        public MainWindow()
        {
            InitializeComponent();
            CamProc = new ImageProcessor();
            CamProc.NewTargetPosition += new ImageProcessor.NewTargetPositionHandler(CamProc_NewTargetPosition);
            //Dispatcher.BeginInvoke((Action)(() => { Window_Loaded_Settings(); }), DispatcherPriority.Loaded, null);
            Dispatcher.BeginInvoke((Action)Window_Loaded_Settings, DispatcherPriority.Loaded, null);
        }


        void CamProc_NewTargetPosition(IntPoint Center, System.Drawing.Bitmap image)
        {
            IntPtr hBitMap = image.GetHbitmap();
            BitmapSource bmaps = Imaging.CreateBitmapSourceFromHBitmap(hBitMap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bmaps.Freeze();
            Dispatcher.Invoke((Action)(() =>
            {

                if (Center.X > 0)
                {
                    try
                    {

                        

                        prova.Content = String.Format("   Codigo: {0}", Center.X);
                        item.Content = String.Format(" Nº Itens: {0}", Center.Y);
                        TextReader respostas = new StreamReader(@"" + Center.X + ".txt");
                        string R_1 = respostas.ReadLine();
                        string R_2 = respostas.ReadLine();
                        string R_3 = respostas.ReadLine();
                        string R_4 = respostas.ReadLine();
                        string R_5 = respostas.ReadLine();
                        string R_6 = respostas.ReadLine();
                        string R_7 = respostas.ReadLine();
                        string R_8 = respostas.ReadLine();
                        string R_9 = respostas.ReadLine();
                        string R_0 = respostas.ReadLine();
                        item1.Content = String.Format(" Item 01: {0}", R_1);
                        item2.Content = String.Format(" Item 02: {0}", R_2);
                        item3.Content = String.Format(" Item 03: {0}", R_3);
                        item4.Content = String.Format(" Item 04: {0}", R_4);
                        item5.Content = String.Format(" Item 05: {0}", R_5);
                        item6.Content = String.Format(" Item 06: {0}", R_6);
                        item7.Content = String.Format(" Item 07: {0}", R_7);
                        item8.Content = String.Format(" Item 08: {0}", R_8);
                        item9.Content = String.Format(" Item 09: {0}", R_9);
                        item10.Content = String.Format(" Item 10: {0}", R_0);
                        string resps = R_1 + ";" + R_2 + ";" + R_3 + ";" + R_4 + ";" + R_5 + ";" + R_6 + ";" + R_7 + ";" + R_8 + ";" + R_9 + ";" + R_0;
    
                        refer.Content = String.Format("todas: {0}", resps);
                        conexao((int)Center.X, resps);
                        respostas.Close();
                    }
                    catch { }
                }
                pictureBoxMain.Source = bmaps;                
            }), DispatcherPriority.Render, null);
            DeleteObject(hBitMap);
        }

        private void Window_Loaded_Settings()
        {
            InputSelection impdev = new InputSelection();

                captureDevice = impdev.CaptureDevice;
                captureDevice.NewFrame += new NewFrameEventHandler(captureDevice_NewFrame);
                captureDevice.Start();
        }

        void captureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            UnmanagedImage uimage = UnmanagedImage.FromManagedImage(eventArgs.Frame);
            try
            {
                CamProc.Process(uimage);
            }
            catch { }
        }

         void conexao(int codigo, string resposta)
        {
         SQLiteConnection con;

        string sqlitepath = "C:\\Users\\Jefferson\\escola\\db\\development.sqlite3";
             con = new SQLiteConnection("Data Source="+sqlitepath+";Version=3;New=False;");
             con.Open();
             SQLiteCommand cmd = new SQLiteCommand(string.Format("update provas set respostas='{0}' where id={1}", resposta, codigo));
             cmd.ExecuteNonQuery();
            con.Close();
        }
        private void buttonStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (captureDevice.IsRunning)
            {
                captureDevice.SignalToStop();
                Application.Current.Shutdown();
            }
            else
            {
                buttonStartStop.Content = "Parar";
            }
        }
    }
}
