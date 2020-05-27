using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SMSGlobal.api;
using System;
using System.Net;

namespace SMSGlobalTest
{
    [TestClass]
    public class SMSUnitTest
    {

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodSendSMS()
        {
             var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            var response = await client.SMS.SMSSend(new
            {
                origin = "Test",
                destination = "DESTINATION-NUMBER",
                message = "This is a test message"
            });

            Assert.IsNotNull(response.messages[0].outgoing_id);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodGetSMS()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string filter = "limit=1";
            var response = await client.SMS.SMSGetAll(filter);
            Assert.IsNotNull(response.messages[0].id);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodGetSMSId()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string id = "SMSGLOBAL-OUTGOING-ID";
            var response = await client.SMS.SMSGetId(id);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodDeleteSMSId()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string id = "SMSGLOBAL-OUTGOING-ID";
            var response = await client.SMS.SMSDeleteId(id);
            Assert.IsNotNull(response);
        }
    }
}
