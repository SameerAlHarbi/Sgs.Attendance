using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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



        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerifyCode(string code, int? id = null)
        {
            try
            {
                var currentWorkShiftsSystem = await ((WorkShiftsSystemsManager)_dataManager).GetSingleItemAsync(s => s.Code.Trim().Normalize() == code.Trim().Normalize());
                if (currentWorkShiftsSystem != null && currentWorkShiftsSystem.Id != id)
                {
                    return Json($"عفواً رمز نظام الورديات مسجل مسبقاً !");
                }
                return Json(true);
            }
            catch (Exception)
            {
                return Json("خطأ أثناء التحقق ...!!");
            }
        }
    }
}
