using Auth.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Service.Infrastructure.Data.EF;

public class AuthContext(DbContextOptions<AuthContext> options) : DbContext(options), IAuthStore
{
    public DbSet<User> Users { get; set; }
    public async Task<User?> VerifyUserLogin(string username, string password) =>
        await Users.FirstOrDefaultAsync(u =>
        u.Username == username && u.Password == password);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfiguration(new UserConfiguration());
}