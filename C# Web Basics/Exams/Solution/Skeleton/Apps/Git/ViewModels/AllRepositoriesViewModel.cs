using Git.Data.Models;
using System;
using System.Collections.Generic;

namespace Git.ViewModels
{
    public class AllRepositoriesViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Owner { get; set; }
        public ICollection<Commit> Commits { get; set; }

    }
}
