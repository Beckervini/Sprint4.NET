using Microsoft.EntityFrameworkCore;
using Sprint1_2semestre.Models;

namespace Sprint1_2semestre.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<KPI> KPIs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KPI>()
                .HasOne(k => k.Empresa)
                .WithMany(e => e.KPIs)
                .HasForeignKey(k => k.EmpresaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
