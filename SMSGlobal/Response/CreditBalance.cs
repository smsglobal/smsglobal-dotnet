/// <summary>
/// The response namespace.
/// </summary>
namespace SMSGlobal.SMS.Response
{
    /// <summary>
    /// The credit balance response object
    /// </summary>
    public class CreditBalance : Response
    {
        public double balance { get; set; }
        public string currency { get; set; }
    }
}
