/// <summary>
/// The response namespace.
/// </summary>
namespace SMSGlobal.Response
{
    /// <summary>
    /// The OTP response object
    /// </summary>
    public class OTPRespone : Response
    {
        public string requestId { get; set; }
        public string destination { get; set; }
        public string validUnitlTimestamp { get; set; }
        public string createdTimestamp { get; set; }
        public string lastEventTimestamp { get; set; }
        public string status { get; set; }
    }
}
