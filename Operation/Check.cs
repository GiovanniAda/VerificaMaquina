using ConnectionTesteConsole.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Net;
using Serilog;
using System.Net.Http;
using System.Text;

namespace ConnectionTesteConsole.Operation
{
    public static class Check
    {

        public static void QuantidadeMemoriaRam(ManagementObjectSearcher RamMemoryLocation)
        {
            int memoriaRam = 0;
            try
            {
                using (RamMemoryLocation)
                {
                    ManagementObjectCollection Informartion = RamMemoryLocation.Get();
                    if (Informartion != null)
                    {
                        foreach (ManagementObject obj in Informartion)
                        {
                            UInt32 tamanhoKB = Convert.ToUInt32(obj.Properties["MaxCapacity"].Value);
                            UInt32 tamanhoMB = tamanhoKB / 1024;
                            memoriaRam += Convert.ToInt32(tamanhoMB);
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            Log.Information($"{memoriaRam} Mb");

        }

        public static void OsVersion(ManagementObjectSearcher searcherOsVersion)
        {
            string OsVersionAwanser = "";
            try
            {
                using (searcherOsVersion)
                {
                    ManagementObjectCollection information = searcherOsVersion.Get();
                    if (information != null)
                    {
                        foreach (ManagementObject obj in information)
                        {
                            OsVersionAwanser = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                    OsVersionAwanser = OsVersionAwanser.Replace("NT 5.1.2600", "XP");
                    OsVersionAwanser = OsVersionAwanser.Replace("NT 5.2.3790", "Server 2003");

                }
            }
            catch (Exception erro)
            {

                Log.Error(erro.Message);
            }
            
            Log.Information(OsVersionAwanser);
        }


    }

}

