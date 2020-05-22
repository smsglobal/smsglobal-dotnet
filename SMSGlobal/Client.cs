using SMSGlobal.SMS.Response;
using System;
using System.Configuration;
using System.Net.Http;

namespace SMSGlobal.api
{
    public class Client
    {
        private Credentials _credentials;

        public Client(Credentials credentials)
        {
            _credentials = credentials;
            PropagateCredentials();
        }

        public Credentials Credentials
        {
            get => _credentials;
            set
            {
                _credentials = value;
                PropagateCredentials();
            }
        }

        private void PropagateCredentials()
        {
            SMS = new SMSGlobal.api.SMS(Credentials);
        }

        public SMSGlobal.api.SMS SMS { get; private set; }
    }
}
