﻿using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Portfolio.API.Data
{
    public interface IRepository
    {
        IQueryable<Project> Projects { get; }
        Task SaveProjectAsync(Project project);
        Task AssignCategoryAsync(AssignRequest assignRequest);
        Task DeleteProjectAsync(int id);
        Task UpdateProjectDetailsAsync(Project project);
    }
}
