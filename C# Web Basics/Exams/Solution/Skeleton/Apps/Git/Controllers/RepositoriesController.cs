using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var repos = this.repositoryService.GetAll();
            return this.View(repos);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(repositoryType))
            {
                return this.Error("Name and type are required");
            }

            if (repositoryType != "Public" || repositoryType!="Private")
            {
                return this.Error("Invalid Type");
            }

            if (name.Length < 3 || name.Length > 10)
            {
                return this.Error("Repo name should be between 3 and 10 characters long");
            }

            bool isPublic = repositoryType == "Private" ? false : true;
            this.repositoryService.Create(name, isPublic, this.GetUserId());
            return this.Redirect("/Repositories/All");
        }

    }
}
