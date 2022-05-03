using ConnectionTesteConsole.Exceptions;
using System;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.Http;
using Serilog;
using ConnectionTesteConsole.Operation;

namespace ConnectionTesteConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

           // Log.Logger = new LoggerConfiguration()
             //   .MinimumLevel.Debug()
               // .WriteTo.File(@"f:log\log.txt", rollingInterval: RollingInterval.Day)
                //.CreateLogger();

            Log.Information("Iniciando Teste De rede");
            Log.Information("Verificando Versão Do Windows...");
            Log.Information(Check.OsVersion());
            Log.Information("Verificando Conexão Com Api");
            Log.Information(VerifyConnection.WithApi());
            Log.Information("Verificando Conexão Com o Banco de Dados");
            Log.Information(VerifyConnection.WithDB());
         

        }
    }
}
