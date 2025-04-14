using System.Security.Claims;

namespace Techan.Business.ExternalServices.Abstractions;
internal interface ITokenHelper
{
    AccessTokenDto CreateToken(List<Claim> claims);
}
