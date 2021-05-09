using Git.Data;
using Git.Data.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext db;

        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, bool isPublic, string ownerId)
        {
            var repo = new Repository
            {
                CreatedOn = DateTime.UtcNow,
                IsPublic = isPublic,
                OwnerId = ownerId,
                Name = name
            };

            this.db.Repositories.Add(repo);
            db.SaveChanges();
        }

        public IEnumerable<AllRepositoriesViewModel> GetAll()
        {
            return this.db.Repositories
                .Where(x=>x.IsPublic)
                .Select(x => new AllRepositoriesViewModel()
                {
                    Id = x.Id,
                    Commits = x.Commits,
                    CreatedOn = x.CreatedOn,
                    Name = x.Name,
                    Owner = x.Owner.Username
                })
                .ToList();
        }

        public Repository GetById(string id)
        {
            return this.db.Repositories.FirstOrDefault(x => x.Id == id);
        }
    }
}
