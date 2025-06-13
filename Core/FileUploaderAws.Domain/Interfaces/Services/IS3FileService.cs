using FileUploaderAws.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace FileUploaderAws.Domain.Interfaces.Services;

public interface IS3FileService
{
    Task<UploadedFile> UploadImageAsync(IFormFile file);
    Task<UploadedFile> UploadArchiveAsync(IFormFile file);
    Task<(Stream Stream, string ContentType, string FileName)> DownloadAsync(string key);
}