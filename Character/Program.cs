using System.ServiceProcess;
using Thyrsus.Character.Forms;

namespace Thyrsus.Character
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
