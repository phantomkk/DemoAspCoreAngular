using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Demo.Business
{
    public class VozImageService : IVozImageService
    {
        //private ILogger _logger;
        //public VozImageService(ILogger logger)
        //{
        //    _logger = logger;
        //}
        public async Task<List<string>> LoadAllPages(string url)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            var html = await GetPageHtmlAsync(url);
            htmlDoc.LoadHtml(html);

            var navNode = htmlDoc.DocumentNode.SelectNodes("//td[@class='vbmenu_control' and not(*)]").First(); var lastPage = 1;
            if (navNode != null)
            {
                var innerText = navNode.InnerText;
                lastPage = int.Parse(GetDigitChars(innerText)[1]);
            }

            var results = new List<List<string>>();
            for (var page = 1; page <= lastPage; page++)
            {
                var date = DateTimeOffset.Now.AddSeconds(1);
                await Task.Delay(500);
                var fullUrl = $"{url}&page={page}";
                results.Add(LoadPageUrl(fullUrl));
            }
            return results.SelectMany(x => x.ToList()).ToList();
        }



        private async Task<string> GetPageHtmlAsync(string url)
        {
            RestClient restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = await restClient.ExecuteGetTaskAsync(request);
            if (response.ErrorException != null)
            {
                //   _logger.LogError(response.ErrorException.Message);
                //////// _logger.LogError(response.ErrorException.StackTrace);
            }
            return response.Content;
        }

        private List<string> LoadPageUrl(string topicUrl)
        {
            var urls = LoadUrls(topicUrl);
            return urls;
        }

        public List<string> LoadUrls(string topicUrl)
        {
            var web = new HtmlWeb();
            var htmlDoc = web.Load(topicUrl);
            var divPost = htmlDoc.DocumentNode.SelectNodes("//div[@class='voz-post-message']//img[@alt='' and not(@class)]");
            List<string> images = new List<string>();
            if (divPost != null)
            {
                foreach (var post in divPost)
                {
                    var url = post.Attributes["src"].Value;
                    if (!string.IsNullOrEmpty(url) && url.Contains("http"))
                    {
                        images.Add(url);
                    }
                }
            }
            return images;
        }

        private string[] GetDigitChars(string text)
        {
            string[] strs = new string[2];
            var digitContinue = false;
            var currentIndex = -1;
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    if (!digitContinue)
                    {
                        currentIndex++;
                    }
                    strs[currentIndex] += c;
                    digitContinue = true;
                }
                else
                {
                    digitContinue = false;
                }
            }
            return strs;
        }
    }
}
