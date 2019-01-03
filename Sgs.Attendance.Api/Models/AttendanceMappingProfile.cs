using AutoMapper;
using Sameer.Shared;
using Sgs.Attendance.Model;

namespace Sgs.Attendance.Api.Models
{
    public abstract class AttendanceMappingProfile<M,VM> : Profile where M : class, ISameerObject, new() where VM : class,ISameerApiViewModel, new()
    {
        public AttendanceMappingProfile()
        {
            CreateMap<M, VM>()
                .ForMember(s => s.Url, opt => opt.MapFrom<ModelUrlResolver<M,VM>>())
                .ReverseMap();
        }
    }

    public class WorkShiftsMappingProfile : AttendanceMappingProfile<WorkShiftsSystem,WorkShiftsSystemModel>
    {}

    public class DepartmentsInfoMappingProfile : AttendanceMappingProfile<DepartmentInfo, DepartmentInfoModel>
    { }

    public class EmployeeInfoMappingProfile : AttendanceMappingProfile<EmployeeInfo, EmployeeInfoModel>
    { }

    public class EmployeeWorkShiftsSystemMappingProfile : AttendanceMappingProfile<EmployeeWorkShiftsSystem, EmployeeWorkShiftsSystemModel>
    { }
}
