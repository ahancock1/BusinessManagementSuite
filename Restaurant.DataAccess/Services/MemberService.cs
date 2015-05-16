using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IMemberService : IGenericService<Member>
    {
        Member GetByEmail(string email);
    }

    public class MemberService : GenericService<Member>, IMemberService
    {
        public Member GetByEmail(string email)
        {
            return Get(m => m.Email.Equals(email));
        }
    }
}
