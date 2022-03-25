using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharpInReqRes.DTOs;

namespace RestSharpInReqRes
{
    [TestClass]
    public class ValidatingResponces
    {
        [TestMethod]
        public void ValidateGetUsers()
        {
            var crudmethods = new CRUDMethods<GetListOfUsersDTO>();
            var user = crudmethods.GetUsers("api/users?page=2"); //returning objects of methods from the CRUDMETHODS class
            Assert.AreEqual(2, user.Page);
            Assert.AreEqual("Michael", user.Data[0].First_name);
            Assert.AreEqual("Lindsay", user.Data[1].First_name);

        }
        [TestMethod]
        public void ValidateCreateNewUser()
        {
            string payload= @"{
                                ""name"": ""morpheus"",
                                ""job"": ""leader""
                                }";
            var crudmethods = new CRUDMethods<CreateListOfUsersDTO>();
            var user = crudmethods.CreateUsers("api/users",payload);
            Assert.AreEqual("morpheus", user.Name);
            Assert.AreEqual("leader", user.Job);
        }
      

    }
}
