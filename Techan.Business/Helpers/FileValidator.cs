using Microsoft.AspNetCore.Http;

namespace Techan.Business.Helpers;
internal static class FileValidator
{
    public static bool CheckSize(this IFormFile file, int mb)
    {
        return file.Length < mb * 1024 * 1024;
    }

    public static bool CheckType(this IFormFile file, string type = "image")
    {
        return file.ContentType.Contains(type);
    }
}