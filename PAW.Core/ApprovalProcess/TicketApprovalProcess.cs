using PAW.Repository.Approvals;

namespace PAW.Core.ApprovalProcess;

public interface ITicketApprovalProcess
{
    Task ProcessAsync(int ticketId);
}

public class TicketApprovalProcess(ITicketRepository ticketRepository) : ITicketApprovalProcess
{
    public async Task ProcessAsync(int ticketId)
    {
        var tickets = await ticketRepository.GetAsync([ticketId], status: string.Empty);
        if (tickets == null) return;

        var ticket = tickets.FirstOrDefault();
        /*handler = (ticket.Status) switch
        {
            ProcessConstants.OPENED => new PendingApprovalHandler(ticketRepository),
            ProcessConstants.PENDING => new InProgressApprovalHandler(ticketRepository),
            ProcessConstants.IN_PROGRESS => new ArchivedApprovalHandler(ticketRepository),
            _ => throw new InvalidOperationException()
        };*/

        var pending = new PendingHandler(ticketRepository);
        var progress = new InProgressHandler(ticketRepository);
        var archived = new ArchivedHandler(ticketRepository);

        pending.SetNext(progress);
        progress.SetNext(archived);

        await pending.HandleAsync(ticket);
    }
}
