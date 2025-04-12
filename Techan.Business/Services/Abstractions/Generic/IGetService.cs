using Techan.Core.Abstractions;

namespace Techan.Business.Services.Abstractions.Generic;

public interface IGetService<TGetDto>
    where TGetDto : IDto
{
    Task<ResultDto<TGetDto>> GetAsync(int id);
    Task<ResultDto<List<TGetDto>>> GetAllAsync();
}


