﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<IEnumerable<ProjectViewModel>> Get()
        {
            return await repository.Projects
                .Include(p => p.ProjectTechnologies)
                   .ThenInclude(pc => pc.Technology)
                 .Include(p => p.ProjectPlatforms)
                   .ThenInclude(pc => pc.Platform)
                .Include(p => p.ProjectLanguages)
                    .ThenInclude(pc => pc.Language)
                .Select(p => new ProjectViewModel(p))
                .ToListAsync();
        } 

        [HttpPost()]
        [Authorize()]
        public async Task Post(ProjectViewModel project)
        {
            await repository.SaveProjectAsync(project);
        }

        //[HttpGet("projectdetails/{id}")]
        //public async Task<ProjectViewModel> GetProjectDetailsById(int id)
        //{
        //    var project = await repository.Projects
        //        .Include(p => p.ProjectTechnologies)
        //           .ThenInclude(pc => pc.Technology)
        //        .Include(p => p.ProjectPlatforms)
        //           .ThenInclude(pc => pc.Platform)
        //       .Include(p => p.ProjectLanguages)
        //           .ThenInclude(pc => pc.Language)
        //        .FirstOrDefaultAsync(p => p.Id == id);

        //    return new ProjectViewModel(project);
        //}

        [HttpGet("projectdetails/{slug}")]
        public async Task<ProjectViewModel> GetProjectDetailsBySlug(string slug)
        {
            try
            {
                var project = await repository.Projects
                .Include(p => p.ProjectTechnologies)
                   .ThenInclude(pc => pc.Technology)
                .Include(p => p.ProjectPlatforms)
                   .ThenInclude(pc => pc.Platform)
               .Include(p => p.ProjectLanguages)
                   .ThenInclude(pc => pc.Language)
                    .FirstOrDefaultAsync(p => p.Slug == slug);
                return new ProjectViewModel(project);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteProject(int id)
        {
            await repository.DeleteProjectAsync(id);
        }

        [HttpPost("Update")]
        [Authorize(Roles = "Admin")]
        public async Task UpdateProjectDetails(ProjectViewModel project)
        {
            await repository.UpdateProjectDetailsAsync(project);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task Assign(AssignRequest assignRequest)
        {
            await repository.AssignCategoryAsync(assignRequest);
        }

    }
}