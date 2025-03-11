using Auth.Service.Endpoints;
using Auth.Service.Infrastructure.Data.EF;
using Auth.Service.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServerDatastore(builder.Configuration);
builder.Services.RegisterTokenService(builder.Configuration);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MigrateDatabase();
}
app.RegisterEndpoints();



app.Run();