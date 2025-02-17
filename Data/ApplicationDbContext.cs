using System.Net.Mime;
using Egovernance.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Egovernance.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<LicenseProfile> LicenseProfiles { get; set; }
    
    public DbSet<Vehicle> Vehicles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One-to-One relationship between ApplicationUser and LicenseProfile
        modelBuilder.Entity<ApplicationUser>()
            .HasOne(a => a.LicenseProfile)
            .WithOne(lp => lp.User)
            .HasForeignKey<LicenseProfile>(lp => lp.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}