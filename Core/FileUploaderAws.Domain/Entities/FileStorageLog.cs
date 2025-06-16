using FileUploaderAws.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FileUploaderAws.Domain.Entities;

public class FileStorageLog(long id, DateTime dateTimeCreation, string bucketName, string objectKey, EnumOperation operation, EnumStatusOperation statusOperation) : BaseEntity(id)
{
    [Required]
    public DateTime DateTimeCreation { get; private set; } = dateTimeCreation;
    [Required]
    public string BucketName { get; private set; } = bucketName;
    [Required]
    public string ObjectKey { get; private set; } = objectKey;
    [Required]
    public EnumOperation Operation { get; private set; } = operation;
    [Required]
    public EnumStatusOperation StatusOperation { get; private set; } = statusOperation;
}