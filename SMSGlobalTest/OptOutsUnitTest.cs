using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SMSGlobal.api;
using System;
using System.Net;

namespace SMSGlobalTest
{
    [TestClass]
    public class OptOutsUnitTest
    {

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodGetOptOuts()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string filter = "";
            var response = await client.SMS.SMSGetOptOuts(filter);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodPostOptOut()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            Object[] payload = new Object[2];

            payload[0] = new
            {
                number = "MOBILE-NUMBER"
            };

            payload[1] = new
            {
                number = "MOBILE-NUMBER"
            };

            var response = await client.SMS.SMSPostOptOut(new { optouts = payload });

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodPostOptOutValidate()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            Object[] payload = new Object[2];

            payload[0] = new
            {
                number = "MOBILE-NUMBER"
            };

            payload[1] = new
            {
                number = "MOBILE-NUMBER"
            };

            var response = await client.SMS.SMSPostOptOutValidate(new { optouts = payload });

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestMethodDeleteOptOut()
        {
            var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

            string number = "MOBILE-NUMBER";
            var response = await client.SMS.SMSDeleteOptOut(number);
            Assert.IsNotNull(response);
        }

    }
}
