using System.ServiceProcess;
using Thyrsus.Account.Classes;

namespace Thyrsus.Account
{
    public partial class Service : ServiceBase
    {
        private Worker worker;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            worker = new Worker();
            worker.Start();
        }

        protected override void OnStop()
        {
            worker.Stop();
        }
    }
}
