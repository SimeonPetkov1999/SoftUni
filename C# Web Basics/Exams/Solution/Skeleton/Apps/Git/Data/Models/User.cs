using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    //•	Has an Id – a string, Primary Key
    //•	Has a Username – a string with min length 5 and max length 20 (required)
    //•	Has an Email - a string (required)
    //•	Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
    //•	Has Repositories collection – a Repository type
    //•	Has Commits collection – a Commit type
    public class User
    {

        public User()
        {
            this.Commits = new HashSet<Commit>();                
            this.Repositories = new HashSet<Repository>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Repository> Repositories { get; set; }

        public ICollection<Commit> Commits { get; set; }
    }
}
