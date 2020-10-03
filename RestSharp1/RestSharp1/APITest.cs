using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp1.domain;

namespace RestSharp1
{
    [TestClass]
    public class APITest
    {
        private readonly string NAME = "user1";
        private readonly string EMAIL = "test@gmail.com";
        private readonly string PASSWORD = "abc123";

        private readonly string ACCOUNT_NO = "Acc12345";
        private readonly string ACCOUNT_NAME = "John Smith";
        private readonly string UPDATED_ACCOUNT_NAME = "Anna Nguyen";
        private readonly double UPDATED_ACCOUNT_BALANCE = 9999.99;

        private static RestClient restClient;
        private RestRequest request;
        private IRestResponse response;
        private static string JwtToken;
        


        /*        [TestInitialize]
                public void Setup()
                {

                }*/


        [ClassInitialize]
        public static void SetupOneTime(TestContext ctx)
        {
            restClient = new RestClient(Base.BASE_URL);
        }


        //[Ignore]
        [TestMethod]
        public void Test001_SignUpTest()
        {
            //Arrange
            //RestClient restClient = new RestClient(Base.BASE_URL);
            request = new RestRequest(EndPoint.SIGNUP, Method.POST);

            //set body of Post method
            JObject jObjectBody = new JObject();
            jObjectBody.Add("name", NAME);
            jObjectBody.Add("email", EMAIL);
            jObjectBody.Add("password", PASSWORD);

            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

            response = restClient.Execute(request);



            // assert

            Assert.AreEqual((int)response.StatusCode, 200);

            var signupDto = JsonConvert.DeserializeObject<SignUpDTO>(response.Content);
            Assert.AreEqual(signupDto.Id, "1");
            Assert.AreEqual(signupDto.UserEmail, EMAIL);


        }


        [TestMethod]
        public void Test002_SignInTest()
        {
            request = new RestRequest(EndPoint.SIGNIN, Method.POST);

            //set body of Post method
            JObject jObjectBody = new JObject();
            jObjectBody.Add("email", EMAIL);
            jObjectBody.Add("password", PASSWORD);

            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

            response = restClient.Execute(request);

            // assert
            Assert.AreEqual((int)response.StatusCode, 200);

            var signinDto = JsonConvert.DeserializeObject<SignInDTO>(response.Content);
            Assert.AreEqual(signinDto.Email, EMAIL);
            Assert.IsTrue(signinDto.Token.Length>100);
            JwtToken = signinDto.Token;

        }


        [TestMethod]
        public void Test003_ViewAccount()
        {
            request = new RestRequest(EndPoint.ACCOUNT, Method.GET);

            //set authorization header with JWT
            request.AddHeader("Authorization", "Bearer " + JwtToken);

            

            response = restClient.Execute(request);

            // assert
            Assert.AreEqual((int)response.StatusCode, 200);

            var accountDto = JsonConvert.DeserializeObject<AccountDTO>(response.Content);

            Assert.AreEqual(accountDto.AccountNo, ACCOUNT_NO);
            Assert.AreEqual(accountDto.AccountName, ACCOUNT_NAME);
            Assert.IsTrue(accountDto.Balance>1000);
            

        }

        [TestMethod]
        public void Test004_ChangeAccount()
        {
            request = new RestRequest(EndPoint.ACCOUNT, Method.PUT);

            //set authorization header with JWT
            request.AddHeader("Authorization", "Bearer " + JwtToken);

            //set body of Post method
            JObject jObjectBody = new JObject();
            jObjectBody.Add("accountName", UPDATED_ACCOUNT_NAME);
            jObjectBody.Add("balance", UPDATED_ACCOUNT_BALANCE);
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

            response = restClient.Execute(request);

            // assert
            Assert.AreEqual((int)response.StatusCode, 200);

            var accountDto = JsonConvert.DeserializeObject<AccountDTO>(response.Content);
            Assert.AreEqual(accountDto.AccountNo, ACCOUNT_NO);
            Assert.AreEqual(accountDto.AccountName, UPDATED_ACCOUNT_NAME);
            Assert.AreEqual(accountDto.Balance, UPDATED_ACCOUNT_BALANCE);
            
            

        }

    }

}
