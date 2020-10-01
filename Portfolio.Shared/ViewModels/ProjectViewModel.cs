﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Portfolio.Shared.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Languages = new List<LanguageViewModel>();
        }

        public ProjectViewModel(Project p)
        {
            Id = p.Id;
            Title = p.Title;
            Requirements = p.Requirements;
            Design = p.Design;
            Languages = new List<LanguageViewModel>(p.ProjectLanguages.Select(pl => new LanguageViewModel(pl.Language)));
            Platforms = new List<PlatformViewModel>(p.ProjectPlatforms.Select(pl => new PlatformViewModel(pl.Platform)));
            Technologies = new List<TechnologyViewModel>(p.ProjectTechnologies.Select(pl => new TechnologyViewModel(pl.Technology)));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }
        public IEnumerable<LanguageViewModel> Languages { get; set; }
        public IEnumerable<PlatformViewModel> Platforms { get; set; }
        public IEnumerable<TechnologyViewModel> Technologies { get; set; }
    }
}
