using Order.Application.Contracts.Dto;
using Refit;

namespace Order.Application
{
    public interface IQuotesApi
    {
        [Get("/random")]
        Task<Quote> GetQuote();
    }
}

