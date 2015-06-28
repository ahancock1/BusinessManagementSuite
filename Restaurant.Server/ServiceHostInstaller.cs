using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Restaurant.Server
{
    [RunInstaller(true)]
    [System.ComponentModel.DesignerCategory("Code")]
    public class ServiceHostInstaller : Installer
    {
        /// <summary>
        /// Enables application to be installed as a windows service by running
        /// InstallUtil
        /// </summary>
        public ServiceHostInstaller()
        {
            Installers.Add(new ServiceInstaller
            {
                StartType = ServiceStartMode.Automatic,
                ServiceName = WindowsService.Name,
                Description = WindowsService.Description
            });

            Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.User,
                Username = WindowsService.Username,
                Password = WindowsService.Password
            });
        }
    }
}
