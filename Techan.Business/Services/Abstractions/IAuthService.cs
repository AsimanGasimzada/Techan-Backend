using Techan.Business.Dtos.AuthDtos;

namespace Techan.Business.Services.Abstractions;
public interface IAuthService
{
    Task<ResultDto<AccessTokenDto>> RegisterAsync(RegisterDto dto);
    Task<ResultDto<AccessTokenDto>> LoginAsync(LoginDto dto);
}
