﻿using Portfolio.Api.Data;
using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Portfolio.API.Data
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        public EfCoreRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Project> Projects => context.Projects;

        public async Task AddCategoryAsync(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task AssignCategoryAsync(ProjectCategory projectCategory)
        {
            context.ProjectCategories.Add(projectCategory);
            await context.SaveChangesAsync();
        }

        public async Task SaveProjectAsync(Project project)
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }
        public async Task DeleteProjectAsync(int id)
        {
            var project = await context.Projects.FindAsync(id);
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }
        public async Task UpdateProjectDetailsAsync(Project project)
        {
            context.Projects.Update(project);
            await context.SaveChangesAsync();
        }
    }
}