using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Security.Principal;


namespace C8Suggested2WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller:System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            if(!System.Diagnostics.EventLog.SourceExists("Service"))
            {
                System.Diagnostics.EventLog.CreateEventSource("Service", "ConfigAcess");
            }
        }
    }
}
