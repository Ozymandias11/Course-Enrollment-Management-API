using Course_Enrollment_Management_APi.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;
using MediatR;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints()
                .SwaggerDocument();
builder.Services.ConfigureReposiotryManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddMediatR(typeof(Application.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddFastEndpoints();


var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseFastEndpoints().UseSwaggerGen();


app.Run();

