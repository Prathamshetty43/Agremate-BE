using Agremate.Domain.Samples;
using Microsoft.EntityFrameworkCore;

namespace Agremate.EntityFramework.Repositories;

public class SampleRepository: ISampleRepository
{
    private readonly AgremateDbContext _context;
    public SampleRepository(AgremateDbContext context)
    {
        _context = context;
    }
    public async Task<Sample> GetByIdAsync(Guid id)
    {
        return await _context.Samples.FindAsync(id);
    }
    public async Task<IEnumerable<Sample>> GetAllAsync()
    {
        return await _context.Samples.ToListAsync();
    }
    public async Task AddAsync(Sample sample)
    {
        await _context.Samples.AddAsync(sample);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Sample sample)
    {
        _context.Samples.Update(sample);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        var sample = await GetByIdAsync(id);
        if (sample != null)
        {
            _context.Samples.Remove(sample);
            await _context.SaveChangesAsync();
        }
    }
}
