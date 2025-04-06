using Microsoft.AspNetCore.Mvc;
using PAW.Core.ApprovalProcess;
using PAW.Models.Approvals;
using PAW.Repository.Approvals;

namespace PAW.API.Controllers.Approvals;

[ApiController]
[Route("[controller]")]
public class TicketController(ITicketRepository ticketRepository, ITicketApprovalProcess process) : Controller
{
    [HttpGet(Name = "GetTickets")]
    public async Task<IEnumerable<Ticket>> Get([FromQuery] IEnumerable<int> ids, [FromQuery] string? status)
    {
        return await ticketRepository.GetAsync(ids, status: status);
    }

    [HttpPost(Name = "ExecuteTicket")]
    public async Task<string> Execute([FromBody] int id)
    {
        await process.ProcessAsync(id);
        return "Success!";
    }

}
