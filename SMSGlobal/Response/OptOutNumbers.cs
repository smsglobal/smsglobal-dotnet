using System;
/// <summary>
/// The response namespace.
/// </summary>
namespace SMSGlobal.SMS.Response
{
    /// <summary>
    /// The opt out numbers response object
    /// </summary>
    public class OptOutNumbers : Response
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }

        public OptOuts[] optouts { get; set; }


    }

    /// <summary>
    /// The opt out response object
    /// </summary>
    public class OptOuts : Response
    {
        public string date { get; set; }

        public string number { get; set; }

        public string status { get; set; }
    }

}
