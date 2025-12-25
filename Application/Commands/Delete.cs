using MediatR;

namespace Application.Commands
{
    public record Delete(Guid Id) : IRequest<bool>;
}
