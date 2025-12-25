using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public record GetAll : IRequest<IReadOnlyList<CultureDto>>;
}
