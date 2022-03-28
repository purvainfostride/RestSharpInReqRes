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
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);
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

    }
}