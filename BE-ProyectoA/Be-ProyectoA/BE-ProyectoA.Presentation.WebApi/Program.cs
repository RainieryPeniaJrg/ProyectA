using BE_ProyectoA.Core.Application;
using BE_ProyectoA.Infraestructure.Persistence;
using BE_ProyectoA.Presentation.WebApi;
using BE_ProyectoA.Presentation.WebApi.Extensions;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPresentationn().AddInfraEstructure(builder.Configuration).AddApplication();

var app = builder.Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}
app.UseCors("DefaultPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
