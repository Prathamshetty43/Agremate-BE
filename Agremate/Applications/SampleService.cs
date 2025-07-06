using Agremate.ApplicationContracts.Dtos.Sample;
using Agremate.ApplicationContracts.ServiceInterfaces;
using Agremate.Domain.Samples;
using Agremate.DomainShared;
using Microsoft.Extensions.Logging;

namespace Agremate.Applications;

public class SampleService : ISampleService
{
    private readonly ISampleRepository _sampleRepository;
    private readonly ILogger<SampleService> _logger;

    public SampleService(
        ISampleRepository sampleRepository,
        ILogger<SampleService> logger)
    {
        _sampleRepository = sampleRepository;
        _logger = logger;
    }

    public async Task<CustomResponse<string>> CreateAsync(SampleDto sampleDto)
    {
        var traceId = Guid.NewGuid().ToString();
        _logger.LogInformation("CreateAsync sample started with TraceId: {TraceId}", traceId);
        try
        {
            await _sampleRepository.AddAsync(new Sample
            {
                Name = sampleDto.Name,
                Description = sampleDto.Description
            });
            return new CustomResponse<string>
            {
                Status = true,
                Message = "Sample created successfully",
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating sample");
            return new CustomResponse<string>
            {
                Status = false,
                Message = ex.InnerException?.Message ?? ex.Message,
            };
        }
    }

    public async Task<CustomResponse<string>> DeleteAsync(Guid? id)
    {
        var traceId = Guid.NewGuid().ToString();
        _logger.LogInformation("DeleteAsync started with TraceId: {TraceId}", traceId);
        try
        {
            if (id == null)
                return new CustomResponse<string> { Status = false, Message = "Id cannot be null" };

            await _sampleRepository.DeleteAsync(id.Value);

            return new CustomResponse<string>
            {
                Status = true,
                Message = "Sample deleted successfully"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting sample");
            return new CustomResponse<string>
            {
                Status = false,
                Message = ex.InnerException?.Message ?? ex.Message
            };
        }
    }

    public async Task<CustomResponse<List<SampleDto>>> GetAllAsync()
    {
        var traceId = Guid.NewGuid().ToString();
        _logger.LogInformation("GetAllAsync started with TraceId: {TraceId}", traceId);
        try
        {
            var samples = await _sampleRepository.GetAllAsync();

            var result = samples.Select(x => new SampleDto
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return new CustomResponse<List<SampleDto>>
            {
                Status = true,
                Result = result,
                Count = result.Count,
                Message = "Samples fetched successfully"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching samples");
            return new CustomResponse<List<SampleDto>>
            {
                Status = false,
                Message = ex.InnerException?.Message ?? ex.Message
            };
        }
    }

    public async Task<CustomResponse<SampleDto>> GetByIdAsync(Guid id)
    {
        var traceId = Guid.NewGuid().ToString();
        _logger.LogInformation("GetByIdAsync started with TraceId: {TraceId}", traceId);
        try
        {
            var sample = await _sampleRepository.GetByIdAsync(id);
            if (sample == null)
                return new CustomResponse<SampleDto> { Status = false, Message = "Sample not found" };

            var result = new SampleDto
            {
                Name = sample.Name,
                Description = sample.Description
            };

            return new CustomResponse<SampleDto>
            {
                Status = true,
                Result = result,
                Message = "Sample fetched successfully"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching sample by id");
            return new CustomResponse<SampleDto>
            {
                Status = false,
                Message = ex.InnerException?.Message ?? ex.Message
            };
        }
    }

    public async Task<CustomResponse<string>> UpdateAsync(Guid id, SampleDto sampleDto)
    {
        var traceId = Guid.NewGuid().ToString();
        _logger.LogInformation("UpdateAsync started with TraceId: {TraceId}", traceId);
        try
        {
            var existing = await _sampleRepository.GetByIdAsync(id);
            if (existing == null)
                return new CustomResponse<string> { Status = false, Message = "Sample not found" };

            existing.Name = sampleDto.Name;
            existing.Description = sampleDto.Description;

            await _sampleRepository.UpdateAsync(existing);

            return new CustomResponse<string>
            {
                Status = true,
                Message = "Sample updated successfully"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating sample");
            return new CustomResponse<string>
            {
                Status = false,
                Message = ex.InnerException?.Message ?? ex.Message
            };
        }
    }
}
