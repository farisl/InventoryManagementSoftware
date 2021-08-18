using eProdaja.Model;
using Flurl.Http;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Security;
using InventoryManagementSoftware.Services;
using InventoryManagementSoftware.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSoftware.WinUI
{
    public class APIService
    {
        private string _resource;
        public string endpoint = $"{Resources.ApiUrl}";

        public static string Token { get; set; }

        public APIService(string resource)
        {
            _resource = resource;
        }

        public async Task<T> Get<T>(object searchRequest = null)
        {
            var query = "";

            if (searchRequest != null)
                query = await searchRequest.ToQueryString();

            return await $"{endpoint}{_resource}?{query}".WithHeader("Authorization", Token).GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(int id)
        {
            var url = $"{endpoint}{_resource}/{id}";

            return await url.WithHeader("Authorization", Token).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{endpoint}{_resource}" + "?" + await request.ToQueryString();

            return await url.WithHeader("Authorization", Token).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(int id, object request)
        {
            var url = $"{endpoint}{_resource}/{id}";

            return await url.WithHeader("Authorization", Token).PutJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Delete<T>(int id)
        {
            var url = $"{endpoint}{_resource}/{id}";

            return await url.WithHeader("Authorization", Token).DeleteAsync().ReceiveJson<T>(); 
        }

        private async Task<AuthResult> Authenticate()
        {
            UserLoginRequest request = new UserLoginRequest
            {
                Email = "eminl@ims.ba",
                Password = "test"
            };
            APIService authService = new APIService("AuthManagement/Login");

            var authResult = await authService.Insert<AuthResult>(request);
            Token = $"Bearer {authResult.Token}";
            return authResult;
        }

    }
}
