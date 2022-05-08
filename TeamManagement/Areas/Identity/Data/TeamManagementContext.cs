using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamManagement.Areas.Identity.Data;
using TeamManagement.Models;

namespace TeamManagement.Data;

public class TeamManagementContext : IdentityDbContext<TeamManagementUser>
{
    public TeamManagementContext(DbContextOptions<TeamManagementContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<TeamManagement.Models.Team> Team { get; set; }

    public DbSet<TeamManagement.Models.Member> Member { get; set; }
    public DbSet<TeamManagement.Models.Role> Role { get; set; }

    public DbSet<TeamManagement.Models.NewMembers> NewMembers { get; set; }

}
