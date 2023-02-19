using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace weatherlogr.OperationFilters;

public sealed class ODataOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters is null) operation.Parameters = new List<OpenApiParameter>();

        var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

        if (descriptor is null) return;

        var queryAtt = descriptor.FilterDescriptors.Select(s => s.Filter).SingleOrDefault(w => w is EnableQueryAttribute) as EnableQueryAttribute;

        if (queryAtt is null) return;

        if (queryAtt.AllowedQueryOptions == AllowedQueryOptions.All)
        {
            AddSelect(operation);
            AddExpand(operation);
            AddFilter(operation);
            AddTop(operation);
            AddSkip(operation);
            AddOrderBy(operation);
            return;
        }

        if (queryAtt.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Select))
            AddSelect(operation);

        if (queryAtt.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Expand))
            AddExpand(operation);

        if (queryAtt.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Filter))
            AddFilter(operation);

        if (queryAtt.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Top))
            AddTop(operation);

        if (queryAtt.AllowedQueryOptions.HasFlag(AllowedQueryOptions.Skip))
            AddSkip(operation);

        if (queryAtt.AllowedQueryOptions.HasFlag(AllowedQueryOptions.OrderBy))
            AddOrderBy(operation);
    }

    private void AddSelect(OpenApiOperation operation)
    {
        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "$select",
            In = ParameterLocation.Query,
            Schema = new OpenApiSchema
            {
                Type = "string",
            },
            Description = "Returns only the selected properties. (ex. FirstName, LastName, City)",
            Required = false
        });
    }

    private void AddExpand(OpenApiOperation operation)
    {
        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "$expand",
            In = ParameterLocation.Query,
            Schema = new OpenApiSchema
            {
                Type = "string",
            },
            Description = "Include only the selected objects. (ex. Childrens, Locations)",
            Required = false
        });
    }

    private void AddFilter(OpenApiOperation operation)
    {
        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "$filter",
            In = ParameterLocation.Query,
            Schema = new OpenApiSchema
            {
                Type = "string",
            },
            Description = "Filter the response with OData filter queries.",
            Required = false
        });
    }

    private void AddTop(OpenApiOperation operation)
    {
        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "$top",
            In = ParameterLocation.Query,
            Schema = new OpenApiSchema
            {
                Type = "string",
            },
            Description = "Number of objects to return. (ex. 25)",
            Required = false
        });
    }

    private void AddSkip(OpenApiOperation operation)
    {
        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "$skip",
            In = ParameterLocation.Query,
            Schema = new OpenApiSchema
            {
                Type = "string",
            },
            Description = "Number of objects to skip in the current order (ex. 50)",
            Required = false
        });
    }

    private void AddOrderBy(OpenApiOperation operation)
    {
        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "$orderby",
            In = ParameterLocation.Query,
            Schema = new OpenApiSchema
            {
                Type = "string",
            },
            Description = "Define the order by one or more fields (ex. LastModified)",
            Required = false
        });
    }
}