using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubSearchWebApp.Models
{
    public class Owner
    {
        public string Username { get; set; }

        public string AvatarUrl { get; set; }

        public Owner(string username, string avatarUrl)
        {
            Username = username;
            AvatarUrl = avatarUrl;
        }
    }
}
