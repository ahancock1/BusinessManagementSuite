﻿using System.Collections.Generic;
using System.ServiceModel;
using Restaurant.DataModels.Management;
using Restaurant.DataModels.Management.Floor;
using Restaurant.DataModels.Management.Staff;

namespace Restaurant.DataAccess.Services
{
    [ServiceContract]
    public interface ITicketService : IGenericService<Ticket>
    {
        [OperationContract]
        IList<Ticket> GetByStaffMember(StaffMember member);
    }

    public class TicketService : GenericService<Ticket>, ITicketService
    {
        public IList<Ticket> GetByStaffMember(StaffMember member)
        {
            return GetAll(t => t.StaffMember.MemberID == member.MemberID);
        }

        public IList<Ticket> GetByTable(Table table)
        {
            return GetAll(t => t.Table.TableID == table.TableID);
        } 
    }
}