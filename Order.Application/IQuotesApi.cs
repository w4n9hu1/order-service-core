using System;
using Order.Application.DTO;
using Refit;

namespace Order.Application
{
    public interface IQuotesApi
    {
        [Get("/random")]
        Task<Quote> GetQuote();
    }
}

