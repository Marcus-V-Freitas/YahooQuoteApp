using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YahooQuoteApp.Models.URI
{
    public abstract class UriHelper
    {
        private string _url;

        public UriHelper(string url)
        {
            _url = url;
        }

        public string Url { get => _url; }

        private void UriAction(Action<NameValueCollection> action)
        {
            var uriBuilder = new UriBuilder(_url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            action.Invoke(query);
            uriBuilder.Query = query.ToString();
            _url = uriBuilder.Uri.AbsoluteUri;
        }

        public void AddQueryString(Dictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
            {
                AddQueryString(parameter.Key, parameter.Value);
            }
        }

        public void AddQueryString(string key, string value)
        {
            var action = (NameValueCollection query) => query.Add(key, value);
            UriAction(action);
        }

        public void RemoveQueryString(List<string> keys)
        {
            foreach (var key in keys)
            {
                RemoveQueryString(key);
            }
        }

        public void RemoveQueryString(string key)
        {
            var action = (NameValueCollection query) => query.Remove(key);
            UriAction(action);
        }
    }
}
