using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public record Update(Guid Id, string Name, string Reference) : IRequest<CultureDto> { }
}