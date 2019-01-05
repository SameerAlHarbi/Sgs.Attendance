using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sgs.Attendance.ERP
{
    public interface IErpManager
    {

        Task<IEnumerable<ErpDepartmentInfo>> GetAllErpDepartmentsInfo();

        Task<IEnumerable<ErpDepartmentInfo>> GetAllErpDepartmentsInfoByParentCode(string parentErpDepartmentByCode, bool directOnly = false);

        Task<ErpDepartmentInfo> GetErpDepartmentByCode(string erpDepartmentByCode);

    }
}
