using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharpInReqRes.DTOs;

namespace RestSharpInReqRes
{
    [TestClass]
    public class ValidatingResponces
    {
        [TestMethod]
        public void VerifyListOfUsers()
        {
            var crudmethods = new CRUDMethods();
            var response = crudmethods.GetUsers(); //returning objects of methods from the CRUDMETHODS class
            Assert.AreEqual(2, response.Page);
            Assert.AreEqual("Michael", response.Data[0].First_name);
            Assert.AreEqual("Lindsay", response.Data[1].First_name);
        }
        [TestMethod]
        public void CreateNewUser()
        {
            string payload= @"{
                                ""name"": ""morpheus"",
                                ""job"": ""leader""
                                }";
            var user = new APIHelper<CreateListOfUsersDTO>();
            var url=user.SetUrl("api/users");
            var request = user.CreatePostRequest(payload);
            var response=user.GetResponse(url,request);
            CreateListOfUsersDTO content = user.GetContent<CreateListOfUsersDTO>(response);
            Assert.AreEqual("morpheus", content.Name);
            Assert.AreEqual("leader", content.Job);

        }
    }
}
