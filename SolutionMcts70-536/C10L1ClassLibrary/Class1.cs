using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using System.Diagnostics;


namespace C10L1ClassLibrary
{
    [RunInstaller(true)]
    public class InstallLog: Installer
    {
        public InstallLog()
            :base()
        {

        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            if (EventLog.Exists("EventLog Log"))
                EventLog.CreateEventSource("LoggingApp", "EventLog Log");
        }

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
        }

        public override void Rollback(System.Collections.IDictionary savedState)
        {
            base.Rollback(savedState);
            RemoveLog();
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            RemoveLog();
        }

        private void RemoveLog()
        {
            if (EventLog.Exists("EventLog Log"))
            {
                EventLog.DeleteEventSource("LoggingApp");
                EventLog.Delete("EventLog Log");
            }
        }
    }
}
