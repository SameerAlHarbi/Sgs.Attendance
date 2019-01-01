using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sgs.Attendance.Api.Controllers;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Models
{
    public class AttendanceSystemUrlResolver : IValueResolver<WorkShiftsSystem, AttendanceSystemModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AttendanceSystemUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(WorkShiftsSystem source, AttendanceSystemModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            string result = url.Link("AttendanceSystemGetByCode", new { code = source.Code });

            return result;
        }
    }
}
