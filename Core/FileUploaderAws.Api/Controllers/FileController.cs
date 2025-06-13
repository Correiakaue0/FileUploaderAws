using FileUploaderAws.Domain.Interfaces.Services;
using FileUploaderAws.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileUploaderAws.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController(IS3FileService sservice) : ControllerBase
{
    private readonly IS3FileService _service = sservice;

    [HttpPost("uploadImage")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Imagem inválida.");

        var uploaded = await _service.UploadImageAsync(file);
        return Ok(uploaded);
    }

    [HttpPost("uploadArchive")]
    public async Task<IActionResult> UploadArchive([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Arquivo inválido.");

        var uploaded = await _service.UploadArchiveAsync(file);
        return Ok(uploaded);
    }

    [HttpGet("GetImage/{key}")]
    public string GetImageUrl(string key)
    {
        return $"https://{AwsConnectionConfiguration.BucketName}.s3.amazonaws.com/{key}";
    }

    [HttpGet("DownloadArchive/{key}")]
    public async Task<IActionResult> DownloadArchive(string key)
    {
        var (stream, contentType, fileName) = await _service.DownloadAsync(key);

        return File(stream, contentType, fileName);
    }
}