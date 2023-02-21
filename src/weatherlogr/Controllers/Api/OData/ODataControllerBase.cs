using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace weatherlogr.Controllers.Api.OData
{
    [ApiExplorerSettings(GroupName = "odata")]
    public abstract class ODataControllerBase : ODataController
    {
        
    }
}