using AutoMapper;
using Sameer.Shared;
using Sgs.Attendance.ERP;
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

    public class DeviceInfoMappingProfile : AttendanceMappingProfile<DeviceInfo, DeviceInfoModel>
    { }

    public class DepartmentsInfoMappingProfile : AttendanceMappingProfile<DepartmentInfo, DepartmentInfoModel>
    { }

    public class ErpDepartmentsInfoMappingProfile : AttendanceMappingProfile<ErpDepartmentInfo, DepartmentInfoModel>
    { }

    public class EmployeeInfoMappingProfile : AttendanceMappingProfile<EmployeeInfo, EmployeeInfoModel>
    { }

    public class WorkShiftsSystemMappingProfile : AttendanceMappingProfile<WorkShiftsSystem,WorkShiftsSystemModel>
    {}

    public class WorkShiftsCalendarMappingProfile : AttendanceMappingProfile<WorkShiftsCalendar, WorkShiftsCalendarModel>
    { }

    public class EmployeeWorkShiftsSystemMappingProfile : AttendanceMappingProfile<EmployeeWorkShiftsSystem, EmployeeWorkShiftsSystemModel>
    { }
}
