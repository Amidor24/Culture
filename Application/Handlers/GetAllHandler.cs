using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class GetAllHandler(IRepository repository) : IRequestHandler<GetAll, IReadOnlyList<CultureDto>>
    {
        private readonly IRepository _repository = repository;

        public async Task<IReadOnlyList<CultureDto>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Culture> Cultures = await _repository.GetAllAsync(cancellationToken);

            return [.. Cultures
                .Select(Culture => new CultureDto(
                    Culture.Id,
                    Culture.Name,
                    Culture.Description))];
        }
    }
}
