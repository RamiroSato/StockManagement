using Microsoft.EntityFrameworkCore;
using StockManagement.Data.Contexts;
using StockManagement.Interfaces;
using StockManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<StockManagementContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("StockManagement"),
        b => b.MigrationsAssembly("StockManagement.Data")
    )
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
