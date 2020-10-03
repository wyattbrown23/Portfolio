using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared.ViewModels;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository repository;

        public CategoryController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("[action]")]
        public async Task<List<LanguageViewModel>> GetLanguages()
        {
            return await repository.Languages
                .Select(p => new LanguageViewModel(p))
                .ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<List<PlatformViewModel>> GetPlatforms()
        {
            return await repository.Platforms
                .Select(p => new PlatformViewModel(p))
                .ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<List<TechnologyViewModel>> GetTechnologies()
        {
            return await repository.Technologies
                .Select(p => new TechnologyViewModel(p))
                .ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<List<LanguageViewModel>> GetLangaugesWithProjects()
        {
            return await repository.Languages
                .Include(l => l.ProjectLanguages)
                    .ThenInclude(pl => pl.Project)
                    .Select(p => new LanguageViewModel(p))
                .ToListAsync();
        }


        [HttpGet("[action]/{id}")]
        public async Task<LanguageViewModel> GetLangaugesWithProjectsById(int id)
        {
            var language = await repository.Languages
                .Include(l => l.ProjectLanguages)
                    .ThenInclude(pl => pl.Project)
                .FirstOrDefaultAsync(l => l.Id == id);

            return new LanguageViewModel(language);
        }

        [HttpGet("[action]/{id}")]
        public async Task<PlatformViewModel> GetPlatformsWithProjectsById(int id)
        {
            var platform = await repository.Platforms
                .Include(p => p.ProjectPlatforms)
                    .ThenInclude(pp => pp.Project)
                .FirstOrDefaultAsync(p => p.Id == id);

            return new PlatformViewModel(platform);
        }

        [HttpGet("[action]/{id}")]
        public async Task<TechnologyViewModel> GetTechnologiesWithProjectsById(int id)
        {
            var technology = await repository.Technologies
                .Include(t => t.ProjectTechnologies)
                    .ThenInclude(pt => pt.Project)
                .FirstOrDefaultAsync(t => t.Id == id);

            return new TechnologyViewModel(technology);
        }

        [HttpGet("[action]")]
        public async Task<List<PlatformViewModel>> GetPlatformsWithProjects()
        {
            return await repository.Platforms
                .Include(p => p.ProjectPlatforms)
                .ThenInclude(pp => pp.Project)
                .Select(p => new PlatformViewModel(p))
                .ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<List<TechnologyViewModel>> GetTechnologiesWithProjects()
        {
            return await repository.Technologies
                .Include(t => t.ProjectTechnologies)
                .ThenInclude(pt => pt.Project)
                .Select(p => new TechnologyViewModel(p))
                .ToListAsync();
        }
    }
}
