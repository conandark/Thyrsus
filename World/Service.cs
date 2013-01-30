using System.ServiceProcess;
using Thyrsus.World.Classes;

namespace Thyrsus.World
{
    public partial class Service : ServiceBase
    {
        private Worker _worker;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _worker = new Worker();
            _worker.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
