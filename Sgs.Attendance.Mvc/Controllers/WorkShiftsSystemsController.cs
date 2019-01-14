using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sgs.Attendance.Mvc.Models;
using Sgs.Attendance.Mvc.ViewModels;

namespace Sgs.Attendance.Mvc.Controllers
{
    public class WorkShiftsSystemsController : GeneralMvcController<WorkShiftsSystemModel, WorkShiftsSystemViewModel>
    {
        public WorkShiftsSystemsController(IDataManager<WorkShiftsSystemModel> dataManager, IMapper mapper, ILogger<WorkShiftsSystemsController> logger) 
            : base(dataManager, mapper, logger)
        {
        }

        protected override Task<WorkShiftsSystemViewModel> createObject()
        {
            return  Task.FromResult(new WorkShiftsSystemViewModel { StartDate=DateTime.Today.AddDays(-1) });
        }

        protected override string createNewTitleMessage => "إضافة نظام ورديات جديد";
    }
}
