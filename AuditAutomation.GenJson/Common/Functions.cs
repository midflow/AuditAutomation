using AuditAutomation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.GenJson.Common
{
    public static class Functions
    {
        //using for random function
        public static Random random = new Random();             

        public static Boolean WriteToJson(IList<Audit> AuditList, out string errorMsg)
        {
            errorMsg = "";
            try
            {
                foreach (var audit in AuditList)
                {
                    //ignore null object
                    var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                    string json = JsonConvert.SerializeObject(audit, jsonSettings);

                    //write Json string to file
                    System.IO.File.WriteAllText(Helpers.ConfigurationHelper.RetreiveAppSetting(
                        Constants.LOCAL_FILE_OUTPUT) + audit.AuditSubcategoryType + "\\" + audit.AuditId + ".json", json);
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;                       
            }
        
            return true;
        }

        /// <summary>
        /// Generate random string with numbers or letters like "YYEere232"
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Generate random string with number like "1232343"
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns></returns>
        public static string RandomNumberString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Generate random string with UPPERCASE
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns></returns>
        public static string RandomUpperCaseString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Generate random string with lowercase
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns></returns>
        public static string RandomLowerCaseString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
