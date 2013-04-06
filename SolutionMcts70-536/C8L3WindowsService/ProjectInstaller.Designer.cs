namespace C8L3WindowsService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller2 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller2 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller2
            // 
            this.serviceProcessInstaller2.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller2.Password = null;
            this.serviceProcessInstaller2.Username = null;
            // 
            // serviceInstaller2
            // 
            this.serviceInstaller2.Description = "2 Logs responses from Microsoft.com";
            this.serviceInstaller2.DisplayName = "Service WebSite Monitor";
            this.serviceInstaller2.ServiceName = "ServiceMonitorWebSite2";
            this.serviceInstaller2.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller2,
            this.serviceInstaller2});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller2;
        private System.ServiceProcess.ServiceInstaller serviceInstaller2;
    }
}