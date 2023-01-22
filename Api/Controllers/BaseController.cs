using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected IStatusCodeActionResult GetStatus(int statusCode, string msg, object? rtnObj = null)
    {
        return statusCode switch
        {
            StatusCodes.Status200OK => Ok(new { msg, data = rtnObj }),
            StatusCodes.Status400BadRequest => BadRequest(new { msg }),
            StatusCodes.Status404NotFound => NotFound(new { msg }),
            _ => BadRequest()
        };
    }
}