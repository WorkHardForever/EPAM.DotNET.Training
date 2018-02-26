using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class App : Application
    {
        Mutex mut = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            if (Mutex.TryOpenExisting("MutexName", out mut))
            {
                MessageBox.Show("Приложение уже запущено");
                mut = null;
                this.Shutdown();
            }
            mut = new Mutex(true, "MutexName");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (mut != null)
            {
                mut.Dispose();
            }
        }
    }
}
