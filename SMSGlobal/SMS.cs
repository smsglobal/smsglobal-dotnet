using System;
using System.Collections.Generic;
using System.Text;
using SMSGlobal.SMS.Response;
using System;
using System.Configuration;
using System.Net.Http;


namespace SMSGlobal.api
{
    public class SMS
    {
        public Credentials Credentials { get; set; }
        public SMS(Credentials creds)
        {
            Credentials = creds;
        }

        public async System.Threading.Tasks.Task<SmsSentMessages> SMSSend(Object payload)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // send an sms message
            var res = await rest.sendSms(payload);

            return res;
        }


        public async System.Threading.Tasks.Task<SmsSentMessages> SMSGetAll(string filter)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // get all messages using filter
            var res = await rest.getSms(filter);

            return res;
        }

        public async System.Threading.Tasks.Task<SmsSent> SMSGetId(string id)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // gets a message
            var res = await rest.getSmsId(id);

            return res;
        }

        public async System.Threading.Tasks.Task<int> SMSDeleteId(string id)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // delete a message
            var res = await rest.deleteSmsId(id);

            return res;
        }

        public async System.Threading.Tasks.Task<SmsSentMessages> SMSGetIncoming(string filter)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // get all incoming messages using filter
            var res = await rest.getSmsIncoming(filter);

            return res;
        }

        public async System.Threading.Tasks.Task<int> SMSDeleteIncoming(string id)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // delete an incoming message
            var res = await rest.deleteSmsIncoming(id);

            return res;
        }

        public async System.Threading.Tasks.Task<SmsIncoming> SMSGetIncomingById(string id)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // gets an incoming message
            var res = await rest.getSmsIncomingById(id);

            return res;
        }

        public async System.Threading.Tasks.Task<OptOutNumbers> SMSGetOptOuts(string filter)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // get all opt out numbers using filter
            var res = await rest.getOptOuts(filter);

            return res;
        }

        public async System.Threading.Tasks.Task<OptOutNumbers> SMSPostOptOut(Object payload)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // post an opt out mobile number
            var res = await rest.sendOptOut(payload);

            return res;
        }

        public async System.Threading.Tasks.Task<OptOutNumbers> SMSPostOptOutValidate(Object payload)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // validate opt out
            var res = await rest.sendOptOutValidate(payload);

            return res;
        }

        public async System.Threading.Tasks.Task<int> SMSDeleteOptOut(string number)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            // opt out mobile number
            var res = await rest.deleteOptOut(number);

            return res;
        }

    }
}
