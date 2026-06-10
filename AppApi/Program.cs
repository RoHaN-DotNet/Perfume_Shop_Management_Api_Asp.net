using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<DataAccessFactory>();
//Services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<PerfumeService>();

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderItemService>();

//Repos
builder.Services.AddScoped<PerfumeRepo>();
builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<CustomerRepo>();
builder.Services.AddScoped<OrderRepo>();
builder.Services.AddScoped<OrderItemRepo>();
//
builder.Services.AddDbContext<PSMS>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
