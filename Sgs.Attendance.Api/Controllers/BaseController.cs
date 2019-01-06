using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Sgs.Attendance.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public const string URLHELPER = "URLHELPER";
        public const string NOTFOUND_MESSAGE = "Not Found";

        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        public BaseController(
            IMapper mapper,
            ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            context.HttpContext.Items[URLHELPER] = this.Url;
        }
    }
}
