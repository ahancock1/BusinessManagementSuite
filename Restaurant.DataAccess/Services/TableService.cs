using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface ITableService : IGenericService<Table>
    {
        Table GetByNumber(int number);
    }

    public class TableService : GenericService<Table>, ITableService
    {
        public Table GetByNumber(int number)
        {
            return Get(t => t.Number == number);
        }
    }
}