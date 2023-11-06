using Microsoft.EntityFrameworkCore;
using TaskTwo_notes_.Models;

namespace TaskTwo_notes_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<NoteModel> Notes { get; set; }
    }
}
