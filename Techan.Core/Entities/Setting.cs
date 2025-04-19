using Techan.Core.Entities.Common;

namespace Techan.Core.Entities;
public class Setting : BaseEntity
{
    public string Key { get; set; } = null!;
    public ICollection<SettingDetail> SettingDetails { get; set; } = [];
}
