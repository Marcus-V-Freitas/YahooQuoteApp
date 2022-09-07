using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Models.WEB
{
    public sealed class HttpHelper : IHttpHelper, IDisposable
    {
        private readonly HttpClient _client;
        private readonly HttpClientHandler _handler;

        public int Timeout
        {
            get => _client.Timeout.Seconds;
            set => _client.Timeout = TimeSpan.FromSeconds(value);
        }

        public HttpStatusCode StatusCode { get; private set; }
        public HttpResponseHeaders Headers { get; private set; }

        public HttpHelper(WebProxy proxy = null)
        {
            _handler = new HttpClientHandler();

            if (proxy != null)
            {
                _handler.UseProxy = true;
                _handler.Proxy = proxy;
            }

            _client = new HttpClient(_handler);
        }

        public void Dispose()
        {
            _client.Dispose();
            _handler.Dispose();
        }

        private void AddHeaders(HttpRequestMessage messageHandler, Dictionary<string, string> headers)
        {
            if (headers == null || !headers.Any())
            {
                return;
            }

            foreach (var header in headers)
            {
                messageHandler.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        private async Task<T> MakeRequest<T>(HttpMethod method, string url, Dictionary<string, string> headers = null, HttpContent body = null)
        {
            T entity = default;

            using (HttpRequestMessage messageHandler = new HttpRequestMessage(method, url))
            {
                if (body != null)
                {
                    messageHandler.Content = body;
                }

                AddHeaders(messageHandler, headers);

                var response = await _client.SendAsync(messageHandler);
                StatusCode = response.StatusCode;
                Headers = response.Headers;

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        entity = JsonConvert.DeserializeObject<T>(content);
                    }
                    catch
                    {
                        entity = default;
                    }

                }
            }
            return entity;
        }

        public async Task<T> Get<T>(string url, Dictionary<string, string> headers = null)
        {
            return await MakeRequest<T>(HttpMethod.Get, url, headers);
        }

        public async Task<T> Post<T>(string url, HttpContent body, Dictionary<string, string> headers = null)
        {
            return await MakeRequest<T>(HttpMethod.Post, url, headers, body);
        }

        public async Task<T> Put<T>(string url, HttpContent body, Dictionary<string, string> headers = null)
        {
            return await MakeRequest<T>(HttpMethod.Put, url, headers, body);
        }

        public async Task<T> Delete<T>(string url, Dictionary<string, string> headers = null)
        {
            return await MakeRequest<T>(HttpMethod.Delete, url, headers);
        }
    }
}
