using PAW.Models.Approvals;

namespace PAW.Repository.Approvals
{
    public interface ITicketRepository
    {
        Task<bool> SaveAsync(Ticket entity);
        Task<IEnumerable<Ticket>> GetAsync(IEnumerable<int> ids, string status);

    }
    public class TicketRepository : ApprovalsRepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository() { }

        public async Task<bool> SaveAsync(Ticket entity)
        {
            bool exists = await ExistsAsync(entity);
            if (exists)
                return await UpdateAsync(entity);
            return await CreateAsync(entity);
        }

        public async Task<IEnumerable<Ticket>> GetAsync(IEnumerable<int> ids, string status)
        {
            if (ids == null) return [];

            if (ids.Count() == 1)
                return [await FindAsync(ids.FirstOrDefault())];

            var tickets = await ReadAsync();
            Func<Ticket, bool> predicate = string.IsNullOrEmpty(status)
                ? x => ids.Contains(x.TicketId)
                : x => ids.Contains(x.TicketId) && x.Status == status;

            return tickets.Where(predicate);
        }
    }
}
