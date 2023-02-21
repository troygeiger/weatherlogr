using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using weatherlogr.CustomAttributes;

namespace weatherlogr.Helpers
{
    public static class AutoEdmBuilder
    {

        public static IEdmModel BuildEdmModels()
        {
            var modelBuilder = new ODataConventionModelBuilder();

            var controllerQuery = typeof(AutoEdmBuilder).Assembly
                .GetTypes()
                .SelectMany(t => t.GetCustomAttributes<ODataEdmDefinitionAttribute>());


            foreach (ODataEdmDefinitionAttribute attr in controllerQuery)
            {
                modelBuilder.AddEntityType(attr.EntityType);
                if (!string.IsNullOrEmpty(attr.EntitySetName))
                    modelBuilder.AddEntitySet(attr.EntitySetName, new(modelBuilder, attr.EntityType));
            }

            return modelBuilder.GetEdmModel();
        }

    }
}