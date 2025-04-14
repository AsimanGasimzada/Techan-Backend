using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using Techan.Business.Dtos.AuthDtos;
using Techan.Business.Exceptions;
using Techan.Business.ExternalServices.Abstractions;
using Techan.Business.Services.Abstractions;
using Techan.Core.Enums;
using Techan.DataAccess.Localizers;

namespace Techan.Business.Services.Implementations;
internal class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _rolaManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ErrorLocalizer _errorLocalizer;
    private readonly ITokenHelper _tokenHelper;
    private readonly IMapper _mapper;

    public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolaManager, SignInManager<AppUser> signInManager, ErrorLocalizer errorLocalizer, ITokenHelper tokenHelper, IMapper mapper)
    {
        _userManager = userManager;
        _rolaManager = rolaManager;
        _signInManager = signInManager;
        _errorLocalizer = errorLocalizer;
        _tokenHelper = tokenHelper;
        _mapper = mapper;
    }

    public async Task<ResultDto<AccessTokenDto>> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);

        if (user is null)
            user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);

        if (user is null)
            throw new LoginException(_errorLocalizer.GetValue(nameof(LoginException)));

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);

        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
                throw new LoginException(_errorLocalizer.GetValue("IsLocketOut"));

            throw new LoginException(_errorLocalizer.GetValue(nameof(LoginException)));
        }

        var claims = (await _userManager.GetClaimsAsync(user)).ToList();

        var token = _tokenHelper.CreateToken(claims);

        return new(token);
    }

    public async Task<ResultDto<AccessTokenDto>> RegisterAsync(RegisterDto dto)
    {
        var isExist = await _userManager.Users.AnyAsync(x => x.NormalizedEmail == dto.Username.ToUpper());

        if (isExist)
            throw new RegisterException(_errorLocalizer.GetValue("DuplicateEmail"));

        isExist = await _userManager.Users.AnyAsync(x => x.NormalizedUserName == dto.Username.ToUpper());

        if (isExist)
            throw new RegisterException(_errorLocalizer.GetValue("DuplicateUsername"));

        var appUser = _mapper.Map<AppUser>(dto);

        var result = await _userManager.CreateAsync(appUser, dto.Password);

        if (!result.Succeeded)
            throw new RegisterException(string.Join(",\n ", result.Errors));

        await _userManager.AddToRoleAsync(appUser, IdentityRoles.Admin.ToString());

        var claims = await GenerateUserClaimsAsync(appUser);

        var tokenDto = _tokenHelper.CreateToken(claims);

        return new(tokenDto);
    }
    private async Task<List<Claim>> GenerateUserClaimsAsync(AppUser user)
    {
        var oldClaims = await _userManager.GetClaimsAsync(user);
        await _userManager.RemoveClaimsAsync(user, oldClaims);

        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        var claims = new List<Claim>() {

            new Claim("Id",user.Id),
            new Claim("Username",user.UserName!),
            new Claim("Email",user.Email!),
            new Claim("PhoneNumber",user.PhoneNumber!),
            new Claim(ClaimTypes.Role, role?.ToString() ?? "")
        };

        await _userManager.AddClaimsAsync(user, claims);

        return claims;
    }
}
