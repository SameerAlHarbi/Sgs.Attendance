using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sgs.Attendance.Api.Controllers
{

    public class ErrorsController : BaseController
    {
        public ErrorsController(IMapper mapper, ILogger<ErrorsController> logger) 
            : base(mapper, logger)
        {
        }

        [Route("500")]
        public ActionResult Error500()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            this._logger.LogError($"Error at {exceptionFeature?.Path ?? "No path data"} - error message : {exceptionFeature?.Error?.Message ?? "No error data"}.");
            return BadRequest("Error-500");
        }

        [Route("{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ViewBag.StatusCode = statusCode;
            if (statusCode == 404)
            {
                this._logger.LogWarning($"Request to {statusCodeData.OriginalPath}{statusCodeData.OriginalQueryString} - {statusCodeData.OriginalPathBase} not found");
                return BadRequest("NotFound-404");
            }
            else
            {
                this._logger.LogError($"Something went wrong on the server status code : {statusCode} .  path : {statusCodeData.OriginalPath}{statusCodeData.OriginalQueryString} - {statusCodeData.OriginalPathBase} ");
                return BadRequest($"Error-{statusCode}");
            }
        }
    }
}
