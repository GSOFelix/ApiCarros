using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Senai.Api.Common.Api;
using Senai.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.AddDataContext();
builder.Services.AddCors();
builder.AddDocumentation(); 
builder.AddService();
builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
app.MapControllers();

app.Run();
