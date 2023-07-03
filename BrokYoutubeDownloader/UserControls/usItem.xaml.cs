using BrokYoutubeDownloader.Models;
using BrokYoutubeDownloader.YoutubeDownloader;
using System;
using System.Diagnostics;
using System.Linq;
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
            video = await download.GetInfo();
            this.DataContext = video;


            var youtube = new YoutubeClient();
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(_url);
            var streamInfo = streamManifest
    .GetVideoOnlyStreams()
    .Where(s => s.Container == Container.Mp4)
    .GetWithHighestVideoQuality();
            var stream = await youtube.Videos.Streams.GetAsync(streamInfo);


            Progress<double> progress = new Progress<double>();

            progress.ProgressChanged += Progress_ProgressChanged;
            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}", progress);

        }

        private void Progress_ProgressChanged(object? sender, double e)
        {
            progValue.ValueRect = e * 100;
            lbl.Title = progValue.ValueRect + "";
        }
    }
}
