using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sameer.Shared;
using Sgs.Attendance.Api.Controllers;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Models
{
    public class ModelUrlResolver<M,VM> : IValueResolver<M, VM, string> where M : class, ISameerObject, new() where VM : class,ISameerApiViewModel, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ModelUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(M source, VM destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[GeneralApiController<M,VM>.URLHELPER];
            var controllerName = _httpContextAccessor.HttpContext.Items[GeneralApiController<M,VM>.CONTROLLER_NAME];
            string result = url.Link($"{controllerName}_GetByIdAsync", new { id = source.Id });
            return result;
        }
    }
}
