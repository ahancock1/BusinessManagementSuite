using System.Collections.Generic;

using Restaurant.DataModels;

namespace Restaurant.DataAccess.Services
{
    public interface ITicketService : IGenericService<Ticket>
    {
        IList<Ticket> GetByMember(Member member);
    }

    public class TicketService : GenericService<Ticket>, ITicketService
    {
        public IList<Ticket> GetByMember(Member member)
        {
            return GetAll(t => t.Member.MemberID == member.MemberID);
        }

        public IList<Ticket> GetByTable(Table table)
        {
            return GetAll(t => t.Table.TableID == table.TableID);
        } 
    }
}