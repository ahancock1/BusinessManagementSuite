using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.ServiceModel;
using Restaurant.Data.Management;
using Restaurant.Data.Management.Floor;

namespace Restaurant.DataAccess.Services
{
    [ServiceContract]
    public interface IReservationService : IGenericService
    {
        [OperationContract]
        IList<Reservation> GetByMember(Member member);

        [OperationContract]
        IList<Reservation> GetByDate(DateTime date);

        [OperationContract]
        IList<Reservation> GetByTable(Table id);
    }

    public class ReservationService : GenericService, IReservationService
    {
        public IList<Reservation> GetByMember(Member member)
        {
            return All<Reservation>(r => r.Member.MemberID == member.MemberID).ToList();
        }

        public IList<Reservation> GetByDate(DateTime date)
        {
            return All<Reservation>(r => r.Arrive.Date.Equals(date.Date));
        }

        public object GetByTableAndTime(DateTime date, Table table)
        {
            return All<Reservation>().Select(r => new {r.Arrive, r.Depart}).ToList();
        }
        
        public IList<Reservation> GetByTable(Table table)
        {
            return All<Reservation>(r => r.Table.TableID == table.TableID);
        }
    }
}