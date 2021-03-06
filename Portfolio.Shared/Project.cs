﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Shared
{
    public class Project
    {
        public const string LanguageCategory = "language";
        public const string PlatformCategory = "platform";
        public const string TechnologyCategory = "technology";

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("requirements")]
        public string Requirements { get; set; }
        [JsonPropertyName("design")]
        public string Design { get; set; }
        [JsonPropertyName("completionDate")]
        public DateTime CompletionDate { get; set; }
        [JsonPropertyName("languages")]
        public List<ProjectLanguage> ProjectLanguages { get; set; }
        [JsonPropertyName("platforms")]
        public List<ProjectPlatform> ProjectPlatforms { get; set; }
        [JsonPropertyName("technologies")]
        public List<ProjectTechnology> ProjectTechnologies { get; set; }
        public string Slug { get; set; }
    }
}
