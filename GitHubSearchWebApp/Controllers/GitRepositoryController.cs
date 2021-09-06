using GitHubSearchWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

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

            string contentFromServer = GetContentFromServer(name);
            return ConvertServerContentToGitRepositories(contentFromServer);
        }

        private static string GetContentFromServer( string name )
        {
            var client = new RestClient("https://api.github.com/search/repositories");
            client.Timeout = -1;
            IRestRequest request = FormRequest(name);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        private static IRestRequest FormRequest(string name)
        {
            return new RestRequest(Method.GET)
                                            .AddQueryParameter("q", name)
                                            .AddParameter("per_page", "10")
                                            .AddParameter("page", "1")
                                            .AddParameter("sort", "updated")
                                            .AddParameter("order", "asc");
        }
        
       [NonAction]
       public IEnumerable<GitRepository> ConvertServerContentToGitRepositories(string contentfromServer)
        {
            var searchResultJson = JObject.Parse(contentfromServer);

            long resultTotalCount = searchResultJson.Value<long>("total_count");
            if ( resultTotalCount == 0 )
            {
                return new List<GitRepository>();
            }

            return Enumerable.Range(1, 10).Select(index =>
            {
                var repository = searchResultJson["items"][index - 1];
                var owner = searchResultJson["items"][index-1]["owner"];
                return new GitRepository
                {
                    Id = index,
                    Name = repository.Value<string>("full_name"),
                    HtmlUrl = repository.Value<string>("html_url"),
                    Username = owner.Value<string>("login"),
                    AvatarUrl = owner.Value<string>("avatar_url")
                };
            })
            .ToArray();
        }
    }
}
