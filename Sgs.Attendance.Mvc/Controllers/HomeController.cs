using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Attendance.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
