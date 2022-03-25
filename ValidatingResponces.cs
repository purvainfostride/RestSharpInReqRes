using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharpInReqRes.DTOs;

namespace RestSharpInReqRes
{
    [TestClass]
    public class ValidatingResponces
    {
        [TestMethod]
        public void ValidateGetListUsers()
        {
            var crudmethods = new CRUDMethods<GetListOfUsersDTO>();
            var user = crudmethods.GetListUsers("api/users?page=2"); //returning objects of methods from the CRUDMETHODS class
            Assert.AreEqual(2, user.Page);
            Assert.AreEqual("Michael", user.Data[0].First_name);
            Assert.AreEqual("Lindsay", user.Data[1].First_name);

        }
        [TestMethod]
        public void ValidateGetListResourceUsers()
        {
            var crudmethods = new CRUDMethods<GetListResource>();
            var user = crudmethods.GetListResourceUsers("api/unknown"); //returning objects of methods from the CRUDMETHODS class
            Assert.AreEqual(1, user.Page);
            Assert.AreEqual("cerulean", user.Data[0].Name);
            Assert.AreEqual("#C74375", user.Data[1].Color);

        }

        [TestMethod]
        public void ValidateCreateNewUser()
        {
            string payload= @"{
                                ""name"": ""morpheus"",
                                ""job"": ""QA""
                                }";
            var crudmethods = new CRUDMethods<CreateListOfUsersDTO>();
            var user = crudmethods.CreateUsers("api/users",payload);
            Assert.AreEqual("morpheus", user.Name);
            Assert.AreEqual("QA", user.Job);
        }
        [TestMethod]
        public void ValidateUpdateUsers()
        {
            string payload = @"{
                                ""name"": ""morpheus"",
                                ""job"": ""LEAD""
                                }";

            var crudmethods = new CRUDMethods<UpdateListDTO>();
            var user = crudmethods.UpdateUsers("api/users/2", payload);
            Assert.AreEqual("LEAD", user.Job);
        }


    }
}
