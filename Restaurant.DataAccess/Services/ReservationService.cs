using System;
using System.Collections.Generic;
using System.ServiceModel;
using Restaurant.DataModels.Management;
using Restaurant.DataModels.Management.Floor;

namespace Restaurant.DataAccess.Services
{
    [ServiceContract]
    public interface IReservationService : IGenericService<Reservation>
    {
        [OperationContract]
        IList<Reservation> GetByMember(Member member);

        [OperationContract]
        IList<Reservation> GetByDate(DateTime date);

        [OperationContract]
        IList<Reservation> GetByTable(Table id);
    }

    public class ReservationService : GenericService<Reservation>, IReservationService
    {
        public IList<Reservation> GetByMember(Member member)
        {
            return GetAll(r => r.Member.MemberID == member.MemberID);
        }

        public IList<Reservation> GetByDate(DateTime date)
        {
            return GetAll(r => r.Arrive.Date.Equals(date.Date));
        }

        public IList<Reservation> GetByTable(Table table)
        {
            return GetAll(r => r.Table.TableID == table.TableID);
        }
    }
}