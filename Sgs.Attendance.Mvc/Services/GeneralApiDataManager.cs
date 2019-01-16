using Newtonsoft.Json;
using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sgs.Attendance.Mvc.Services
{
    public class GeneralApiDataManager<T> : IDataManager<T> where T : class, ISameerObject, new()
    {
        protected readonly HttpClient _client;

        public GeneralApiDataManager(HttpClient client)
        {
            _client = client;
        }

        protected virtual async Task<(string errorMessage, bool notFoundData, bool modelStateError, string MemberName ,string MemberError)> getErrorResponseMessage(HttpResponseMessage response)
        {
            string httpErrorObject = await response.Content.ReadAsStringAsync();
            // Deserialize:
            var deserializedErrorObject = JsonConvert
                .DeserializeAnonymousType(httpErrorObject, new { message = "", ModelState = new { Member="" ,MemberError=""} });

            bool notFoundData = false;

            if (deserializedErrorObject.message != null)
            {
               notFoundData = deserializedErrorObject.message.Trim().ToLower()  == "Not Found".Trim().ToLower();
            }

            bool modelStateError = deserializedErrorObject.ModelState != null;

            return (deserializedErrorObject.message??"",notFoundData,modelStateError,deserializedErrorObject.ModelState.Member,deserializedErrorObject.ModelState.MemberError);
        }

        public virtual async Task<List<T>> GetAllDataList(string fieldName, string fieldValue)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"GetBy?fieldName={fieldName}&fieldValue={fieldValue}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<List<T>>(content);
                    return results;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Path not found !!");
                }
                else
                {
                    var errorData = await getErrorResponseMessage(response);
                    if(errorData.notFoundData)
                    {
                        return null;
                    }
                    throw new Exception($"Internal Server Error : {errorData.errorMessage}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<List<T>> GetAllDataList()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<List<T>>(content);
                    return results;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Path not found !!");
                }
                else
                {
                    var errorData = await getErrorResponseMessage(response);
                    if (errorData.notFoundData)
                    {
                        return null;
                    }
                    throw new Exception($"Internal Server Error : {errorData.errorMessage}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<T> GetDataById(int id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<T>(content);
                    return results;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Path not found !!");
                }
                else
                {
                    var errorData = await getErrorResponseMessage(response);
                    if (errorData.notFoundData)
                    {
                        return null;
                    }
                    throw new Exception($"Internal Server Error : {errorData.errorMessage}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<DataActionResult<T>> InsertNewDataItem(T newItem)
        {
            try
            {
                string serializeItemToCreate = JsonConvert.SerializeObject(newItem);

                HttpResponseMessage response = await _client.PostAsync(requestUri: ""
                        , content: new StringContent(serializeItemToCreate, Encoding.Unicode, mediaType: "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    newItem = JsonConvert.DeserializeObject<T>(content);
                    return new DataActionResult<T>(newItem, RepositoryActionStatus.Created);
                }
                else if(response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("path not found");
                }
                else
                {
                    var errorData = await getErrorResponseMessage(response);
                    if (errorData.notFoundData)
                    {
                        return new DataActionResult<T>(newItem, RepositoryActionStatus.NotFound);
                    }
                    else if(errorData.modelStateError)
                    {
                        throw new ValidationException(new ValidationResult(errorData.MemberError,new string[] { errorData.MemberName }),null,null);
                    }
                    throw new Exception($"Internal Server Error");
                }
            }
            catch(ValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual Task<DataActionResult<T>> DeleteDataItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            this._client.Dispose();
        }

        public virtual Task<PagedDataResult<T>> GetPagedDataList(int pageNumber = 1, int pageSize = 100, string sort = "Id")
        {
            throw new NotImplementedException();
        }

        public virtual Task<DataActionResult<T>> UpdateDataItem(T currentItem)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<DataActionResult<T>>> InsertNewDataItems(IEnumerable<T> newItems)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<DataActionResult<T>>> UpdateDataItems(IEnumerable<T> currentItems)
        {
            throw new NotImplementedException();
        }
    }
}
