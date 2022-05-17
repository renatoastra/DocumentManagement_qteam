using DocumentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManegemant.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DocumentModel> Document { get; set; }
        public DbSet<Process> Process { get; set; }
    }
}
