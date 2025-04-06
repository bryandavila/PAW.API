using PAW.Core.ApprovalProcess.Contract;
using PAW.Core.ApprovalProcess.Helpers;
using PAW.Models.Approvals;
using PAW.Repository.Approvals;

namespace PAW.Core.ApprovalProcess;

public class InProgressHandler(ITicketRepository ticketRepository) : HandlerBase(ticketRepository)
{
    public override async Task<IApprovalHandler<HandlerBase>> HandleAsync(Ticket ticket)
    {
        ticket.Status = ProcessConstants.ARCHIVED;
        return await base.HandleAsync(ticket);
    }
}