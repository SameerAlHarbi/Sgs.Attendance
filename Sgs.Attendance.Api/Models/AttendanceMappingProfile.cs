using AutoMapper;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Models
{
    public class AttendanceMappingProfile : Profile
    {
        public AttendanceMappingProfile()
        {
            CreateMap<WorkShiftsSystem, WorkShiftsSystemModel>()
                .ForMember(s => s.Url, opt => opt.MapFrom<WorkShiftsSystemUrlResolver>())
                .ReverseMap();
        }
    }
}
