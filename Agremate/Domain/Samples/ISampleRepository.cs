namespace Agremate.Domain.Samples;

public interface ISampleRepository
{
    Task<Sample> GetByIdAsync(Guid id);
    Task<IEnumerable<Sample>> GetAllAsync();
    Task AddAsync(Sample sample);
    Task UpdateAsync(Sample sample);
    Task DeleteAsync(Guid id);
}
