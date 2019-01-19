using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Attendance.Mvc.Models
{
    public class ApiModelError
    {
        public string Key { get; set; }

        public List<string> Errors { get; set; }

    }
}
