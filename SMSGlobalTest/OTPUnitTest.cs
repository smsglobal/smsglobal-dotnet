using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SMSGlobal.api;
using System;
using System.Net;

namespace SMSGlobalTest
{
    [TestClass]
    public class OTPUnitTest
    {
           [TestMethod]
          public async System.Threading.Tasks.Task TestMethodSendOTP()
          {
              var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

              var response = await client.OTP.OTPSend(new
              {
                  message = "{*code*} is your SMSGlobal verification code.",
                  destination = "DESTINATION-NUMBER",
              });

              Assert.IsNotNull(response);
          }    

         [TestMethod]
         public async System.Threading.Tasks.Task TestMethodValidateOTPRequest()
         {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string requestid = "REQUEST-ID";
            string code = "OTP-CODE";
            var response = await client.OTP.OTPValidateRequest(requestid, new
            {
                code = code,
            });

            Assert.IsNotNull(response);
         } 

         [TestMethod]
         public async System.Threading.Tasks.Task TestMethodValidateOTPDestination()
         {
             var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

             string destinationid = "DESTINATION-NUMBER";
             string code = "OTP-CODE";
             var response = await client.OTP.OTPValidateDestination(destinationid, new
             {
                 code = code,
             });

             Assert.IsNotNull(response);
         }
        

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodCancelOTPRequest()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string requestid = "REQUEST-ID";
            var response = await client.OTP.OTPCancelRequest(requestid);
            Assert.IsNotNull(response.requestId);
        }  
       
        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodCancelOTPDestination()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string destination = "DESTINATION-NUMBER";
            var response = await client.OTP.OTPCancelDestination(destination);
            Assert.IsNotNull(response);
        }       
    }
}
