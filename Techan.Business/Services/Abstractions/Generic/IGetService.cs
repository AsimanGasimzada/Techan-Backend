using Techan.Core.Abstractions;

namespace Techan.Business.Services.Abstractions.Generic;

public interface IGetService<TGetDto>
    where TGetDto : IDto
{
    Task<TGetDto> GetAsync(int id);
    Task<List<TGetDto>> GetAllAsync();
}


