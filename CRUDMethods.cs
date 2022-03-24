using Newtonsoft.Json;
using RestSharp;
using RestSharpInReqRes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestSharpInReqRes
{
    public class CRUDMethods
    {
        public GetListOfUsersDTO GetUsers(string endpoint)
        {
            ////REQUEST
            //var restClient = new RestClient("https://reqres.in/"); //creating var with RestClient method to pass base URL
            //var restRequest = new RestRequest("/api/users?page=2", Method.GET); //passing end point & method of CRUD
            //restRequest.AddHeader("Accept", "application/json"); //passing HEADERS
            //restRequest.RequestFormat = DataFormat.Json; //FORMAT

            ////RESPONSE
            //var response = restClient.Execute(restRequest);   //Handling response with interface by executing request
            ////getting content
            //var content = response.Content;

            ////Deserialization  (Convert JSON -> .NET)
            //var users = JsonConvert.DeserializeObject<GetListOfUsersDTO>(content);
            //return users;
            var user = new APIHelper<GetListOfUsersDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, (RestRequest)request);
            GetListOfUsersDTO content = user.GetContent<GetListOfUsersDTO>(response);
            return content;

        }
        public CreateListOfUsersDTO CreateUsers(string endpoint, dynamic payload)
        {
            var user = new APIHelper<CreateListOfUsersDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);
            CreateListOfUsersDTO content = user.GetContent<CreateListOfUsersDTO>(response);
            return content;
        }

    }
}