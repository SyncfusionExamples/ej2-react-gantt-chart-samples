using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.OData.ModelBuilder;
using ODataV4Adaptor.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Build OData Model
var modelBuilder = new ODataConventionModelBuilder();
var gantt = modelBuilder.EntitySet<GanttDataAdaptor>("GanttTasks");
gantt.EntityType.HasKey(t => t.TaskID);

var batchHandler = new DefaultODataBatchHandler
{
    MessageQuotas =
    {
        MaxNestingDepth = 10,
        MaxOperationsPerChangeset = 100
    }
};

// Add services
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100)
    .AddRouteComponents("odata", modelBuilder.GetEdmModel(),batchHandler));

// Add CORS support (required for React app to call API)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseDefaultFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.UseODataBatching();

app.Run();
