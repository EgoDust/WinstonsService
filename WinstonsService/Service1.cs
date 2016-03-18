using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinstonsService
{
    public partial class WinstonsService : ServiceBase
    {
        public WinstonsService()
        {
            InitializeComponent();
            //mine below
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");
            MessageBox.Show("Winston's Service has started", "WinstonsService", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop");
        }
        protected override void OnPause()
        {
            base.OnPause();
            eventLog1.WriteEntry("In OnPause");
        }
        protected override void OnShutdown()
        {
            base.OnShutdown();
            eventLog1.WriteEntry("In OnShutdown");
        }
    }
}
