using Library.Application.Services;
using Library.Application.Services.Interfaces;
using Library.Domain.Repositories;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IReaderService, ReaderService>();
builder.Services.AddScoped<IReaderRepository, ReaderRepository>();

builder.Services.AddScoped<IBorrowedService, BorrowedService>();
builder.Services.AddScoped<IBorrowedRepository, BorrowedRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("LibraryCS"));
        option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
