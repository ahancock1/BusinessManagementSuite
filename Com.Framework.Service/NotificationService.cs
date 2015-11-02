using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Framework.Data.Core.Notification;

namespace Com.Framework.Service
{
    public interface INotificationService : IService
    {
        void RegisterClient(RegisterData data); // TODO maybe change to be IpAddress and host name



    }

    public interface INotificationCallBackService : IService
    {
        void NotifyClient();
    }

    public class NotificationService : INotificationService
    {
        public void RegisterClient(RegisterData data)
        {


        }


    }

    public class NotificationCallBackService : INotificationCallBackService
    {

        public void NotifyClient()
        {

        }

    }
}
