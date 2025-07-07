using Agremate.ApplicationContracts.Dtos.Sample;
using Agremate.DomainShared;

namespace Agremate.ApplicationContracts.ServiceInterfaces;

public interface ISampleService
{
    Task<CustomResponse<string>> CreateAsync(SampleDto sampleDto);
    Task<CustomResponse<List<SampleDto>>> GetAllAsync();
    Task<CustomResponse<SampleDto>> GetByIdAsync(Guid id);
    Task<CustomResponse<string>> UpdateAsync(Guid id, SampleDto sampleDto);
    Task<CustomResponse<string>> DeleteAsync(Guid? id);
}
