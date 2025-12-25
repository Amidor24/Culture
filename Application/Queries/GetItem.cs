using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public record GetItem(Guid Id) : IRequest<CultureDto>;
}