using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    internal class CreateHandler(IRepository repository) : IRequestHandler<Create, CultureDto>
    {
        private readonly IRepository _repository = repository;

        public async Task<CultureDto> Handle(Create request, CancellationToken cancellationToken)
        {
            Culture culture = new()
            {
                Name = request.Name,
                Description = request.Description
            };

            Culture createdCulture = await _repository.Add(culture);

            CultureDto CultureDto = new(
                    createdCulture.Id,
                    createdCulture.Name,
                    createdCulture.Description
                );

            return CultureDto;
        }
    }
}
