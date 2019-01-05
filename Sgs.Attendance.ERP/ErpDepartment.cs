using Sameer.Shared;

namespace Sgs.Attendance.ERP
{
    public class ErpDepartmentInfo : ISameerObject
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string ParentCode { get; set; }

        public string ParentName { get; set; }

        public ErpDepartmentInfo ParentErpDepartmentInfo { get; set; }
    
        public int? ManagerId { get; set; }

        public string ManagerName { get; set; }

        public string ManagerPosition { get; set; }
    }
}
