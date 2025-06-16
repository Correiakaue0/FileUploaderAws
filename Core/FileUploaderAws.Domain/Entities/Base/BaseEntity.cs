using System.ComponentModel.DataAnnotations;

namespace FileUploaderAws.Domain.Entities;

public class BaseEntity(long id)
{
    [Key]
    public long Id { get; private set; } = id;
}