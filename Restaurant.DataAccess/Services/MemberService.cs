using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IMemberService : IGenericService<Member>
    {
    }

    public class MemberService : GenericService<Member>, IMemberService
    {
    }
}
