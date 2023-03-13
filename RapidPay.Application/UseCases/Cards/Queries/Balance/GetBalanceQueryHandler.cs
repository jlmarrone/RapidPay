using MediatR;
using RapidPay.Abstractions.Services;
using RapidPay.Core.Dtos;

namespace RapidPay.Application.UseCases.Cards.Queries.Balance
{
    internal class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, BalanceDto>
    {
        private readonly IBalanceService _balanceService;

        public GetBalanceQueryHandler(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }
        public async Task<BalanceDto> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            return await _balanceService.GetByCardAsync(request.CardId);
        }
    }
}
