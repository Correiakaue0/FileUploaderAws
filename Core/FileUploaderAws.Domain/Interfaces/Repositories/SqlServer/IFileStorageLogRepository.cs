using FileUploaderAws.Domain.Entities;

namespace FileUploaderAws.Domain.Interfaces.Repositories;

public interface IFileStorageLogRepository
{
    void Create(FileStorageLog fileStorageLog);
    List<FileStorageLog> GetAll();
}