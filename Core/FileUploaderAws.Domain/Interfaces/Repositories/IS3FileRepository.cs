using FileUploaderAws.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace FileUploaderAws.Domain.Interfaces.Repositories;

public interface IS3FileRepository
{
    Task<UploadedFile> UploadAsync(IFormFile file);
    Task<(Stream Stream, string ContentType, string FileName)> DownloadAsync(string key);
}