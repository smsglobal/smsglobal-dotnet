using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSGlobal.api;

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
            var response = await client.SMS.SMSGetIncoming(filter);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodDeleteSMSIncoming()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string id = "INCOMING-NUMBER";
            var response = await client.SMS.SMSDeleteIncoming(id);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodGetSMSIncomingById()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string id = "SMSGLOBAL-OUTGOING-ID";
            var response = await client.SMS.SMSGetIncomingById(id);
            Assert.IsNotNull(response);
        }

    }
}
