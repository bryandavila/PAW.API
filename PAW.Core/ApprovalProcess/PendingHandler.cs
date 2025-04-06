using PAW.Core.ApprovalProcess.Contract;
using PAW.Core.ApprovalProcess.Helpers;
using PAW.Models.Approvals;
using PAW.Repository.Approvals;

namespace PAW.Core.ApprovalProcess;

public class PendingHandler(ITicketRepository ticketRepository) : HandlerBase(ticketRepository)
{
    public override async Task<IApprovalHandler<HandlerBase>> HandleAsync(Ticket ticket)
    {
        ticket.Status = ProcessConstants.IN_PROGRESS;
        return await base.HandleAsync(ticket);
    }
}
