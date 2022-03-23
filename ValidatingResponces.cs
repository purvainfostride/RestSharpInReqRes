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
            var demo = new CRUDMethods();
            var response = demo.GetUsers(); //returning objects from the method
            Assert.AreEqual(2, response.Page);
            Assert.AreEqual("Michael", response.Data[0].first_name);
            Assert.AreEqual("Lindsay", response.Data[1].first_name);
        }
    }
}
