using Newtonsoft.Json;
using Sgs.Attendance.ERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sgs.Attendance.Api.Services
{
    public class ErpManager : IErpManager
    {
        private readonly HttpClient _client;

        public ErpManager(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ErpDepartmentInfo>> GetAllErpDepartmentsInfo()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("departments");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<List<ErpDepartmentInfo>>(content);
                    return results;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Data not found !!");
                }
                else //Else in case of BadRequest for not found data or InternalServerError
                {
                    throw new Exception("Internal Server Error");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ErpDepartmentInfo>> GetAllErpDepartmentsInfoByParentCode(string parentErpDepartmentByCode, bool directOnly = false)
        {
            return new List<ErpDepartmentInfo>();
        }

        public async Task<ErpDepartmentInfo> GetErpDepartmentByCode(string erpDepartmentByCode)
        {
            return await Task.FromResult(new ErpDepartmentInfo());
        }
    }
}
