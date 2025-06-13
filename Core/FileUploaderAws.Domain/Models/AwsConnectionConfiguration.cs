namespace FileUploaderAws.Domain.Models;

public class AwsConnectionConfiguration
{
    public static string? AccessKey { get; private set; } = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
    public static string? SecretKey { get; private set; } = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");
    public static string? Region { get; private set; } = Environment.GetEnvironmentVariable("AWS_REGION");
    public static string? BucketName { get; private set; } = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME");

    public AwsConnectionConfiguration()
    {
        if (string.IsNullOrEmpty(AccessKey) || string.IsNullOrEmpty(SecretKey) || string.IsNullOrEmpty(Region) || string.IsNullOrEmpty(BucketName))
            throw new Exception("As variáveis de ambiente AWS não estão definidas corretamente.");
    }
}