using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IStaffMemberService : IGenericService<StaffMember>
    {
    }

    public class StaffMemberService : GenericService<StaffMember>, IStaffMemberService
    {
    }
}
