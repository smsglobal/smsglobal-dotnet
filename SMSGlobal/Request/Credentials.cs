namespace SMSGlobal.api
{
    public class Credentials
    {
        /// <summary>
        /// SMS API Key (from your account dashboard)
        /// </summary>
        public string ApiKey { get; set; }
        /// <summary>
        /// SMS API Secret (from your account dashboard)
        /// </summary>
        public string ApiSecret { get; set; }
        /// <summary>
        /// Host URL
        /// </summary>
        public string host { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public string port { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public string version { get; set; }

        public Credentials()
        {

        }

        public Credentials(string smsApiKey, string smsApiSecret)
        {
            host = "api.smsglobal.com";
            port = "443";
            version = "v2";
            ApiKey = smsApiKey;
            ApiSecret = smsApiSecret;
        }
    }
}
