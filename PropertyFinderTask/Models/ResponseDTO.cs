using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinderTask.Models
{
    public class ResponseDTO
    {
        public string Message { set; get; }
        public string URL { set; get; }

        public ResponseDTO(string message, string url)
        {
            Message = message;
            URL = url;
        }

    }
}
