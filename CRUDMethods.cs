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
    public class CRUDMethods<T>
    {
        public GetListOfUsersDTO GetUsers(string endpoint)
        {
            var user = new APIHelper<GetListOfUsersDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            GetListOfUsersDTO content = user.GetContent<GetListOfUsersDTO>(response);
            return content;

        }
        public CreateListOfUsersDTO CreateUsers(string endpoint, string payload)
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