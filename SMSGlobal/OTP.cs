using System;
using System.Collections.Generic;
using System.Text;
using SMSGlobal.Response;
using System.Configuration;
using System.Net.Http;


namespace SMSGlobal.api
{
    public class OTP
    {
        public Credentials Credentials { get; set; }
        public OTP(Credentials creds)
        {
            Credentials = creds;
        }

        public async System.Threading.Tasks.Task<OTPRespone> OTPSend(Object payload)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            var res = await rest.sendOTP(payload);

            return res;
        }

        public async System.Threading.Tasks.Task<OTPRespone> OTPValidateRequest(string requestid, Object payload)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            var res = await rest.OTPValidateRequest(requestid, payload);

            return res;
        }

        public async System.Threading.Tasks.Task<OTPRespone> OTPValidateDestination(string destinationid, Object payload)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            var res = await rest.OTPValidateDestination(destinationid, payload);

            return res;
        }
        
        public async System.Threading.Tasks.Task<OTPRespone> OTPCancelRequest(string requestid)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            var res = await rest.OTPCancelRequest(requestid);

            return res;
        }

        public async System.Threading.Tasks.Task<OTPRespone> OTPCancelDestination(string destination)
        {
            SMSGlobal.SMS.Transport.Rest rest = new SMSGlobal.SMS.Transport.Rest(Credentials);

            var res = await rest.OTPCancelDestination(destination);

            return res;
        }

    }
}
