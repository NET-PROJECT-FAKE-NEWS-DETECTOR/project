using HtmlAgilityPack;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Pages;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HarvestingController : ControllerBase
    {

        [Route("Harvesting")]
        [HttpPost]
        public List<string> Harvesting(string url)
        {
            url = HttpUtility.UrlDecode(url);
            var response = CallUrl(url).Result;
            System.Console.WriteLine(url);
            var news = ParseHtml(response);
            
            return news;
        }
        private List<string> ParseHtml(string html)
        {
            // titlu, text, subiect, data
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var title = htmlDoc.DocumentNode.SelectSingleNode("//head/title").InnerText;
            //var date = htmlDoc.DocumentNode.SelectSingleNode("//div[@class = 'col-12 text-left author']").InnerText;
            var texts = htmlDoc.DocumentNode.SelectNodes("//article//p/text()");
            string body = System.String.Empty;
            foreach (var text in texts)
            {
                body += text.InnerText;
            }
            // var jsons = htmlDoc.DocumentNode.SelectNodes("//script[@type = 'application/ld+json']");
            // JObject json = new JObject();
            // json = JObject.Parse(jsons[3].InnerText);
            // var date = json.GetValue("datePublished").ToString();
            // var text = json.GetValue("articleBody").ToString();
            List<string> news = new List<string>();
            news.Add(title);
            news.Add(body);
            return news;
        }
        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }

    }
}