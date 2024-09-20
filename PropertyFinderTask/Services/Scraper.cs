using PropertyFinderTask.Models;
using PropertyFinderTask.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyFinderTask.Services
{
    public class Scraper : IScrapper
    {
        public List<Task<string>> Scrape(string[] files)
        {
            List<Task<string>> result = new List<Task<string>>();
            for (int i = 0; i < files.Length; i++)
            {
                FileType fileType = UrlUtil.GetExtension(files[i]);
                string url = UrlUtil.GetMockServerUrl(files[i]);
                result.Add(ScrapeSingleFile(fileType, url));
            }
            return result;
        }

        public async Task<string> ScrapeSingleFile(FileType fileType, string filePath)
        {
            if (!UrlUtil.IsValidUrl(filePath)) return FileUtil.BuildErrorMessage(Constants.INVALID_URL, filePath).Result.Message;
            if (!UrlUtil.IsValidFile(filePath)) return FileUtil.BuildErrorMessage(Constants.UNSUPPORTED_TYPE, filePath).Result.Message;

            FileResponse fileResponse = FileUtil.ReadFile(filePath, fileType).Result;
            if (fileResponse.IsSuccess)
            {
                if (string.IsNullOrWhiteSpace(fileResponse.Content)) return FileUtil.BuildErrorMessage(Constants.EMPTY_CONTENT, filePath).Result.Message;
                return await FileUtil.ExtractTitle(fileResponse.Content, fileType);
            }
            else
            {
                return FileUtil.BuildErrorMessage(Constants.FILE_NOT_FOUND, filePath).Result.Message;
            }
        }
    }
}
