using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
using ImagitiveUI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace ImagitiveCSC460UI.Services
{
    public class AdminRequestAPIService
    {
        public Task<AdminRequestModel> CreateRequestAsync(int reporterId, PostAdminPromoteRequest request)
        {
            var response = ApiClient.Client.PostAsJsonAsync($"api/adminrequests/{reporterId}", request).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to create admin request: {response.ReasonPhrase}");
            }
            return response.Content.ReadFromJsonAsync<AdminRequestModel>();
        }

        public async Task<List<AdminRequestModel>?> GetAllRequestsAsync()
        {
            var response = await ApiClient.Client.GetAsync("api/adminrequests");
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<List<AdminRequestModel>>();
        }

        public async Task<AdminRequestModel?> GetRequestByIdAsync(int requestId)
        {
            var response = await ApiClient.Client.GetAsync($"api/adminrequests/{requestId}");
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<AdminRequestModel>();
        }

        public async Task<bool> UpdateRequestStatusAsync(int requestId, string status)
        {
            var response = await ApiClient.Client.PatchAsJsonAsync($"api/adminrequests/{requestId}/status", status);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<AdminRequestModel>?> GetRequestsByStatusAsync(string status)
        {
            var response = await ApiClient.Client.GetAsync($"api/adminrequests/status/{status}");
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<List<AdminRequestModel>>();
        }

        public async Task<List<AdminRequestModel>?> GetRequestsByRequesterIdAsync(int requesterId)
        {
            var response = await ApiClient.Client.GetAsync($"api/adminrequests/requester/{requesterId}");
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<List<AdminRequestModel>>();
        }

        public async Task<PagedResponse<AdminRequestModel>?> GetAllRequestsAsync(int pageNumber, int pageSize, string filter, string sort)
        {
            var response = await ApiClient.Client.GetAsync($"api/adminrequests/paged?pageNumber={pageNumber}&pageSize={pageSize}&filter={filter}&sort={sort}");
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<PagedResponse<AdminRequestModel>>();
        }
    }
}
