using BrokYoutubeDownloader.Models;
using BrokYoutubeDownloader.YoutubeDownloader;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace BrokYoutubeDownloader.UserControls
{
    /// <summary>
    /// Interaction logic for usItem.xaml
    /// </summary>
    public partial class usItem : UserControl
    {
        private Models.Video video = new Models.Video();
        private string _url;
        public usItem(string url)
        {
            InitializeComponent();
            _url = url;
        }

        public double ProValue
        {
            get { return (double)GetValue(ProValueProperty); }
            set { SetValue(ProValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProValueProperty =
            DependencyProperty.Register("ProValue", typeof(double), typeof(usItem), new PropertyMetadata(default));


        public object MyTag
        {
            get { return (object)GetValue(MyTagProperty); }
            set { SetValue(MyTagProperty, value); }
        }
        public static readonly DependencyProperty MyTagProperty =
            DependencyProperty.Register("MyTag", typeof(object), typeof(usItem), new PropertyMetadata(default));


        public event EventHandler<EventArgs> Path_Click;
        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (Path_Click != null)
            {
                Path_Click(sender, e);
            }
        }

        private async void wMain_Loaded(object sender, RoutedEventArgs e)
        {   
            Download download = new Download(_url);
            this.DataContext = await download.GetInfo();
        }
    }
}
