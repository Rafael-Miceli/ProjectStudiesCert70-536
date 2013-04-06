using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;

namespace C10L2ClassLibrary
{
    public class InstallPerf: Installer
    {
        public InstallPerf()
            :base()
        {

        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            if(!PerformanceCounterCategory.Exists("PerfApp"))
            {
                PerformanceCounterCategory.Create("PerfApp", "Conters for app", PerformanceCounterCategoryType.SingleInstance, "Clicks", "Times the user has clicked the button");
            }
        }

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);

            if(PerformanceCounterCategory.Exists("PerfApp"))
                PerformanceCounterCategory.Delete("PerfApp");
        }

        public override void Rollback(System.Collections.IDictionary savedState)
        {
            base.Rollback(savedState);

            if(PerformanceCounterCategory.Exists("PerfApp"))
                PerformanceCounterCategory.Delete("PerfApp");
        }
    }
}
