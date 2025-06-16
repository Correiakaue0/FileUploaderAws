using FileUploaderAws.Domain.Entities;
using FileUploaderAws.Domain.Interfaces.Repositories;
using MinhaAppDDD.Infra.Data;

namespace FileUploaderAws.Infrastructure.Repositories;

public class FileStorageLogRepository(AppDbContext context) : IFileStorageLogRepository
{
    private readonly AppDbContext _context = context;

    public void Create(FileStorageLog fileStorageLog)
    {
        _context.FileStorageLogs.Add(fileStorageLog);
        _context.SaveChanges(); 
    }

    public List<FileStorageLog> GetAll() => _context.FileStorageLogs.ToList();
}