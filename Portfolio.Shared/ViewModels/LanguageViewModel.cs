using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class LanguageViewModel
    {
        public LanguageViewModel() { }
        public LanguageViewModel(Language l)
        {
            Id = l.Id;
            Name = l.Name;
            Slug = l.Slug;

            Projects = l.ProjectLanguages
                        .Select(pl => new BasicProject(pl.Project))
                        .ToList();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public IList<BasicProject> Projects { get; set; }
    }
}
