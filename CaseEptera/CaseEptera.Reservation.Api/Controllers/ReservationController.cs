using CaseEptera.Reservation.Application.Features.Reservation.Commands;
using CaseEptera.Reservation.Application.Features.Reservation.Queries;
using CaseEptera.Reservation.Application.Features.RoomQuota.Commands;
using CaseEptera.Reservation.Application.Features.RoomType.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseEptera.Reservation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetReservation")]
        public async Task<IActionResult> GetReservation() => Ok(await _mediator.Send(new GetReservationQuery()));

        [HttpPost(Name = "CreateReservation")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost(Name = "UpdateRoomQuota")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateRoomQuota([FromBody] UpdateRoomQuotaCommand model)
        {
            return Ok(await _mediator.Send(model));
        }

        [HttpPost(Name = "GetRoomType")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoomType([FromBody] GetRoomTypeQuery model)
        {
            return Ok(await _mediator.Send(model));
        }
    }
}
