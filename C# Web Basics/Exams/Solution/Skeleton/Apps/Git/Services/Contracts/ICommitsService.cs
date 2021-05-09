using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        public void Create(string description, string repoId, string ownerId);

        public IEnumerable<CommitViewModel> GetAllByUserId(string userId);

        public void DeleteById(string commitId);
    }
}
