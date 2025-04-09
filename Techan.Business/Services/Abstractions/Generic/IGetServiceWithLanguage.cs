using Techan.Core.Abstractions;
using Techan.Core.Enums;

namespace Techan.Business.Services.Abstractions.Generic;

public interface IGetServiceWithLanguage<TGetDto>
    where TGetDto : IDto
{
    Task<TGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan);
    Task<List<TGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan);
}


