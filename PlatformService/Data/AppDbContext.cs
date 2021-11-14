using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    /// <summary>
    /// Contesto del db
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Costruttore di default, con la dependency injection riceve il db su cui si connette
        /// variando allo startup l'opzione del db può essere in memory o sqlserver
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}