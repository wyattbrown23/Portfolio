using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace PortfolioBlazorApp
{
    public class ProjectApiService
    {
        private readonly HttpClient client;

        public ProjectApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task SaveProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("api/project", project);
        }

        public async Task DeleteProjectAsync(Project project)
        {
            await client.DeleteAsync($"/api/project/deleteproject/{project.Id}");
        }

        public async Task UpdateProjectDetails(Project project)
        {
            await client.PostAsJsonAsync("api/project/update", project);
        }

        public async Task AssignAsync(string categoryType, int projectId, string newName)
        {
            var assignBody = new AssignRequest
            {
                CategoryType = categoryType,
                Name = newName,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync($"api/project/assign", assignBody);
        }
    }
}
