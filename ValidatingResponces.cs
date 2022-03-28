using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharpInReqRes.DTOs;
using AventStack.ExtentReports;
namespace RestSharpInReqRes
{
    [TestClass]
    public class ValidatingResponces
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]//before this class Reporter class will run once
        public static void Setup(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetupExtentReporter("RestSharp Test", "RestSharp Testing Report", dir);
        }

        [TestInitialize]//for every test
        public void SetupTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status logstatus;
            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    logstatus = Status.Fail;
                    Reporter.TestStatus(logstatus.ToString());
                    break;
                case UnitTestOutcome.Passed:
                    logstatus = Status.Pass;
                    Reporter.TestStatus(logstatus.ToString());
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Reporter.FlushReport();
        }
        [DeploymentItem("TestData")]
        [TestMethod]
        public void ValidateGetListUsers()
        {
            var payload = HandleContent.Deserialize<GetListUsersDTO>("GetUser.json");
            var crudmethods = new CRUDMethods<GetListUsersDTO>();
            var content = crudmethods.GetListUsers("api/users?page=2");
            Assert.AreEqual(payload.Page, content.Page);

        }

        [TestMethod]
        public void ValidateGetListResourceUsers()
        {
            var payload = HandleContent.Deserialize<GetListResourceDTO>("GetResourceUser.json");
            var crudmethods = new CRUDMethods<GetListResourceDTO>();
            var content = crudmethods.GetListResourceUsers("api/unknown");
            Assert.AreEqual(payload.Page, content.Page);

        }

        [TestMethod]
        public void ValidateCreateNewUser()
        {
            var payload = HandleContent.Deserialize<CreateUserRequestDTO>("CreateUser.json");
            var crudmethods = new CRUDMethods<CreateUserDTO>();
            var content = crudmethods.CreateUsers("api/users", payload);
            Assert.AreEqual(payload.Name, content.Name);
            Assert.AreEqual(payload.Job, content.Job);
        }
    }
}
