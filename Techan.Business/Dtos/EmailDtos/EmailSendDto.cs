using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Techan.Core.Abstractions;

namespace Techan.Business.Dtos;
public class EmailSendDto : IDto
{
    [Required]
    [EmailAddress]
    public string ToEmail { get; set; } = null!;

    [Required]
    public string Subject { get; set; } = null!;

    [Required]
    public string Body { get; set; } = null!;

    public List<IFormFile> Attachments { get; set; } = new();
}
