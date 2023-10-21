using Application.Features;
using Application.Features.ParkingTickets;
using Domain.Common.DTOs.ParkingTicketDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ParkingTicketsController : BController
    {
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateParkingTicketResultDTO>> CreateParkingTicket([FromBody]CreateParkingTicketDTO createParkingTicketDTO)
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
        public async Task<ActionResult<CreateParkingTicketInitDataDTO>> GetCreateParkingTicketInitData()
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

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<IndexParkingTicketDTO>>> GetUserParkingTickets([FromQuery]string deviceId)
        {
            // get data
            var result = await Mediator.Send(new GetUserParkingTicketsService()
            {
                DeviceId = deviceId
            });

            // return result
            if (result.Succeeded)
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
