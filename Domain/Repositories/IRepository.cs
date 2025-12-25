using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRepository
    {
        Task<Culture> Add(Culture culture);
        Task<IReadOnlyList<Culture>> GetAllAsync(CancellationToken ct = default);
        Task<Culture?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task UpdateAsync(Culture culture, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
