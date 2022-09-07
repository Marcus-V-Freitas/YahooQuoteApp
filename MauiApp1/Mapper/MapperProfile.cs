using AutoMapper;
using YahooQuoteApp.Command.Models;
using YahooQuoteApp.ExtensionMethods;
using YahooQuoteApp.Models;
using YahooQuoteApp.Models.YahooRequestsModels;

namespace YahooQuoteApp.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateYahooQuoteCommand, YahooQuote>()
                .ReverseMap();

            CreateMap<Quote, CreateYahooQuoteCommand>()
                .ForMember(dst => dst.fullExchangeName, map => map.MapFrom(src => src.fullExchangeName))
                .ForMember(dst => dst.symbol, map => map.MapFrom(src => src.symbol))
                .ForMember(dst => dst.regularMarketOpen, map => map.MapFrom(src => src.regularMarketOpen.fmt.ToMoney()))
                .ForMember(dst => dst.regularMarketChangePercent, map => map.MapFrom(src => src.regularMarketChangePercent.fmt.ToMoney()))
                .ForMember(dst => dst.regularMarketDayHigh, map => map.MapFrom(src => src.regularMarketDayHigh.fmt.ToMoney()))
                .ForMember(dst => dst.tradeable, map => map.MapFrom(src => src.tradeable))
                .ForMember(dst => dst.contractSymbol, map => map.MapFrom(src => src.contractSymbol))
                .ForMember(dst => dst.currency, map => map.MapFrom(src => src.currency))
                .ForMember(dst => dst.regularMarketPreviousClose, map => map.MapFrom(src => src.regularMarketPreviousClose.fmt.ToMoney()))
                .ForMember(dst => dst.regularMarketChange, map => map.MapFrom(src => src.regularMarketChange.fmt.ToMoney()))
                .ForMember(dst => dst.cryptoTradeable, map => map.MapFrom(src => src.cryptoTradeable))
                .ForMember(dst => dst.regularMarketPrice, map => map.MapFrom(src => src.regularMarketPrice.fmt.ToMoney()))
                .ForMember(dst => dst.market, map => map.MapFrom(src => src.market))
                .ForMember(dst => dst.regularMarketVolume, map => map.MapFrom(src => src.regularMarketVolume.fmt.ToMoney()))
                .ForMember(dst => dst.regularMarketDayLow, map => map.MapFrom(src => src.regularMarketDayLow.fmt.ToMoney()))
                .ForMember(dst => dst.shortName, map => map.MapFrom(src => src.shortName))
                .ForMember(dst => dst.region, map => map.MapFrom(src => src.region))
                .ForMember(dst => dst.triggerable, map => map.MapFrom(src => src.triggerable))
                .ReverseMap();
        }
    }
}
