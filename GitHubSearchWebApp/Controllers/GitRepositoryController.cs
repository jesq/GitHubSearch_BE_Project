using GitHubSearchWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHubSearchWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitRepositoryController : ControllerBase
    {
        // GET api/<GitRepositoryController>/5
        [HttpGet("{name}")]
        public IEnumerable<GitRepository> Get(string name)
        {
            var client = new RestClient("https://api.github.com/search/repositories");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET)
                                .AddQueryParameter("q", name)
                                .AddParameter("per_page", "10")
                                .AddParameter("page","1")
                                .AddParameter("sort", "updated")
                                .AddParameter("order", "asc");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToGitRepositories(response.Content);
        }

        private IEnumerable<GitRepository> ConvertResponseToGitRepositories(string content)
        {
            var json = JObject.Parse(content);

            long resultSize = json.Value<long>("total_count");
            if ( resultSize == 0 )
            {
                return new List<GitRepository>();
            }

            return Enumerable.Range(1, 10).Select(index =>
            {
                var repository = json["items"][index - 1];
                var owner = json["items"][0]["owner"];
                return new GitRepository
                {
                    Id = index,
                    Name = repository.Value<string>("full_name"),
                    HtmlUrl = repository.Value<string>("html_url"),
                    Owner = new Owner(owner.Value<string>("login"), owner.Value<string>("avatar_url"))
                };
            });
        }
    }
}
