using Sgs.Attendance.Mvc.Models;
using Sgs.Attendance.Mvc.Services;
using System;
using System.ComponentModel.DataAnnotations;
using Sameer.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Sgs.Attendance.Mvc.ViewModels
{
    public class WorkShiftsSystemViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "رمز نظام الورديات مطلوب !")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "رمز نظام الورديات من {1} خانات فقط !")]
        [Remote(action: "VerifyCode", controller: "WorkShiftsSystems", AdditionalFields = nameof(Id))]
        [Display(Name ="الرمز")]
        public string Code { get; set; }

        [Required(ErrorMessage = "اسم نظام الورديات مطلوب !")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "اسم نظام الورديات يجب ان يكون بين {2} الى {1} ")]
        [Remote(action: "VerifyName", controller: "WorkShiftsSystems", AdditionalFields = nameof(Id))]
        [Display(Name = "الاسم")]
        public string Name { get; set; }

        [Display(Name = "تاريخ البداية")]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاريخ البداية هجري")]
        public string StartDateHijriText => StartDate.ConvertToString(true, true, true) + "هـ ";

        [Display(Name = "إثبات الحضور")]
        public AttendanceProof AttendanceProof { get; set; }

        [Display(Name = "إثبات الحضور")]
        public string AttendanceProofText => AttendanceProof.GetName();

        public bool IsDefaultWorkShiftsSystem { get; set; }

        [Display(Name = "ملاحظات")]
        public string Note { get; set; }
    }
}
