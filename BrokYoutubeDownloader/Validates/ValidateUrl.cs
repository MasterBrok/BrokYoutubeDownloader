using System.Text.RegularExpressions;

namespace BrokYoutubeDownloader.Validates
{
    public class ValidateUrl
    {
        public static bool IsYouTubeLinkValid(string link)
        {
            string youtubePattern = @"^(https?://)?(www\.)?(youtube\.com|youtu\.be)/.+";

            Regex regex = new Regex(youtubePattern);
            return regex.IsMatch(link);
        }
    }
}
