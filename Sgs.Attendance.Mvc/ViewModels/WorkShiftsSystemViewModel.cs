using Sgs.Attendance.Mvc.Models;
using Sgs.Attendance.Mvc.Services;
using System;
using System.ComponentModel.DataAnnotations;
using Sameer.Shared;

namespace Sgs.Attendance.Mvc.ViewModels
{
    public class WorkShiftsSystemViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "{0} must be of {1} characters !")]
        [Display(Name ="الرمز")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} must be between {2} And {1} characters long !")]
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

        [Display(Name = "ملاحظات")]
        public string Note { get; set; }
    }
}
