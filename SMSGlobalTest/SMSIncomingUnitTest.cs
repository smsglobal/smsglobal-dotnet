using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SMSGlobal.api;
using System;
using System.Net;

namespace SMSGlobalTest
{
    [TestClass]
    public class SMSIncomingUnitTest
    {

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodGetSMSIncoming()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string filter = "limit=1";
            var a = await client.SMS.SMSGetIncoming(filter);
            Assert.IsNotNull(a.messages[0].id);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodDeleteSMSIncoming()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));
            
            string id = "123457";
            var a = await client.SMS.SMSDeleteIncoming(id);
            Assert.AreEqual(a, 204);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodGetSMSId()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string id = "457337691";
            var a = await client.SMS.SMSGetIncomingById(id);
            Assert.IsNotNull(a);
        }

    }
}
