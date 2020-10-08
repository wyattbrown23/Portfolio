﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class PlatformViewModel
    {
        public PlatformViewModel() { }
        public PlatformViewModel(Platform platform)
        {
            Id = platform.Id;
            Name = platform.Name;
            Slug = platform.Slug;
            Projects = platform.ProjectPlatforms
                       .Select(pl => new BasicProject(pl.Project))
                       .ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<BasicProject> Projects { get; set; }
    }
}

