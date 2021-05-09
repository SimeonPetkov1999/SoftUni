using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(ICommitsService commitsService,IRepositoryService repository)
        {
            this.commitsService = commitsService;
            this.repositoryService = repository;
        }

        [HttpGet]
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var repo = this.repositoryService.GetById(id);
            var model = new CommitInputViewModel() { Id = id, Name = repo.Name };
            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string id,string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (description.Length<5)
            {
                return this.Error("Description length must be atleast 5 characters long");
            }

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(description))
            {
                return this.Error("Invalid description");
            }

            this.commitsService.Create(description, id, this.GetUserId());        
            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All() 
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var commits = this.commitsService.GetAllByUserId(this.GetUserId());
            return this.View(commits);
        }

        public HttpResponse Delete(string id) 
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }


            this.commitsService.DeleteById(id);
            return this.Redirect("All");
        }
    }
}
