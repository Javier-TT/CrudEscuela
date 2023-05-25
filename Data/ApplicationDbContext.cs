using CrudEscuela.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CrudEscuela.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Grado> grados { get; set; }
    }
}
