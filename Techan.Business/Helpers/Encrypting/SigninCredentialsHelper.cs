using Microsoft.IdentityModel.Tokens;

namespace Techan.Business.Helpers.Encrypting;
public static class SigninCredentialsHelper
{
    public static SigningCredentials CreateSigninCredentials(SecurityKey securityKey)
    {
        return new(securityKey, SecurityAlgorithms.HmacSha256);
    }
}