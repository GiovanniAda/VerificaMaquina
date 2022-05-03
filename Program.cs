using ConnectionTesteConsole.Exceptions;
using System;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Data.SqlClient;
using System.Net.Http;
using Serilog;
using ConnectionTesteConsole.Operation;

namespace ConnectionTesteConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "";
            

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Verificando Versão Do Windows...");
            Check.OsVersion(new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"));

            Log.Information("Quantidade De Memoria Ram Na maquina");
            Check.QuantidadeMemoriaRam(new ManagementObjectSearcher("SELECT MaxCapacity FROM Win32_PhysicalMemoryArray"));

            Log.Information("Verificando Conexão Com Api");
           VerifyConnection.WithApi("");

            Log.Information("Verificando Conexão Com o Banco de Dados");
            VerifyConnection.WithDB(sqlConnection);

            Console.WriteLine("Aperte Enter Para Fechar");
            Console.ReadLine();

        }
    }
}
