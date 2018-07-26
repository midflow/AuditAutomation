namespace AuditAutomation.Svc
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
            this.auditServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.auditServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // auditServiceProcessInstaller
            // 
            this.auditServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.auditServiceProcessInstaller.Password = null;
            this.auditServiceProcessInstaller.Username = null;
            // 
            // auditServiceInstaller
            // 
            this.auditServiceInstaller.Description = "Audit Automation Service";
            this.auditServiceInstaller.DisplayName = "Audit Automation Service";
            this.auditServiceInstaller.ServiceName = "AuditAutomationSvc";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.auditServiceProcessInstaller,
            this.auditServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller auditServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller auditServiceInstaller;
    }
}