using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Notifications
{
    public class ErroNotification : INotification
    {
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
