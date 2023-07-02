using BrokYoutubeDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace BrokYoutubeDownloader.YoutubeDownloader
{
    public class Download
    {
        YoutubeClient youtube;

        public string Link { get; set; }
        public Download()
        {
            youtube = new YoutubeClient();
        }
        public Download(string link)
        {
            Link = link;
            youtube = new YoutubeClient();
        }

        /// <summary>
        /// Get info Video
        /// </summary>
        /// <returns></returns>
        public async ValueTask<Models.Video> GetInfo()
        {
            var info = await youtube.Videos.GetAsync(Link);
            var video = new Models.Video();
            video.Title = info.Title;
            video.Channel = info.Author.ChannelTitle;
            video.Name = "Brok";
            video.Link = info.Url;
            video.Duration = info.Duration.ToString();
            video.Description = info.Description;
            video.DateUpload = info.UploadDate.ToString();
            return video;
        }
    }
}
