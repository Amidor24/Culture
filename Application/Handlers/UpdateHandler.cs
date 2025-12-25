using Application.Commands;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class UpdateHandler(IRepository repository) : IRequestHandler<Update, CultureDto>
    {
        private readonly IRepository _repository = repository;

        public async Task<CultureDto> Handle(Update request, CancellationToken cancellationToken)
        {
            Culture culture = await _repository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new KeyNotFoundException($"Culture with Id {request.Id} not found.");

            culture.Name = request.Name;

            culture.Description = request.Reference;

            await _repository.UpdateAsync(culture, cancellationToken);

            return new CultureDto(culture.Id, culture.Name, culture.Description);
        }
    }
}
