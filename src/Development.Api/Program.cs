using Library.Application.Services;
using Library.Application.Services.Interfaces;
using Library.Domain.Repositories;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBorrowedService, BorrowedService>();
builder.Services.AddTransient<IReaderService, ReaderService>();
builder.Services.AddTransient<IDataValidatorService, DataValidatorService>();

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IReaderRepository, ReaderRepository>();
builder.Services.AddTransient<IBorrowedRepository, BorrowedRepository>();

builder.Services.AddDbContext<LibraryContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

//using var scope = app.Services.CreateScope();
//var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
//db.Database.Migrate();

app.Run();
