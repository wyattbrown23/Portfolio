using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class BasicProject
    {
        public BasicProject() { }

        public BasicProject(Project p)
        {
            Id = p.Id;
            Title = p.Title;
            Requirements = p.Requirements;
            CompletionDate = p.CompletionDate;
            Design = p.Design;
            Slug = p.Slug;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Slug { get; set; }
    }
}

