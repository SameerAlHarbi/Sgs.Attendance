using Newtonsoft.Json;
using Sameer.Shared;
using Sgs.Attendance.Mvc.Models;
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

        protected virtual async Task<(string errorMessage, bool notFoundData, bool modelStateError, List<ApiModelError> modelErrors)> getErrorResponseMessage(HttpResponseMessage response)
        {
            string httpErrorObject = await response.Content.ReadAsStringAsync();
            var deserializedErrorObject = JsonConvert
                .DeserializeAnonymousType(httpErrorObject, new { ErrorMessage = "", Errors = new List<ApiModelError>() });

            bool notFoundData = false;

            if (deserializedErrorObject.ErrorMessage != null)
            {
               notFoundData = deserializedErrorObject.ErrorMessage.Trim().ToLower()  == "Not Found".Trim().ToLower();
            }

            bool modelStateError = deserializedErrorObject.Errors != null;

            return (deserializedErrorObject.ErrorMessage ?? "",notFoundData,modelStateError,deserializedErrorObject.Errors);
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
                        throw new ValidationException(new ValidationResult(errorData.modelErrors.First().Errors.First(),new string[] { errorData.modelErrors.First().Key }),validatingAttribute:null,value:newItem);
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

        public virtual async Task<DataActionResult<T>> UpdateDataItem(T currentItem)
        {
            try
            {
                if(currentItem == null)
                {
                    throw new ArgumentNullException(nameof(currentItem),$"Current item to update can't be null !");
                }

                HttpResponseMessage response = await _client.PutAsJsonAsync<T>(currentItem.Id.ToString(), currentItem);

                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    currentItem = JsonConvert.DeserializeObject<T>(content);
                    return new DataActionResult<T>(currentItem, RepositoryActionStatus.Updated);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("path not found");
                }
                else
                {
                    var errorData = await getErrorResponseMessage(response);
                    if (errorData.notFoundData)
                    {
                        return new DataActionResult<T>(currentItem, RepositoryActionStatus.NotFound);
                    }
                    else if (errorData.modelStateError)
                    {
                        throw new ValidationException(new ValidationResult(errorData.modelErrors.First().Errors.First(), new string[] { errorData.modelErrors.First().Key }), validatingAttribute: null, value: currentItem );
                    }
                    throw new Exception($"Internal Server Error");
                }

            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<DataActionResult<T>> DeleteDataItem(int itemId)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(itemId.ToString());

                if (response.IsSuccessStatusCode)
                {
                    return new DataActionResult<T>(null,RepositoryActionStatus.Deleted);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("path not found");
                }
                else
                {
                    var errorData = await getErrorResponseMessage(response);
                    if (errorData.notFoundData)
                    {
                        return new DataActionResult<T>(null, RepositoryActionStatus.NotFound);
                    }
                    else if (errorData.modelStateError)
                    {
                        throw new ValidationException(new ValidationResult(errorData.modelErrors.First().Errors.First(), new string[] { errorData.modelErrors.First().Key }), validatingAttribute: null, value: null);
                    }
                    throw new Exception($"Internal Server Error");
                }


            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void Dispose()
        {
            this._client.Dispose();
        }

        public virtual Task<PagedDataResult<T>> GetPagedDataList(int pageNumber = 1, int pageSize = 100, string sort = "Id")
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
