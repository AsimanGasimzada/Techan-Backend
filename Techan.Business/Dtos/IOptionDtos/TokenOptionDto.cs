namespace Techan.Business.Dtos;

public class TokenOptionDto : IDto
{
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string SecurityKey { get; set; } = null!;
    public int TokenExpiration { get; set; }
}

