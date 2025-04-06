using PAW.Models.Approvals;

namespace PAW.Core.ApprovalProcess.Contract;

public interface IApprovalHandler<IHandler>
{
    IApprovalHandler<IHandler> SetNext(IApprovalHandler<IHandler> handler);
    Task<IApprovalHandler<IHandler>> HandleAsync(Ticket ticket);
}
