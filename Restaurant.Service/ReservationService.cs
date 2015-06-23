using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Restaurant.Service
{
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        void DoWork();
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReservationService" in both code and config file together.
    public class ReservationService : IReservationService
    {
        public void DoWork()
        {
        }
    }
}
