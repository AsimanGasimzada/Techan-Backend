using Techan.Core.Abstractions;

namespace Techan.Business.Services.Abstractions.Generic;

public interface IModifyService<TCreateDto, TUpdateDto>
    where TCreateDto : IDto
    where TUpdateDto : IDto
{
    Task<bool> CreateAsync(TCreateDto dto);
    Task<bool> UpdateAsync(TUpdateDto dto);
    Task<TUpdateDto> GetUpdatedDtoAsync(int id);
    Task DeleteAsync(int id);
}


