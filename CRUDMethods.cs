using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpInReqRes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace RestSharpInReqRes
{
    public class CRUDMethods<T>
    {
        public GetListUsersDTO GetListUsers(string endpoint)
        {
            var user = new APIHelper<GetListUsersDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            GetListUsersDTO content = user.GetContent<GetListUsersDTO>(response);
            return content;

        }

        public GetListResourceDTO GetListResourceUsers(string endpoint)
        {
            var user = new APIHelper<GetListResourceDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
           
            GetListResourceDTO content = user.GetContent<GetListResourceDTO>(response);
            return content;

        }
        public CreateUserDTO CreateUsers(string endpoint, dynamic payload)
        {
            var user = new APIHelper<CreateUserDTO>();
            var url = user.SetUrl(endpoint);
            var requestJson=HandleContent.Serialize(payload);//serialize into json
            var request = user.CreatePostRequest(requestJson);
            var response = user.GetResponse(url, request);
            HttpStatusCode statusCode = response.StatusCode;
            int numCode = (int)statusCode;
            Assert.AreEqual(201, numCode);
            CreateUserDTO content = user.GetContent<CreateUserDTO>(response);
            return content;
        }
        public UpdateListDTO UpdateUsers(string endpoint, string payload)
        {
            var user = new APIHelper<UpdateListDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreatePutRequest(payload);
            var response = user.GetResponse(url, request);
            UpdateListDTO content = user.GetContent<UpdateListDTO>(response);
            return content;
        }
        public GetListUsersDTO DemoGetListUsers()
        {
            //REQUEST
            var restClient = new RestClient("https://reqres.in/"); //creating var with RestClient method to pass base URL
            var restRequest = new RestRequest("/api/users?page=2", Method.GET); //passing end point & method of CRUD
            restRequest.AddHeader("Accept", "application/json"); //passing HEADERS
            restRequest.RequestFormat = DataFormat.Json; //FORMAT

            //RESPONSE
            IRestResponse response = restClient.Execute(restRequest);   //Handling response with interface by executing request
            //getting content
            var content = response.Content;

            //Deserialization  (Convert JSON -> .NET)
            var users = JsonConvert.DeserializeObject<GetListUsersDTO>(content);
            return users;
        }

    }
}