using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Notifications
{
    public class QuoteCreateNotification : INotification
    {
        public string id { get; set; }
        public string shortName { get; set; }
        public DateTime captureDate { get; set; }
        public bool isCommitted { get; set; }
    }
}
