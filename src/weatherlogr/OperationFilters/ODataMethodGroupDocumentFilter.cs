using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace weatherlogr.OperationFilters
{
    public class ODataMethodGroupDocumentFilter : IDocumentFilter
    {
        private readonly string documentToFilter;
        public ODataMethodGroupDocumentFilter(string documentToFilter)
        {
            this.documentToFilter = documentToFilter;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (context.DocumentName != documentToFilter)
                return;
            foreach (string key in swaggerDoc.Paths.Select(p => p.Key).Where(p => p.Contains("odata")))
            {
                swaggerDoc.Paths.Remove(key);
            }

            foreach (string key in context.SchemaRepository.Schemas
                .Select(s => s.Key)
                .Where(k => k.StartsWith("Edm") || k.StartsWith("IEdm") || k.StartsWith("OData")))
            {
                context.SchemaRepository.Schemas.Remove(key);
            }
        }
    }
}