﻿using System;
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


        [HttpGet("[action]/{slug}")]
        public async Task<LanguageViewModel> GetLangaugesWithProjectsBySlug(string slug)
        {
            try
            {
                var language = await repository.Languages
                .Include(l => l.ProjectLanguages)
                    .ThenInclude(pl => pl.Project)
                .FirstOrDefaultAsync(l => l.Slug == slug);

                return new LanguageViewModel(language);
            }
            catch
            {
                throw;
            }
            
        }

        [HttpGet("[action]/{slug}")]
        public async Task<PlatformViewModel> GetPlatformsWithProjectsBySlug(string slug)
        {
            try
            {
                var platform = await repository.Platforms
               .Include(p => p.ProjectPlatforms)
                   .ThenInclude(pp => pp.Project)
               .FirstOrDefaultAsync(p => p.Slug == slug);

                return new PlatformViewModel(platform);
            }
            catch
            {
                throw;
            }
           
        }

        [HttpGet("[action]/{slug}")]
        public async Task<TechnologyViewModel> GetTechnologiesWithProjectsBySlug(string slug)
        {
            try
            {
                var technology = await repository.Technologies
                .Include(t => t.ProjectTechnologies)
                    .ThenInclude(pt => pt.Project)
                .FirstOrDefaultAsync(t => t.Slug == slug);

                return new TechnologyViewModel(technology);
            }
            catch
            {
                throw;
            }
            
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
