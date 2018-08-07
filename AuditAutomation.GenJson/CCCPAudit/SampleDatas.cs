using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.GenJson.CCCPAudit
{
    public static class SampleDatas
    {
        #region "List Data"
        public static string[] SubjectList = new[]
        {
                "CN=XXXXXX.dv2.bbswrs.aze2.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                "CN=XXXXXX.dv1.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                "CN=XXXXXX.dv3.bbswrs.aze3.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                "CN=XXXXXX.dv2.bbswrs.aze2.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                "CN=XXXXXX.dv1.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US"
                };
        public static string[] IssuerList = new[]
        {
                "CN=GEICO SHA256 SUB CA 01, DC=GEICO, DC=corp, DC=net",
                "CN=GEICODDC Private Primary Issuing CA, O=GEICO",
                "DC=Windows Azure CRP Certificate Generator"
                };
        public static string[] ResourceTypeList = new[]
        {
                "Cloud service (classic)",
                "Virtual Machines (classic)",
                "Virtual Machines",
                "Storage account (classic)",
                "DNS Servers (classic)",
                "Local Networks (classic)",
                "Virtual Networks (classic)",
                "Storage account",
                "Availibility Sets",
                "TotalRegionalCoresvCPUs",
                "Virtual Machine Scale Sets",
                "standard DSv2 Family",
                "standard Av2 Family",
                "Basic A Family",
                "standard A0_A7 Family",
                "standard NCv2 Family",
                "standard LS Family",
                "standard G Family"
                };
        public static string[] RegionNameList = new[]
        {
                "East US",
                "West US",
                "North Europe",
                "North Central US"
                };
        public static string[] DataNameList = new[]
                {
                    "GE2XXXXXXXAPP01",
                    "gze-XXXXXX-DV1-cls-XXXXXX-001",
                    "GE3XXXXXXXAPP02",
                    "GE3XXXXXXXAPP03",
                    "gze-XXXXXX-DV2-cls-XXXXXX-002"
                };
        public static string[] DataUserRoleList = new[]
                {
                    "CoAdministrator",
                    "Owner"
                };
        #endregion

    }
}
