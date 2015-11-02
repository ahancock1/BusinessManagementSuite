using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Framework.Data.Rotas;

namespace Com.Framework.Service.Rotas
{
    [ServiceContract]
    public interface IRotaService : IService
    {
        [OperationContract]
        Rota GetRota(int rotaID);

        [OperationContract]
        Rota GetRotaByPremiseByDate(int premiseID, DateTime date);

        [OperationContract]
        Rota GetRotaByPremiseByWeek(int premiseID, int week);

        [OperationContract]
        IEnumerable<Rota> GetRotasByPremise(int premiseID);

        [OperationContract]
        IEnumerable<Rota> GetRotasByPremiseBetweenDates(int premiseId, DateTime start, DateTime end);

        [OperationContract]
        bool Update(params Rota[] items);
    }

    public class RotaService : BaseService, IRotaService
    {
        public Rota GetRota(int rotaID)
        {
            return Service.Get<Rota>(r => r.RotaID == rotaID, r => r.Shifts);
        }

        public Rota GetRotaByPremiseByDate(int premiseID, DateTime date)
        {
            return Service.Get<Rota>(r => r.PremiseID == premiseID && r.Week == (int)Math.Floor((decimal)date.DayOfYear / 7), r => r.Shifts);
        }

        public Rota GetRotaByPremiseByWeek(int premiseID, int week)
        {
            return Service.Get<Rota>(r => r.PremiseID == premiseID && r.Week == week, r => r.Shifts);
        }

        public IEnumerable<Rota> GetRotasByPremise(int premiseID)
        {
            // things like this need to have a page number
            return Service.All<Rota>(r => r.PremiseID == premiseID, r => r.Shifts);
        }

        public IEnumerable<Rota> GetRotasByPremiseBetweenDates(int premiseID, DateTime start, DateTime end)
        {
            int startWeek = (int)Math.Floor((decimal)start.DayOfWeek / 7);
            int endWeek = (int)Math.Floor((decimal)end.DayOfWeek / 7);

            return Service.All<Rota>(r => r.PremiseID == premiseID && r.Week >= startWeek && r.Week <= endWeek,
                r => r.Shifts);
        }

        public bool Update(params Rota[] items)
        {
            return Service.Update(items);
        }
    }
}
