using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        protected string UserName => HttpContext.Items["CurrentUserName"]?.ToString() ??
                                     (string) (HttpContext.Items["CurrentUserName"] = User.Identity.Name);

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}