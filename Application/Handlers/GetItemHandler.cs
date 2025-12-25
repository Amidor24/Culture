using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class GetItemHandler(IRepository repository) : IRequestHandler<GetItem, CultureDto>
    {
        private readonly IRepository _repository = repository;

        public async Task<CultureDto> Handle(GetItem request, CancellationToken cancellationToken)
        {
            Culture? culture = await _repository.GetByIdAsync(request.Id, cancellationToken);

            return culture == null ? null! : new CultureDto(culture.Id, culture.Name, culture.Description);
        }
    }
}
