using System;
using System.Collections.Generic;
using Com.Framework.Data.Rotas;

namespace Com.Framework.Hubs.Rotas
{
    public interface IRotaHub
    {
        Rota GetRota(int rotaID);

        Rota GetRotaByPremiseByWeek(int premiseID, int week);

        IEnumerable<Rota> GetRotasByPremise(int premiseID);

        IEnumerable<Rota> GetRotasByPremiseBetweenDates(int premiseID, DateTime start, DateTime end);

        bool UpdateRotas(string name, params Rota[] rotas);
    }

    public interface IRotaContract
    {
        void UpdateRotas(params Rota[] rota);
    }

    public class RotaHub : ServiceHub<IRotaContract>, IRotaHub
    {
        public Rota GetRota(int rotaID)
        {
            return Service.Get<Rota>(r => r.RotaID == rotaID, r => r.Shifts);
        }

        public Rota GetRotaByPremiseByWeek(int premiseID, int week)
        {
            return Service.Get<Rota>(r => r.PremiseID == premiseID && r.Week == week, r => r.Shifts);
        }

        public IEnumerable<Rota> GetRotasByPremise(int premiseID)
        {
            return Service.All<Rota>(r => r.PremiseID == premiseID, r => r.Shifts);
        }

        public IEnumerable<Rota> GetRotasByPremiseBetweenDates(int premiseID, DateTime start, DateTime end)
        {
            int startWeek = (int)Math.Floor((decimal)start.DayOfWeek / 7);
            int endWeek = (int)Math.Floor((decimal)end.DayOfWeek / 7);


            return Service.All<Rota>(r => r.PremiseID == premiseID && r.Start >= start && r.End <= end, r => r.Shifts);
        }

        public bool UpdateRotas(string name, params Rota[] rotas)
        {
            if (rotas.Length == 0) return false;

            Clients.Group(name).UpdateRotas(rotas);

            return Service.Update(rotas);
        }
    }
}
