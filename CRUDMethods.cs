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
        public ListOfUsersDTO GetUsers()
        {
            //REQUEST
            var restClient = new RestClient("https://reqres.in/"); //creating var with RestClient method to pass base URL
            var restRequest = new RestRequest("/api/users?page=2", Method.GET); //passing end point & method of CRUD
            restRequest.AddHeader("Accept", "application/json"); //passing HEADERS
            restRequest.RequestFormat = DataFormat.Json; //FORMAT

            //RESPONSE
            var response = restClient.Execute(restRequest);   //Handling response with interface by executing request
            var content = response.Content; //getting content

            //Deserialization  (Convert JSON -> .NET)
            var users = JsonConvert.DeserializeObject<ListOfUsersDTO>(content);
            return users;

        }
    }
}