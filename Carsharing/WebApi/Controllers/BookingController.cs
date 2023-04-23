using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using static Application.Bookings.CreateBooking;
using static Application.Bookings.DeleteBooking;
using static Application.Bookings.GetBooking;
using static Application.Bookings.GetBookings;
using static Application.Bookings.UpdateBooking;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BookingController : BaseController
    {
        private readonly IMapper _mapper;

        public BookingController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<BookingsVm>> GetAll(GetBookingsQuery query)
        {
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingVm>> Get(Guid id)
        {
            var query = new GetBookingQuery
            {
                BookingId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookingCommandDto commandDto)
        {
            var command = _mapper.Map<CreateBookingCommand>(commandDto);
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBookingCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookingCommandDto commandDto)
        {
            var command = _mapper.Map<UpdateBookingCommand>(commandDto);
            var rm = await Mediator.Send(command);
            return NoContent();
        }
    }
}
