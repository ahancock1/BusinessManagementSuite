using System.Linq;
using Restaurant.DataAccess.Services;
using Restaurant.Network;
using Restaurant.Network.Packets;

namespace Restaurant.Listeners
{
    public class MemberListener : PacketHandler
    {
        private readonly IMemberService  service;

        public MemberListener()
        {
            // Create data access
            service = new MemberService();

            // Register packets to listen for
            Register<NetMembersRequest>(RequestMember);
            Register<NetMemberUpdate>(UpdateMember);
            Register<NetMemberRequestByUsername>(RequestMemberByEmail);
        }

        public void RequestMember(Connection connection, INetPacket packet)
        {
            if (((NetMembersRequest)packet).Where != null)
            {
                connection.Send(new NetMemberResponse
                {
                    Members = service.GetAll(((NetMembersRequest)packet).Where).ToArray()
                });
            }
            else
            {
                connection.Send(new NetMemberResponse
                {
                    Members = service.GetAll().ToArray()
                });
            }
        }

        public void RequestMemberByEmail(Connection connection, INetPacket packet)
        {
            connection.Send(new NetMemberResponse
            {
                Members = new []
                {
                    service.GetByEmail(((NetMemberRequestByUsername)packet).Email)
                }
            });
        }

        public void UpdateMember(Connection connection, INetPacket packet)
        {
            service.Update(((NetMemberUpdate)packet).Members);
        }
    }
}
