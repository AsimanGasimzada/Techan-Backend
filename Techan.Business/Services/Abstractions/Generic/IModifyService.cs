using Techan.Core.Abstractions;

namespace Techan.Business.Services.Abstractions.Generic;

public interface IModifyService<TCreateDto, TUpdateDto>
    where TCreateDto : IDto
    where TUpdateDto : IDto
{
    Task<ResultDto> CreateAsync(TCreateDto dto);
    Task<ResultDto> UpdateAsync(TUpdateDto dto);
    Task<ResultDto<TUpdateDto>> GetUpdatedDtoAsync(int id);
    Task<ResultDto> DeleteAsync(int id);
}


