using Microsoft.EntityFrameworkCore;
using Movies.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MoviesAPIContext>(options =>    
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) // options.UseInMemoryDatabase("DbNameAny")
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// app.AddSeedData();

app.Run();
