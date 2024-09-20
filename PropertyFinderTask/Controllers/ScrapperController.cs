using Microsoft.AspNetCore.Mvc;
using PropertyFinderTask.Services;
using PropertyFinderTask.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyFinderTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapperController : ControllerBase
    {
        private readonly SemaphoreSlim _semaphore;
        private readonly IScrapper _scraper;
        public ScrapperController(IScrapper scrapper)
        {
            _semaphore = new SemaphoreSlim(10);
            _scraper = scrapper;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] string[] fileNames)
        {
            if (fileNames == null || fileNames.Length == 0)
            {
                return BadRequest(Constants.EMPTY_PAYLOAD);
            }

            await _semaphore.WaitAsync();
            try
            {
                List<Task<string>> tasks = _scraper.Scrape(fileNames);
                string[] results = await Task.WhenAll(tasks);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, Constants.GENERIC_ERROR);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
