using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Our Lady of the Assumption API",
                                        Description = "Catholic Church API",
                                        Version = "v2"});
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Our Lady of the Assumption Catholic Church API");
    });
}

app.MapGet("/priest", () => "Fr. Sicelo Libanje OMI");

//app.MapGet("/priest", () => data);

app.Run();
