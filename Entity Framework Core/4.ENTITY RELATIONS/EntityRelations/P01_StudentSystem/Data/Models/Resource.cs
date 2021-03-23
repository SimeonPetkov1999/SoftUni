using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
//o ResourceId
//o Name(up to 50 characters, unicode)
//o Url(not unicode)
//o ResourceType(enum – can be Video, Presentation, Document or Other)
//o CourseId

    public class Resource
    {
        
        public int ResourceId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public ResourceType ResourceType  { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }

    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
}
