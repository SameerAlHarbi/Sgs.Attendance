using AutoMapper;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Models
{
    public class AttendanceMappingProfile : Profile
    {
        public AttendanceMappingProfile()
        {
            CreateMap<AttendanceSystem, AttendanceSystemModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<AttendanceSystemUrlResolver>())
                .ReverseMap();
        }
    }
}
