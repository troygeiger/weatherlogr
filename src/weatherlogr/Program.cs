using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using weatherlogr.Core;
using weatherlogr.Core.DTO;
using weatherlogr.OperationFilters;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<StationLookupRow>();
modelBuilder.EntitySet<StationLookupRow>("ObservationStations");

builder.Services.AddODataQueryFilter();

// Add services to the container.
var mvc = builder.Services.AddControllersWithViews()
    .AddOData(options => options.Select().Filter().OrderBy().Count().SetMaxTop(null).AddRouteComponents(
        "odata", modelBuilder.GetEdmModel()));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.OperationFilter<ODataOperationFilter>();

    setup.SwaggerDoc("odata", new()
    {
        Title = "OData Methods",
        Version = "v1"
    });
    setup.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "WeatherLogR Version 1",
        Version = "v1"
    });
});




var configOptions = builder.Configuration.GetSection("ConfigOptions").Get<ConfigurationOptions>();

if (configOptions is null)
    throw new ArgumentNullException("ConfigOptions was not found in Configurations!");

builder.Services.AddWeatherLogR(configOptions);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(setup =>
{
    setup.RoutePrefix = "swagger";
    setup.InjectJavascript("/js/custom-swagger.js");
    setup.SwaggerEndpoint("odata/swagger.json", "OData");
    setup.SwaggerEndpoint("v1/swagger.json", "Methods");

});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
