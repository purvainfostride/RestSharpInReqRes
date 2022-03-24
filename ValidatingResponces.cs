using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}
