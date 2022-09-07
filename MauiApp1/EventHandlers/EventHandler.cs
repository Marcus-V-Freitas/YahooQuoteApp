using YahooQuoteApp.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.EventHandlers
{
    public class LogEventHandler : INotificationHandler<ErroNotification>,
                                   INotificationHandler<QuoteCreateNotification>
    {
        public Task Handle(QuoteCreateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CREATE: '{notification.id} - {notification.shortName} - {notification.captureDate:dd/MM/yyyy}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERROR: '{notification.Exception} - {notification.StackTrace}'");
            });
        }
    }
}
