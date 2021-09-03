using GitHubSearchWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHubSearchWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitRepositoryController : ControllerBase
    {
        // GET: api/<GitRepositoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

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

            return Enumerable.Range(1, 10).Select(index =>
           {
               var repository = json["items"][index - 1];
               return new GitRepository
               {
                   Id = index,
                   Name = repository.Value<string>("full_name"),
                   HtmlUrl = repository.Value<string>("html_url")
               };
           });
        }
    }
}
