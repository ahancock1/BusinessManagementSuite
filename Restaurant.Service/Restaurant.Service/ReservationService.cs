using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Restaurant.Data.Management;
using Restaurant.Data.Management.Floor;
using Restaurant.DataAccess.Services;

namespace Restaurant.Service
{
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        IList<Reservation> GetByMember(Member member);

        [OperationContract]
        IList<Reservation> GetByDate(DateTime date);

        [OperationContract]
        IList<Reservation> GetByTable(Table id);
    }

    public class ReservationService : IReservationService
    {
        private IGenericService service = new GenericService();
        

        public IList<Reservation> GetByMember(Member member)
        {
            return service.All<Reservation>(r => r.Member.MemberID == member.MemberID).ToList();
        }

        public IList<Reservation> GetByDate(DateTime date)
        {
            return service.All<Reservation>(r => r.Arrive.Date.Equals(date.Date));
        }

        public object GetByTableAndTime(DateTime date, Table table)
        {
            return service.All<Reservation>().Select(r => new { r.Arrive, r.Depart }).ToList();
        }

        public IList<Reservation> GetByTable(Table table)
        {
            return service.All<Reservation>(r => r.Table.TableID == table.TableID);
        }
    }
}
