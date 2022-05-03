using ConnectionTesteConsole.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConnectionTesteConsole.Operation
{
    public static class Check
    {
        public static string OsVersion()
        {
            string OsVersionAwanser = "";
            using (ManagementObjectSearcher searcherOsVersion = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                ManagementObjectCollection information = searcherOsVersion.Get();
                if (information != null)
                {
                    foreach (ManagementObject obj in information)
                    {
                        OsVersionAwanser = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                    }
                }
                OsVersionAwanser = OsVersionAwanser.Replace("NT 5.1.2600", "XP");
                OsVersionAwanser = OsVersionAwanser.Replace("NT 5.2.3790", "Server 2003");

            }
            return OsVersionAwanser;
        }


    }

}

