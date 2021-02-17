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
            OTP = new SMSGlobal.api.OTP(Credentials);
        }

        public SMSGlobal.api.SMS SMS { get; private set; }

        public SMSGlobal.api.OTP OTP { get; private set; }

    }
}
