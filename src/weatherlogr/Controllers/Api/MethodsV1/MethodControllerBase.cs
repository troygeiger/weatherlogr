using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace weatherlogr.Controllers.Api.MethodsV1
{
    [ApiController]
    [Route("[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "methods_v1")]
    [Produces("application/json")]
    public abstract class MethodControllerBase : ControllerBase
    {
        
    }
}