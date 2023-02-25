using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using weatherlogr.Core;
using weatherlogr.Core.DTO;
using weatherlogr.Helpers;
using weatherlogr.OperationFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddODataQueryFilter();

// Add services to the container.
var mvc = builder.Services.AddControllersWithViews()
    .AddOData(options =>
    {
        options.Select().Filter().OrderBy().Count().SetMaxTop(null).AddRouteComponents(
        "odata", AutoEdmBuilder.BuildEdmModels());
        options.UrlKeyDelimiter = Microsoft.OData.ODataUrlKeyDelimiter.Parentheses;
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.ResolveConflictingActions(resolve =>
    {
        return resolve.First();
    });
    setup.OperationFilter<ODataOperationFilter>();
    setup.DocumentFilter<ODataMethodGroupDocumentFilter>("methods_v1");

    setup.SwaggerDoc("odata", new()
    {
        Title = "OData Methods",
        Version = "v1"
    });
    setup.SwaggerDoc("methods_v1", new OpenApiInfo()
    {
        Title = "Generic Methods",
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
    setup.SwaggerEndpoint("methods_v1/swagger.json", "Generic Methods");

});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
