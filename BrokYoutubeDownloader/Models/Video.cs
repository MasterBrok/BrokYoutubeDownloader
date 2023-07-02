using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokYoutubeDownloader.Models
{
    public  class Video
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Channel { get; set; }
        public string Size { get; set; }
        public string DateUpload { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
