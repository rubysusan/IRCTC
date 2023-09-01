using IRCTC.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IrctcContext>(option =>
{
    option.UseSqlServer(builder.Configuration["ConnectionString:SqlServer"],
        option => option.MigrationsAssembly("IRCTC.Repository"));

});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
        // .SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});
var app = builder.Build();
app.UseCors("AllowAngularOrigins");





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

