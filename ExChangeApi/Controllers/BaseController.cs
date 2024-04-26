using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

[Route("api/{version:apiVersion}/[controller]/[action]")]
[ApiVersion("1.0")]
[ApiController]
public class BaseController : Controller
{

}
