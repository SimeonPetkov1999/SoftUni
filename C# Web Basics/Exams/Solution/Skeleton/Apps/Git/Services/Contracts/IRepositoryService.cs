using Git.Data.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoryService
    {
        public void Create(string name, bool isPublic, string ownerId);

        public IEnumerable<AllRepositoriesViewModel> GetAll();

        public Repository GetById(string id);
    }
}
