using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thyrsus.Character.Classes;

namespace Thyrsus.Character.Forms
{
    public partial class fDebug : Form
    {
        private Worker _worker;

        public fDebug()
        {
            InitializeComponent();
            _worker = new Worker();
        }

        private void fDebug_Load(object sender, EventArgs e)
        {
            _worker.Start();
        }
    }
}
