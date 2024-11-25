using Microsoft.EntityFrameworkCore;
using RastreamentoWorkshopsWebApi.Models;

namespace RastreamentoWorkshopsWebApi.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Colaborador> Colaboradores { get; set; } = null!;
    public DbSet<Workshop> Workshops { get; set; } = null!;
    public DbSet<Ata> Atas { get; set; } = null!;    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {      
        modelBuilder.Entity<Colaborador>()
            .HasMany(c => c.Atas)
            .WithMany(a => a.Colaboradores)
            .UsingEntity(j => j.ToTable("ColaboradorAtas"));
            
        modelBuilder.Entity<Workshop>()
            .HasOne(w => w.Ata)
            .WithOne(a => a.Workshop)
            .HasForeignKey<Ata>(a => a.WorkshopId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

