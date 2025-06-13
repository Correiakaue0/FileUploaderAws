using Amazon.S3;
using FileUploaderAws.Domain.Models;

namespace FileUploaderAws.Infrastructure.AWS;

public class AwsConnectionFactory
{
    private readonly IAmazonS3 _s3Client;

    public AwsConnectionFactory() => _s3Client = new AmazonS3Client(AwsConnectionConfiguration.AccessKey, AwsConnectionConfiguration.SecretKey, Amazon.RegionEndpoint.GetBySystemName(AwsConnectionConfiguration.Region));

    public IAmazonS3 GetClient() => _s3Client;
}