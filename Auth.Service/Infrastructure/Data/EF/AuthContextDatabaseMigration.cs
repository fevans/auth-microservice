using Microsoft.EntityFrameworkCore;

namespace Auth.Service.Infrastructure.Data.EF;

public static class AuthContextDatabaseMigration
{
    public static void MigrateDatabase(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        using var authContext = scope.ServiceProvider.GetRequiredService<AuthContext>();
        authContext.Database.Migrate();
    }
}