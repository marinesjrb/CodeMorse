using CodeMorse.Handler;
using CodeMorse.Model;
using Microsoft.AspNetCore.Mvc;

namespace CodeMorse.Controllers;

[ApiController]
[Produces("application/json")]
[Route("v1/decodes")]
public class DecodeController : ControllerBase
{
    private readonly IDecodeHandler _handler;

    public DecodeController(IDecodeHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    [Route("morsecode")]
    public IActionResult Post([FromBody]string request)
    {
        string response = _handler.HandleSingleCode(request);

        return Ok(response);
    }

    [HttpPost]
    [Route("morsecodes")]
    public IActionResult Post([FromBody] Request request)
    {
        Response response = _handler.HandleMultipleCodes(request);

        return Ok(response);
    }
}