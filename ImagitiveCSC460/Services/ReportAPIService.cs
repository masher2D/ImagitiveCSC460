using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveUI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace ImagitiveCSC460UI.Services
{
    public class ReportAPIService
    {
        public async Task<List<ReportModel>?> GetAllReportsAsync()
        {
            var response = await ApiClient.Client.GetAsync("api/reports");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<List<ReportModel>>();
        }

        public async Task<ReportModel?> GetReportByIdAsync(int id)
        {

            var response = await ApiClient.Client.GetAsync($"api/reports/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ReportModel>();

        }

        public async Task<ReportModel?> CreateReportAsync(PostReportRequest request)
        {
            var response = await ApiClient.Client.PostAsJsonAsync("api/reports", request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReportModel>();

        }

        public async Task<bool> UpdateReportStatusAsync(int id, UpdateReportStatusRequest request)
        {
            var response = await ApiClient.Client.PatchAsJsonAsync($"api/reports/{id}/status", request);

            return response.IsSuccessStatusCode;
        }
    }
}
