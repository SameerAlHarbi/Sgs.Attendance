using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgs.Attendance.Api.Controllers;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Models
{
    public class WorkShiftsSystemUrlResolver : IValueResolver<WorkShiftsSystem, WorkShiftsSystemModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkShiftsSystemUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(WorkShiftsSystem source, WorkShiftsSystemModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            string result = url.Link("WorkShiftsSystemGetByCode", new { code = source.Code });

            return result;
        }
    }
}
