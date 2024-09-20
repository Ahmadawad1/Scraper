using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyFinderTask.Services
{
    public interface IScrapper
    {
        List<Task<string>> Scrape(string[] urls);
    }
}
