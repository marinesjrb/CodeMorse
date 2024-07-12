﻿using CodeMorse.Handler;
using Microsoft.AspNetCore.Mvc;

namespace CodeMorse.Controllers;

[ApiController]
[Produces("application/json")]
[Route("v1/decodifications")]
public class DecodeController : ControllerBase
{
    private readonly IDecodeHandler _handler;

    public DecodeController(IDecodeHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    [Route("morseCodes")]
    public IActionResult Post(Request request)
    {
        var response = _handler.Handle(request.MorseCode);

        return Ok(response);
    }
}