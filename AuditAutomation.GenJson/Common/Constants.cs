using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.GenJson.Common
{
    public static class Constants
    {
        public const string LOCAL_FILE_OUTPUT = "OutputPath";
        public const string NO_AUDIT = "NoAudit";        
        public const int MAX_DAY_EXPIRE = 99;
        public const int SERIAL_LENGTH = 36;
        public const int NO_REGION = 2;
        public const int NO_REGION_CCCP4005 = 1;
        public const int NO_RESOURCE = 3;
        public const int NO_RESOURCE_CCCP4005 = 1;
        public const int NO_RESOURCE_CCCP1005 = 2;
        public const int NO_RESOURCE_CCCP3002 = 35;
        public const int NO_DATA_CCCP4005 = 3;
        public const int NO_CERTIFICATE = 2;
        public const int NO_ADGROUP = 2;
        public const int NO_ADUSER = 3;
        public const string AUDIT_4005 = "CCCP4005";
        public const string AUDIT_2005 = "CCCP2005";
        public const string AUDIT_1005 = "CCCP1005";
        public const string AUDIT_1003 = "CCCP1003";
        public const string AUDIT_3002 = "CCCP3002";
        public const string AUDIT_4001 = "CCCP4001";
    }
}
