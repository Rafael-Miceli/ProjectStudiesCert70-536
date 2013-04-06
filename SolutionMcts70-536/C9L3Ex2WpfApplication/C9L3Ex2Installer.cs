using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using System.IO;

namespace C9L3Ex2WpfApplication
{
    [RunInstaller(true)]
    class C9L3Ex2Installer: Installer
    {
        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
            File.CreateText("Commit.txt");
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            File.CreateText("Install.txt");
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            File.Delete("Install.txt");
            File.Delete("Commit.txt");
        }

        public override void Rollback(System.Collections.IDictionary savedState)
        {
            base.Rollback(savedState);
            File.Delete("Install.txt");
        }
    }
}
