using ApiRest;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlatecBackend.Application.Actions.BlogPost.Queries;
using PlatecBackend.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(o => o.UseInMemoryDatabase("MyDatabase"));
builder.Services.AddMediatR(typeof(GetAll.QueryGetAllBlogPostsHandler).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
DataInfo.SeedData(app);
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
