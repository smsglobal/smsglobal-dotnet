using System;
/// <summary>
/// The response namespace.
/// </summary>
namespace SMSGlobal.SMS.Response
{
    /// <summary>
    /// The sms income messages response object
    /// </summary>
    public class SmsIncoming : Response
    {
        public int id { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }

        public string message { get; set; }

        public bool isUnicode { get; set; }

        public DateTime dateTime { get; set; }

        public Campaign campaign { get; set; }

        public bool isMultipart { get; set; }

        public int partNumber { get; set; }

        public int totalParts { get; set; }
    }

    /// <summary>
    /// The sms income response object
    /// </summary>
    public class Campaign : Response
    {
        public string id { get; set; }
    }
}
