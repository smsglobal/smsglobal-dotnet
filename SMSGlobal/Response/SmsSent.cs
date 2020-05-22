/// <summary>
/// The response namespace.
/// </summary>
namespace SMSGlobal.SMS.Response
{
    /// <summary>
    /// The sms sent messages response object
    /// </summary>
    public class SmsSentMessages : Response
    {
        public SmsSent[] messages { get; set; }
    }

    /// <summary>
    /// The sms sent response object
    /// </summary>
    public class SmsSent : Response
    {
        public string id { get; set; }
        public string outgoing_id { get; set; }
        public string origin { get; set; }
        public string message { get; set; }
        public string dateTime { get; set; }
        public string status { get; set; }
    }
}
