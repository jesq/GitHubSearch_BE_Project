using Microsoft.AspNetCore.Mvc;
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
        public string Get(string name)
        {
            return "value";
        }
    }
}
