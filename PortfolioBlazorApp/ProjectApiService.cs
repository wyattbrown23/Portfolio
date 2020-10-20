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

        public async Task<IList<Project>> GetProjectsAsync()
        {
            var response = await client.GetAsync("api/project");
            return await client.GetFromJsonAsync<IList<Project>>("api/project");
        }

        public async Task SaveProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("api/project", project);
        }

        public async Task UpdateProjectDetails(Project project)
        {
            await client.PostAsJsonAsync("api/project/update", project);
        }

        public async Task<ProjectViewModel> GetProjectByIDAsync(int id)
        {
            return await client.GetFromJsonAsync<ProjectViewModel>($"api/project/projectdetails/{id}");
        }

        public async Task<ProjectViewModel> GetProjectBySlugAsync(string slug)
        {
            return await client.GetFromJsonAsync<ProjectViewModel>($"api/project/projectdetails/{slug}");
        }

        public async Task<List<LanguageViewModel>> GetLanguages()
        {
            var response = await client.GetAsync("api/category/getlanguages");
            return await client.GetFromJsonAsync<List<LanguageViewModel>>("api/category/getlanguages");
        }

        public async Task<List<PlatformViewModel>> GetPlatforms()
        {
            var response = await client.GetAsync("api/category/getplatforms");
            return await client.GetFromJsonAsync<List<PlatformViewModel>>("api/category/getplatforms");
        }

        public async Task<List<TechnologyViewModel>> GetTechnologies()
        {
            var response = await client.GetAsync("api/category/gettechnologies");
            return await client.GetFromJsonAsync<List<TechnologyViewModel>>("api/category/gettechnologies");
        }

        public async Task<LanguageViewModel> GetLangaugesWithProjectsBySlug(string slug)
        {
          
            var response = await client.GetAsync($"api/category/GetLangaugesWithProjectsBySlug/{slug}");
            return await client.GetFromJsonAsync<LanguageViewModel>($"api/category/GetLangaugesWithProjectsBySlug/{slug}");

        }

        public async Task<PlatformViewModel> GetPlatformsWithProjectsBySlug(string slug)
        {

            var response = await client.GetAsync($"api/category/GetPlatformsWithProjectsBySlug/{slug}");
            return await client.GetFromJsonAsync<PlatformViewModel>($"api/category/GetPlatformsWithProjectsBySlug/{slug}");

        }

        public async Task<TechnologyViewModel> GetTechnologiesWithProjectsBySlug(string slug)
        {

            var response = await client.GetAsync($"api/category/GetTechnologiesWithProjectsBySlug/{slug}");
            return await client.GetFromJsonAsync<TechnologyViewModel>($"api/category/GetTechnologiesWithProjectsBySlug/{slug}");

        }

        public async Task<List<LanguageViewModel>> GetLangaugesWithProjects()
        {
            var response = await client.GetAsync($"api/category/GetLangaugesWithProjects");
            return await client.GetFromJsonAsync<List<LanguageViewModel>>($"api/category/GetLangaugesWithProjects");
        }

        public async Task<List<PlatformViewModel>> GetPlatformsWithProjects()
        {
            var response = await client.GetAsync($"api/category/GetPlatformsWithProjects");
            return await client.GetFromJsonAsync<List<PlatformViewModel>>($"api/category/GetPlatformsWithProjects");
        }

        public async Task<List<TechnologyViewModel>> GetTechnologiesWithProjects()
        {
            var response = await client.GetAsync($"api/category/GetTechnologiesWithProjects");
            return await client.GetFromJsonAsync<List<TechnologyViewModel>>($"api/category/GetTechnologiesWithProjects");
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
