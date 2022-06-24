using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SteamAPI.Models;

namespace SteamAPI.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<SteamAPI.Models.Token>? Tokens { get; set; }
    public DbSet<SteamAPI.Models.Group>? Group { get; set; }
    public DbSet<SteamAPI.Models.UserInGroup>? UserInGroup { get; set; }
}