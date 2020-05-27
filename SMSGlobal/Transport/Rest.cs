using Newtonsoft.Json;
using SMSGlobal.api;
using SMSGlobal.SMS.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMSGlobal.SMS.Transport
{
    /// <summary>
    /// The rest api class.
    /// </summary>
    class Rest
    {
        private Uri uri;

        public string host { get; set; }
        public string port { get; set; }
        public string version { get; set; }
        public string key { get; set; }
        public string secret { get; set; }
        
        public Rest(Credentials _credentials)
        {
            host = _credentials.host;
            port = _credentials.port;
            version = _credentials.version;
            key = _credentials.ApiKey;
            secret = _credentials.ApiSecret;
        }

        /// <summary>
        /// Gets the credit balance.
        /// </summary>
        /// <returns>Task</returns>
        public async Task<Response.CreditBalance> getCreditBalance()
        {
            HttpResponseMessage response = await Request("user/credit-balance");

            return await response.Content.ReadAsAsync<Response.CreditBalance>();
        }

        /// <summary>
        /// Gets sms message by Id.
        /// </summary>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>Task</returns>
        public async Task<Response.SmsSent> getSmsId(string id = "")
        {
            HttpResponseMessage response = await Request("sms", null, null, id);

            return await response.Content.ReadAsAsync<Response.SmsSent>();
        }

        /// <summary>
        /// Delete sms message by Id.
        /// </summary>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>Task</returns>
        public async Task<int> deleteSmsId(string id = "")
        {
            HttpResponseMessage response = await Request("sms", null, null, id, "delete");

            return (int)response.StatusCode;
        }

        /// <summary>
        /// Gets sms messages.
        /// </summary>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>Task</returns>
        public async Task<Response.SmsSentMessages> getSms(string filter = "")
        {
            HttpResponseMessage response = await Request("sms", null, filter);

            return await response.Content.ReadAsAsync<Response.SmsSentMessages>();
        }

        /// <summary>
        /// Sends an sms message.
        /// </summary>
        /// <returns>Task</returns>
        public async Task<Response.SmsSentMessages> sendSms(Object payload)
        {
            HttpResponseMessage response = await Request("sms", payload);

            return await response.Content.ReadAsAsync<Response.SmsSentMessages>();
        }

        /// <summary>
        /// Gets incoming sms messages.
        /// </summary>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>Task</returns>
        public async Task<Response.SmsSentMessages> getSmsIncoming(string filter = "")
        {
            HttpResponseMessage response = await Request("sms-incoming", null, filter);

            return await response.Content.ReadAsAsync<Response.SmsSentMessages>();
        }

        /// <summary>
        /// Delete incoming sms message by Id.
        /// </summary>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>Task</returns>
        public async Task<int> deleteSmsIncoming(string id = "")
        {
            HttpResponseMessage response = await Request("sms-incoming", null, null, id, "delete");

            return (int)response.StatusCode;
        }

        /// <summary>
        /// Gets sms message by Id.
        /// </summary>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>Task</returns>
        public async Task<Response.SmsIncoming> getSmsIncomingById(string id = "")
        {
            HttpResponseMessage response = await Request("sms-incoming", null, null, id);

            return await response.Content.ReadAsAsync<Response.SmsIncoming>();
        }

        /// <summary>
        /// Gets opt out number.
        /// </summary>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>Task</returns>
        public async Task<Response.OptOutNumbers> getOptOuts(string filter = "")
        {
            HttpResponseMessage response = await Request("opt-outs", null, filter);

            return await response.Content.ReadAsAsync<Response.OptOutNumbers>();
        }

        /// <summary>
        /// Opt out mobile number.
        /// </summary>
        /// <returns>Task</returns>
        public async Task<Response.OptOutNumbers> sendOptOut(Object payload)
        {
            HttpResponseMessage response = await Request("opt-outs", payload);

            return await response.Content.ReadAsAsync<Response.OptOutNumbers>();
        }

        /// <summary>
        /// Opt out validate mobile numbers.
        /// </summary>
        /// <returns>Task</returns>
        public async Task<Response.OptOutNumbers> sendOptOutValidate(Object payload)
        {
            HttpResponseMessage response = await Request("opt-outs/validate", payload);

            return await response.Content.ReadAsAsync<Response.OptOutNumbers>();
        }

        /// <summary>
        /// Opt in a mobile number
        /// </summary>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>Task</returns>
        public async Task<int> deleteOptOut(string number = "")
        {
            HttpResponseMessage response = await Request("opt-outs", null, null, number, "delete");

            return (int)response.StatusCode;
        }

        /// <summary>
        /// Requests information from the rest api.
        /// </summary>
        /// <param name="path">The rest api path.</param>
        /// <param name="payload">The rest api method.</param>
        /// <param name="filter">The rest api query string result filter.</param>
        /// <returns>The http response message object.</returns>
        private async Task<HttpResponseMessage> Request(string path, Object payload = null, string filter = "", string smsid = "", string method = "")
        {
            using (var client = new HttpClient())
            {
                string credentials = "";
                if (method == "delete")
                {
                    credentials = Credentials(path, "DELETE", filter, smsid);
                }
                else
                {
                    credentials = Credentials(path, null == payload ? "GET" : "POST", filter, smsid);
                }
                
                client.BaseAddress = new Uri(string.Format("{0}://{1}", uri.Scheme, uri.Host));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("MAC", credentials);

                var json = JsonConvert.SerializeObject(payload);

                HttpResponseMessage response = null;

                if (method == "delete")
                {
                    response = await client.DeleteAsync(uri.PathAndQuery);

                    return response;
                }
                else
                {
                    response = null == payload ? await client.GetAsync(uri.PathAndQuery) : await client.PostAsync(uri.PathAndQuery, new StringContent(json, Encoding.UTF8, "application/json"));

                    response.EnsureSuccessStatusCode();

                    return response;
                }
                    
            }
        }

        /// <summary>
        /// Compiles the mac oauth2 credentials.
        /// </summary>
        /// <param name="path">The request path.</param>
        /// <param name="method">The request method.</param>
        /// <returns>The credential string.</returns>
        private string Credentials(string path, string method = "GET", string filter = "", string smsid = "")
        {
            if (filter != null)
            {
                uri = new Uri(string.Format("https://{0}/{1}/{2}/?{3}", host, version, path, filter));
            }
            else if (smsid != null)
            {
                uri = new Uri(string.Format("https://{0}/{1}/{2}/{3}", host, version, path, smsid));
            }

            string timestamp = ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
            string nonce = Guid.NewGuid().ToString("N");
            string mac = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n\n", timestamp, nonce, method, uri.PathAndQuery, uri.Host, port);

            mac = Convert.ToBase64String((new HMACSHA256(Encoding.ASCII.GetBytes(secret))).ComputeHash(Encoding.ASCII.GetBytes(mac)));

            return string.Format("id=\"{0}\", ts=\"{1}\", nonce=\"{2}\", mac=\"{3}\"", key, timestamp, nonce, mac);
        }
    }
}
