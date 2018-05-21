using System;
using System.Collections.Generic;
using System.Linq;
using Library.Domain.Models;
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
            var users = new List<User>
            {
                new User {Email = "first@email.com"},
                new User {Email = "second@email.com"},
            };

            return View(users);
        }

        public IActionResult GetEmails(string[] names) // /Users/GetData?names=packager1&names=packager2&names=packager3
        {
            var usersEmails = names.Select(x => _usersRepository.Get(x)?.Email ?? string.Empty);

            return PartialView(usersEmails);
        }

        [HttpPost]
        public IActionResult SendEmails(IEnumerable<string> names) // from Request.Form
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Check(IEnumerable<User> items)
        {
            throw new NotImplementedException();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsUnique(string email, string name)
        {
            throw new NotImplementedException();
        }
    }
}