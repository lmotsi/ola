using Microsoft.OpenApi.Models;
using OurLadyOfTheAssumption.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Our Lady of the Assumption API",
                                        Description = "Catholic Church API",
                                        Version = "v2"});
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5500") // website url
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseCors("AllowOrigin");

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Our Lady of the Assumption Catholic Church API");
    });
}

/* Church Details */
app.MapGet("/priest", () => ChurchDB.father);

/* Sacraments */
app.MapGet("/sacrament/{id}", (int id) => ChurchDB.getSacrament(id));
app.MapGet("/sacraments", () => ChurchDB.getSacraments());


app.Run();
