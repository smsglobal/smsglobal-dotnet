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

    }
}
