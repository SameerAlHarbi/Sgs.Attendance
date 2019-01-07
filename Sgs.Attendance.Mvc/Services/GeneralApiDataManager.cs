using Newtonsoft.Json;
using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sgs.Attendance.Mvc.Services
{
    public class GeneralApiDataManager<T> : IDataManager<T> where T:class,ISameerObject,new()
    {
        private readonly HttpClient _client;

        public GeneralApiDataManager(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<T>> GetAllDataList()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("departmentsinfo");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<List<T>>(content);
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
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<T> GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DataActionResult<T>> DeleteDataItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this._client.Dispose();
        }



        public Task<PagedDataResult<T>> GetPagedDataList(int pageNumber = 1, int pageSize = 100, string sort = "Id")
        {
            throw new NotImplementedException();
        }

        public Task<DataActionResult<T>> InsertNewDataItem(T newItem)
        {
            throw new NotImplementedException();
        }

        public Task<DataActionResult<T>> UpdateDataItem(T currentItem)
        {
            throw new NotImplementedException();
        }
    }
}
