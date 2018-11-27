using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Attendance.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMapper mapper, ILogger<HomeController> logger) 
            : base(mapper, logger)
        {
        }

        public IActionResult Index()
        {
            ViewData["StatusMessage"] = this.StatusMessage;
            return View();
        }
    }
}
