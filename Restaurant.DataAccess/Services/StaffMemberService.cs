using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IStaffMemberService : IGenericService<StaffMember>
    {
        StaffMember GetByUsername(string username);

        StaffMember GetByEmail(string email);
    }

    public class StaffMemberService : GenericService<StaffMember>, IStaffMemberService
    {
        public StaffMember GetByUsername(string username)
        {
            return Get(m => m.Username.Equals(username));
        }

        public StaffMember GetByEmail(string email)
        {
            return Get(m => m.Email.Equals(email));
        }
    }
}
