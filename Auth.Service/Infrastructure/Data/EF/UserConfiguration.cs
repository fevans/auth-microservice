using Auth.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Service.Infrastructure.Data.EF;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired();

        builder.Property(u => u.Password)
            .IsRequired();

        builder.Property(u => u.Role).IsRequired();

        builder.HasData(
            new User
            {
                Id = new Guid("11DFB4DD-2D9A-48F2-934B-CEE300FBC012"),
                Username = "microservices@code-maze.com",
                Password = "oKNrqkO7iC#G",
                Role = "Administrator",
            },
            new User
            {
                Id = new Guid("19CE3AAD-1211-4062-B777-47B9B3DEBA92"),
                Username = "francis@simplyTuition.com",
                Password = "pKNrqkO7iC#G",
                Role = "Student",
            });
    }
}