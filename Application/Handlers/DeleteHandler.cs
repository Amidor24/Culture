using Application.Commands;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class DeleteHandler(IRepository repository) : IRequestHandler<Delete, bool>
    {
        private readonly IRepository _repository = repository;

        public async Task<bool> Handle(Delete request, CancellationToken cancellationToken)
        {
            Culture? culture = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (culture == null)
            {
                return false;
            }
            else
            {
                await _repository.DeleteAsync(culture.Id, cancellationToken);

                return true;
            }
        }
    }
}
