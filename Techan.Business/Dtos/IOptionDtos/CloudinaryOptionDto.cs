﻿using Techan.Core.Abstractions;

namespace Techan.Business.Dtos;
public class CloudinaryOptionDto : IDto
{
    public string APIKey { get; set; } = null!;
    public string APISecret { get; set; } = null!;
    public string CloudName { get; set; } = null!;
}
