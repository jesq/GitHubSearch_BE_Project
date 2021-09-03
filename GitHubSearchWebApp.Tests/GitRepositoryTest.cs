using GitHubSearchWebApp.Controllers;
using GitHubSearchWebApp.Models;
using System;
using System.Collections;
using System.IO;
using Xunit;

namespace GitHubSearchWebApp.Tests
{
    public class GitRepositoryTest
    {
        [Fact]
        public void ConvertResponseToToGitRepositoriesNameTest()
        {
            //Asume
            string content = LoadJsonFromResource1();
            var controller = new GitRepositoryController();

            // Act
            var output = controller.ConvertResponseToGitRepositories(content);

            // Assert
            var gitName = ((GitRepository[])output)[0];
            Assert.Equal("jnewland/gsa-prototype", gitName.Name);
        }
    
        [Fact]
        public void ConvertResponseToToGitRepositoriesHtmlUrlTest()
        {
            //Asume
            string content = LoadJsonFromResource1();
            var controller = new GitRepositoryController();

            // Act
            var output = controller.ConvertResponseToGitRepositories(content);

            // Assert
            var gitHtmlUrl = ((GitRepository[])output)[0];
            Assert.Equal("https://github.com/jnewland/gsa-prototype", gitHtmlUrl.HtmlUrl);
        }
        private string LoadJsonFromResource1()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromGitRepoApi.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
