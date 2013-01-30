using System.ServiceProcess;
using Thyrsus.World.Forms;

namespace Thyrsus.World
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service()
			};
#if !DEBUG
			ServiceBase.Run(ServicesToRun);
#else
            RunServiceInForm();
#endif
        }

        static void RunServiceInForm()
        {
            var f = new fDebug();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
