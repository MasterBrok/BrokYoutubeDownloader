using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BrokYoutubeDownloader.Windows
{
    /// <summary>
    /// Interaction logic for wUsMessageBox.xaml
    /// </summary>
    public partial class wUsMessageBox : Window
    {
        public wUsMessageBox(string Message)
        {
            InitializeComponent();
            lblMessage.Value = Message;
        }
        public bool isClose { get; set; }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void ccButton_Click(object sender, RoutedEventArgs e)
        {
            isClose = true;
            this.Close();
        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isClose = false;
            this.Close();
        }
    }
}
