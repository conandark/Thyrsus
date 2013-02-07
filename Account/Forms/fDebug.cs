using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thyrsus.Account.Classes;

namespace Thyrsus.Account.Forms
{
    public partial class fDebug : Form
    {
        private Worker worker;

        public fDebug()
        {
            InitializeComponent();
            worker = new Worker();
        }

        private void fDebug_Load(object sender, EventArgs e)
        {
            worker.Start();
        }

        private void fDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            worker.Stop();
        }
    }
}
