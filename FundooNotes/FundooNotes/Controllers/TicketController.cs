using BussinessLayer.Interfaces;
using CommonLayer.Models;
using Experimental.System.Messaging;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUserBussines userBussines;

        private readonly IBus bus;
        public TicketController(IUserBussines userBussines, IBus bus)
        {
            this.userBussines = userBussines;
            this.bus = bus;
        }
        [HttpPost("Forgot password")]

        public async Task<IActionResult> createTicket(string Email)
        {
            if (Email != null)
            {
                var token = userBussines.ForgetPassword(Email);

                if (!string.IsNullOrEmpty(token))
                {
                    var ticketResonse = userBussines.CreateTick(Email, token);
                    Uri uri = new Uri("rabbitmq://localhoost/tickerQueue");
                    var endpoint=await bus.GetSendEndpoint(uri);
                    await endpoint.Send(ticketResonse);
                    return Ok(new { success = true, message = "Email sent Successfully" });

                }
                else
                {
                    return BadRequest(new { success = false, message = "Email Id is Not Registered" });
                }

                
            }
            else
            {
                return BadRequest(new { success = false, message = "Somthing went wrong" });
            }



        }
    }
}
