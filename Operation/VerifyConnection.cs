using ConnectionTesteConsole.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Serilog;
using System.Net;
using System.Net.Http;

using System.Text;

namespace ConnectionTesteConsole.Operation
{
    public static class VerifyConnection
    {
        /// <summary>
        /// Verifica conexão com api do inforcfc
        /// </summary>
        /// <returns>Retornar texto comprovando conexão com a api</returns>
        /// <exception cref="AuthException">Caso não consiga se conectar com a api dentro de 10 segundos lança uma excessão e continua a executar o codigo</exception>
        public static void WithApi(string LinkDaApi)
        {
            WebClient web = new WebClient();
            Stopwatch TimeCount = new Stopwatch();

            TimeCount.Start();

            try
            {
                Log.Information(web.DownloadString(LinkDaApi).ToString());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
        }

        /// <summary>
        /// Verifica Conexão Com o Banco de dados, Caso não conecte com o banco lança uma exceção
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SqlException">Exceção Caso Não Consiga Se conectar ao servidor ou aconteça algum erro durante a execução</exception>
        public static void WithDB(SqlConnection sqlConnection)
        {
            SqlConnection connection = sqlConnection;
            try
            {
                connection.Open();
                if (connection.State.ToString() == "Open")
                {
                    Log.Information("Conexão estabelecida com sucesso");
                }
            }
            catch (SqlException e)
            {

                Log.Error(e.Message);
            }
            catch (Exception er)
            {
                Log.Error(er.Message);
            }
        }

    }
}
