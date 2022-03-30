using NUnit.Framework;
using RestSharp;
using RestSharpInReqRes.DTOs;
using System;
using TechTalk.SpecFlow;

namespace RestSharpInReqRes
{
    [Binding]
    public class CreateUserStepDefinitions
    {
        private const string baseUrl = "https://reqres.in/";
        private readonly CreateUserRequestDTO createUserRequestDTO;
        public IRestResponse response;
        public CreateUserStepDefinitions(CreateUserRequestDTO createUserRequestDTO)
        {
            this.createUserRequestDTO = createUserRequestDTO;
        }

        [Given(@"I input name ""([^""]*)""")]
        public void GivenIInputName(string name)
        {
            createUserRequestDTO.Name = name;
        }

        [Given(@"I input job ""([^""]*)""")]
        public void GivenIInputJob(string role)
        {
            createUserRequestDTO.Job = role;
        }
        //[DeploymentItem("TestData")]
        [When(@"I send create user request")]
        public dynamic WhenISendCreateUserRequest()
        {
            var payload = HandleContent.ParseJson<CreateUserRequestDTO>("C:\\Users\\Purva\\C#\\RestSharpInReqRes\\TestData\\CreateUser.json");
            return payload;
        }

        [Then(@"user is created successfully")]
        public void ThenUserIsCreatedSuccessfully()
        {
            var crudmethods = new CRUDMethods<CreateUserDTO>();
            var content = crudmethods.CreateUsers("api/users", WhenISendCreateUserRequest());
            Assert.AreEqual(WhenISendCreateUserRequest().Name, content.Name);
        }
    }
}
