using Application.Features;
using Domain.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ParkingTicketsController : BController
    {
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateParkingTicket([FromBody]CreateParkingTicketDTO createParkingTicketDTO)
        {
            // create parking ticket
            var result = await Mediator.Send(new CreateParkingTicketService()
            {
                CreateParkingTicketDTO = createParkingTicketDTO
            });

            // return result
            if(result.Succeeded == true)
            {
                return StatusCode(
                    StatusCodes.Status200OK,
                    result.Data);
            }
            else
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    result.Message);
            }
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCreateParkingTicketInitData()
        {
            // get data
            var result = await Mediator.Send(new GetCreateParkingTicketInitDataService());

            // return result
            if(result.Succeeded)
            {
                return StatusCode(
                    StatusCodes.Status200OK,
                    result.Data);
            }
            else
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    result.Message);
            }
        }
    }
}
