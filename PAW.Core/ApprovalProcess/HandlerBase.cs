using PAW.Core.ApprovalProcess.Contract;
using PAW.Models.Approvals;
using PAW.Repository.Approvals;

namespace PAW.Core.ApprovalProcess;

public abstract class HandlerBase(ITicketRepository ticketRepository) : IApprovalHandler<HandlerBase>
{
    protected IApprovalHandler<HandlerBase> _handler;

    public virtual async Task<IApprovalHandler<HandlerBase>> HandleAsync(Ticket ticket)
    {
        await ticketRepository.SaveAsync(ticket);
        return await _handler.HandleAsync(ticket);
    }

    public IApprovalHandler<HandlerBase> SetNext(IApprovalHandler<HandlerBase> handler)
    {
        _handler = handler;
        return _handler;
    }
}