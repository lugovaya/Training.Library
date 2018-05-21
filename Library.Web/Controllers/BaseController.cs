using System;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    [NonController]
    public class BaseController : Controller
    {
        [NonAction]
        public IActionResult DataTable()
        {
            throw new NotImplementedException();
        }
    }
}