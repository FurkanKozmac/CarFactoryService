using CarFactory.Application.Commands.MoveVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{vin}/move-next")]
    public async Task<IActionResult> MoveNext(string vin, [FromBody] string operatorId)
    {
        var command = new MoveVehicleCommand(vin, operatorId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}