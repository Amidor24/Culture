using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public record Create(string Name, string Description) : IRequest<CultureDto> { };
}
