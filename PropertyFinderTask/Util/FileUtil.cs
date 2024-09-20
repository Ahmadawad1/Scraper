using HtmlAgilityPack;
using Newtonsoft.Json;
using PropertyFinderTask.Models;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace PropertyFinderTask.Util
{
    public static class FileUtil
    {
        public static Task<FileResponse> ReadFile(string filePath, FileType fileType)
        {    
            switch (fileType)
            {
                case FileType.Json:
                    return ReadLocalFileAsync(filePath);
                case FileType.Html:
                    return ReadLocalFileAsync(filePath);
                default:
                    return null;
            }
        }

        public static async Task<FileResponse> ReadLocalFileAsync(string filePath)
        {
            if (!File.Exists(filePath)) return new FileResponse(null, false) ;

            string content = await File.ReadAllTextAsync(filePath);
            return new FileResponse(content, true);
        }

        public static Task<string> ExtractTitle(string response, FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Json:
                    return ProcessJsonResponse(response);
                case FileType.Html:
                    return ProcessHtmlResponse(response);
                // TODO case .. (".pdf")
                // TODO case .. (".txt")
                default:
                    return null;
            }
        }
        private static async Task<string> ProcessJsonResponse(string jsonString)
        {
            dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            var title = (string)jsonObject.title;
    
            return title;
        }

        private static async Task<string> ProcessHtmlResponse(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);
            var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
            var headerText = h1Node?.InnerText;

            return headerText;
        }
        public static async Task<ResponseDTO> BuildErrorMessage(string errorMessage, string url)
        {
            return new ResponseDTO(errorMessage, url);
        }
    }
}
