using FileUploaderAws.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MinhaAppDDD.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<FileStorageLog> FileStorageLogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
