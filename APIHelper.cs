﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.IO;
using Newtonsoft.Json;

namespace RestSharpInReqRes
{
    public class APIHelper
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://reqres.in/";
        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            var RestClient = new RestClient(url);
            return RestClient;
        }
        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }
        public RestRequest CreateGetRequest(string payload)
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }
        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }
        public DTOs GetContent<DTOs>(RestResponse response)
        {
            var contentOfUsers = response.Content;
            DTOs dTOs = JsonConvert.DeserializeObject<DTOs>(contentOfUsers);
            return dTOs;
        }

    }
}
