using System.Collections.Generic;

using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IOrderService : IGenericService<Order>
    {
        IList<Order> GetByMember(Member member);
    }

    public class OrderService : GenericService<Order>, IOrderService
    {
        public IList<Order> GetByMember(Member member)
        {
            return GetAll(o => o.Member.MemberID == member.MemberID);
        }

        public IList<Order> GetByTable(Table table)
        {
            return GetAll(o => o.Table.TableID == table.TableID);
        } 
    }
}