using Techan.Core.Abstractions;
using Techan.Core.Enums;

namespace Techan.Business.Services.Abstractions.Generic;

public interface IGetServiceWithLanguage<TGetDto>
    where TGetDto : IDto
{
    Task<ResultDto<TGetDto>> GetAsync(int id, Languages language = Languages.Azerbaijan);
    Task<ResultDto<List<TGetDto>>> GetAllAsync(Languages language = Languages.Azerbaijan);
}


