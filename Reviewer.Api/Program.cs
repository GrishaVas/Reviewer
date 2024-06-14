using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Reviewer.Api.Configurations;
using Reviewer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ReviewerDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"));
});
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Reviewer API",
    });
});
builder.Services.AddServicesConfiguration();
builder.Services.AddInfrastructureConfiguration();

var app = builder.Build();

await MigrateDatabase(app);

app.UseSwagger();
app.UseSwaggerUI(opts =>
{
    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    opts.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task MigrateDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    await using var dbContext = scope.ServiceProvider.GetRequiredService<ReviewerDbContext>();

    await dbContext.Database.MigrateAsync();
}
