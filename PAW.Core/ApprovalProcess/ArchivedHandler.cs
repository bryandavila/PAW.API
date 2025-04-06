using PAW.Core.ApprovalProcess.Contract;
using PAW.Models.Approvals;
using PAW.Repository.Approvals;

namespace PAW.Core.ApprovalProcess;

public class ArchivedHandler(ITicketRepository ticketRepository) : HandlerBase(ticketRepository)
{
    public override async Task<IApprovalHandler<HandlerBase>> HandleAsync(Ticket ticket)
    {
        return this;// await base.HandleAsync(ticket);
    }
}
