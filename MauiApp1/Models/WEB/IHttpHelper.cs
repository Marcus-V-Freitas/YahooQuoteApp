using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Models.WEB
{
    public interface IHttpHelper : IDisposable
    {
        int Timeout { get; set; }
        HttpStatusCode StatusCode { get; }
        HttpResponseHeaders Headers { get; }

        Task<T> Get<T>(string url, Dictionary<string, string> headers = null);
        Task<T> Post<T>(string url, HttpContent body, Dictionary<string, string> headers = null);
        Task<T> Put<T>(string url, HttpContent body, Dictionary<string, string> headers = null);
        Task<T> Delete<T>(string url, Dictionary<string, string> headers = null);

    }
}
