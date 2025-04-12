using Microsoft.Extensions.Localization;

namespace Techan.DataAccess.Localizers;
public class ErrorLocalizer
{
    private readonly IStringLocalizer _localizer;

    public ErrorLocalizer(IStringLocalizerFactory factory)
    {
        _localizer = factory.Create("Errors", "Techan.Presentation");
    }
    public string GetValue(string key)
    {
        return _localizer.GetString(key);
    }
}
