using System.ServiceProcess;
using Thyrsus.Account.Classes;

namespace Thyrsus.Account
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
