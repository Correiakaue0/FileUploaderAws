using FileUploaderAws.Domain.Interfaces.Repositories;
using FileUploaderAws.Domain.Interfaces.Services;
using FileUploaderAws.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace FileUploaderAws.Domain.Services;

public class S3FileService(IS3FileRepository repository) : IS3FileService
{
    private readonly IS3FileRepository _repository = repository;

    public async Task<UploadedFile> UploadImageAsync(IFormFile file) => await _repository.UploadAsync(file);
    public async Task<UploadedFile> UploadArchiveAsync(IFormFile file) => await _repository.UploadAsync(file);
    public async Task<(Stream Stream, string ContentType, string FileName)> DownloadAsync(string key) => await _repository.DownloadAsync(key);
}