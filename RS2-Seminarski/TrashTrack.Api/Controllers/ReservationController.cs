using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrashTrack.Api.Models.Reservation;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers;

public class ReservationController : BaseCrudController<ReservationDto, ReservationUpsertDto, ReservationSearchObject, IReservationService>
{
	private readonly IMapper _mapper;

	public ReservationController(IReservationService service, ILogger<BaseController> logger, IMapper mapper) : base(service, logger)
	{
		_mapper = mapper;
	}

	[Authorize]
	[HttpPut("PutReservationStatus")]
	public async Task<IActionResult> PutReservationStatus([FromBody] ReservationUpdateModel model, CancellationToken cancellationToken = default)
	{
		var reservationDto = _mapper.Map<ReservationUpsertDto>(model);
		var reservation = await Service.UpdateReservationStatusAsync(reservationDto, cancellationToken);

		return Ok(reservation);
	}

	[Authorize]
    [HttpPost("PayWithBalance")]
	public async Task<IActionResult> PayWithBalance([FromBody] ReservationUpsertDto dto, CancellationToken cancellationToken = default)
	{
		try
		{
			await Service.PayWithBalanceAsync(dto, cancellationToken);
			return Ok();
		}
		catch (Exception e)
		{
			Logger.LogError(e, "Error while processing the payment.");
			return BadRequest();
		}
	}

    [Authorize]
    [HttpGet("ReservationCount")]
    public async Task<IActionResult> GetReservationCountAsync(CancellationToken cancellationToken = default)
    {
        var count = await Service.GetReservationCountAsync(cancellationToken);

        return Ok(count);
    }
}
