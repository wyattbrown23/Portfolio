using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class BasicPlatform
    {
        public BasicPlatform() { }
        public BasicPlatform(Platform platform)
        {
            Id = platform.Id;
            Name = platform.Name;
            Slug = platform.Slug;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}