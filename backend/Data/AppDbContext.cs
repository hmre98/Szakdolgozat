using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace backend.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    builder.Entity<Appointment>()
        .HasOne(a => a.User)
        .WithMany() // or .WithMany(u => u.Appointments) if you add a collection
        .HasForeignKey(a => a.UserId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
}


    public DbSet<Appointment> Appointments { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<ServiceBooked> ServicesBooked { get; set; } = null!;
    public DbSet<ServiceProvided> ServicesProvided { get; set; } = null!;   
}
