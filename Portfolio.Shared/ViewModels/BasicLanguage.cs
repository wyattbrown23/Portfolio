﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class BasicLanguage
    {
        public BasicLanguage() { }
        public BasicLanguage(Language l)
        {
            Id = l.Id;
            Name = l.Name;
            Slug = l.Slug;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

    }
}
