using Meroora_bejelento.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meroora_bejelento.DataAccess
{
    
    public class ApplicationDbContext : IdentityDbContext
    {

        // 25 nuget, using:entityframeworkcore ; using models 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Berlo> Berlok { get; set; }

        public DbSet<Felhasznalo> Felhasznalok { get; set; }
        public DbSet<Lakas> Lakasok { get; set; }
        public DbSet<MeroOra> MeroOrak { get; set; }
        public DbSet<MeroOraTipus> MeroOraTipusok { get; set; }
        public DbSet<Leolvasas> Leolvasasok { get; set; }
        public DbSet<Szerepkor> Szerepkorok { get; set; }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
