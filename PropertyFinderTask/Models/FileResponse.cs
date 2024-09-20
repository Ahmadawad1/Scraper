using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinderTask.Models
{
    public class FileResponse
    {
        public string Content { set; get; }
        public bool IsSuccess { set; get; }

        public FileResponse(string content, bool success)
        {
            IsSuccess = success;
            Content = content;
        }

    }
}
