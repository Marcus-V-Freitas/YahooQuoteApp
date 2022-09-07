using AutoMapper;
using YahooQuoteApp.Command.Models;
using YahooQuoteApp.Models;
using YahooQuoteApp.Notifications;
using YahooQuoteApp.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooQuoteApp.Command.Handler
{
    public class CreateYahooQuoteCommandHandler : IRequestHandler<CreateYahooQuoteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IYahooService _yahooService;
        private readonly IMapper _mapper;

        public CreateYahooQuoteCommandHandler(IMediator mediator, IYahooService yahooService, IMapper mapper)
        {
            _mediator = mediator;
            _yahooService = yahooService;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateYahooQuoteCommand request, CancellationToken cancellationToken)
        {
            YahooQuote yahooQuote = _mapper.Map<YahooQuote>(request);

            try
            {
                await _yahooService.SaveYahooQuoteAsync(yahooQuote);

                await _mediator.Publish(new QuoteCreateNotification { id = yahooQuote.id, shortName = yahooQuote.shortName, captureDate = yahooQuote.captureDate, isCommitted = true });

                return await Task.FromResult($"Saved {yahooQuote.id}!!!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new QuoteCreateNotification { id = yahooQuote.id, shortName = yahooQuote.shortName, captureDate = yahooQuote.captureDate, isCommitted = false });
                await _mediator.Publish(new ErroNotification { Exception = ex.Message, StackTrace = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }

        }
    }
}
