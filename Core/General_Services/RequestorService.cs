using Domain.DTOs.ApplicationUser;
using Domain.DTOs.Responses;
using Domain.Enums;
using Domain.Interfaces.General_Services;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.General_Services
{
    public class RequestorService : IRequestorService
    {
        public async Task<ApiResponse> Call(string client, string endpoint, MethodTypes method, object data, string userToken)
        {
            Method restsharMethod = GetMethod(method);
            //if(restsharMethod == 0)
            //{
            //    return new Response(false, "MethodNull", 402, null);
            //}

            string clientUrl = "https://localhost:7292/";
            //string clientUrl = "https://api-tacoshare.azurewebsites.net/";
            if (!string.IsNullOrEmpty(client))
            {
                clientUrl = client;
            }
            RestClient restClient = new(clientUrl);
            RestRequest restRequest = new(endpoint, restsharMethod)
            {
                RequestFormat = DataFormat.Json,
            };

            if (!string.IsNullOrEmpty(userToken))
            {
                restRequest.AddHeader("Authorization", $"bearer {userToken}");
            }
            restRequest.AddHeader("Content-Type", "application/json");

            if (data != null)
            {
                restRequest.AddJsonBody(data);
            }
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            ApiResponse output = JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content);
            return output;
        }

        private Method GetMethod(MethodTypes methodType)
        {
            switch (methodType)
            {
                case MethodTypes.GET:
                    return Method.Get;
                case MethodTypes.POST:
                    return Method.Post;
                case MethodTypes.PUT:
                    return Method.Put;
                case MethodTypes.DELETE:
                    return Method.Delete;
                default:
                    return 0;
            }
        }

    }
}
