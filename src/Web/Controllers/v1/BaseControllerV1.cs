namespace DirectId_EOD.Api.Controllers.v1
{
    using Application.DTOs;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    [Route("/api/[controller]")]
    public class BaseController : ControllerBase
    {

    }
}