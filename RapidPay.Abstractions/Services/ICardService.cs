using RapidPay.Core.Dtos;
using RapidPay.Core.Entities;

namespace RapidPay.Abstractions.Services
{
    public interface ICardService
    {
        Task<CardDto> CreateAsync(Card card);

        Task<CardDto> GetByIdAsync(Guid cardId);
    }
}
