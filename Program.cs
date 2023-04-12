using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using restAPI.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(optionsAction: options =>
options.UseNpgsql(builder.Configuration.GetConnectionString(name: "ConnectionString"))
);

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
