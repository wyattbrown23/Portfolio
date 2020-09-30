﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Portfolio.Shared
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProjectCategory> ProjectCategories { get; set; }
    }
}
