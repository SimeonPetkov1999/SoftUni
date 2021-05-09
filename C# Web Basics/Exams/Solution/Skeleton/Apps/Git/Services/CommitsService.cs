using Git.Data;
using Git.Data.Models;
using Git.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string description, string repoId, string creatorId)
        {
            this.db.Commit.Add(new Commit
            {
                CreatedOn = DateTime.UtcNow,
                Description = description,
                RepositoryId = repoId,
                CreatorId = creatorId
            });

            this.db.SaveChanges();
        }


        public IEnumerable<CommitViewModel> GetAllByUserId(string userId)
        {
            var commits = this.db
                .Users
                .Where(x => x.Id == userId)
                .Include(x => x.Commits)
                .ThenInclude(x=>x.Repository)
                .First()
                .Commits
                .Select(x => new CommitViewModel()
                 {
                    Id = x.Id,
                     CreatedOn = x.CreatedOn,
                     Description = x.Description,
                     RepoName = x.Repository.Name
                 })
                .ToList();

            return commits;
        }
        public void DeleteById(string commitId)
        {
            var commit = this.db.Commit
                .FirstOrDefault(x => x.Id == commitId);

            this.db.Commit.Remove(commit);
            this.db.SaveChanges();
        }


    }
}
