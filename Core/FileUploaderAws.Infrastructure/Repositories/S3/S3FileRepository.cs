using Amazon.S3;
using Amazon.S3.Transfer;
using FileUploaderAws.Domain.Interfaces.Repositories;
using FileUploaderAws.Domain.Models;
using FileUploaderAws.Infrastructure.AWS;
using Microsoft.AspNetCore.Http;

namespace FileUploaderAws.Infrastructure.Repositories;

public class S3FileRepository(AwsConnectionFactory connectionFactory) : IS3FileRepository
{
    private readonly AwsConnectionFactory _connectionFactory = connectionFactory;

    public async Task<UploadedFile> UploadAsync(IFormFile file)
    {
        var key = $"{Guid.NewGuid()}_{file.FileName}";
        using var stream = file.OpenReadStream();

        var transferUtility = new TransferUtility(_connectionFactory.GetClient());

        var transferUtilityUploadRequest = new TransferUtilityUploadRequest()
        {
            InputStream = stream,
            Key = key,
            BucketName = AwsConnectionConfiguration.BucketName,
            CannedACL = S3CannedACL.PublicRead
        };

        await transferUtility.UploadAsync(transferUtilityUploadRequest);

        var url = $"https://{AwsConnectionConfiguration.BucketName}.s3.amazonaws.com/{key}";
        return new UploadedFile(key, file.FileName, url);
    }

    public async Task<(Stream Stream, string ContentType, string FileName)> DownloadAsync(string key)
    {
        var s3Client = _connectionFactory.GetClient();

        var response = await s3Client.GetObjectAsync(AwsConnectionConfiguration.BucketName, key);

        var fileName = Path.GetFileName(key);
        var contentType = response.Headers.ContentType ?? "application/octet-stream";

        return (response.ResponseStream, contentType, fileName);
    }
}