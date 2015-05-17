using System.Linq;
using Restaurant.Data;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public class MemberListener : PacketHandler
    {
        private readonly IGenericService<Member> service;

        public MemberListener()
        {
            // Create data access
            service = new GenericService<Member>();

            // Register packets to listen for
            Register<NetMemberRequest>(RequestMember);
            Register<NetMembersRequest>(RequestMembers);
            Register<NetMemberUpdate>(UpdateMember);
        }

        private void RequestMembers(Connection connection, INetPacket packet)
        {
            if (((NetMembersRequest) packet).Where != null)
            {
                connection.Send(new NetMembersResponse
                {
                    Members = service.GetAll(((NetMembersRequest) packet).Where).ToArray()
                });
            }
            else
            {
                connection.Send(new NetMembersResponse
                {
                    Members = service.GetAll().ToArray()
                });
            }
        }

        private void RequestMember(Connection connection, INetPacket packet)
        {
            connection.Send(new NetMemberResponse
            {
                Member = service.Get(((NetMemberRequest) packet).Where)
            });
        }

        private void UpdateMember(Connection connection, INetPacket packet)
        {
            service.Update(((NetMemberUpdate) packet).Members);
        }
    }
}
