using PropertyFinderTask.Models;
using System.IO;

namespace PropertyFinderTask.Util
{
    public class UrlUtil
    {
        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;
            return true;
        }

        public static bool IsValidFile(string url)
        {
            if (GetExtension(url) == FileType.Unknown) return false;
            return true;
        }

        public static FileType GetExtension(string fileName)
        {
            switch (Path.GetExtension(fileName))
            {
                case Constants.HTML_EXTENSION:
                    return FileType.Html;
                case Constants.JSON_EXTENSION:
                    return FileType.Json;
                // TODO case handle ".pdf"
                // TODO case handle ".txt"
                default:
                    return FileType.Unknown;
            }
        }

        public static string GetMockServerUrl(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), Constants.MOCK_SERVER, fileName);
        }
    }
}
