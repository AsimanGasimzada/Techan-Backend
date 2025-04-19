using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;

public class SettingDetail : BaseEntity
{
    public int SettingId { get; set; }
    public Setting? Setting { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
    public string Value { get; set; } = null!;
}
