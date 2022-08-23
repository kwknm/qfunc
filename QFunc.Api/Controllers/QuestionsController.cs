using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QFunc.Api.Controllers;

[Route("api/questions")]
public class QuestionsController : ApiController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(User.Identity?.IsAuthenticated);
    }
}