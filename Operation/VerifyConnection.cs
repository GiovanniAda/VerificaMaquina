using ConnectionTesteConsole.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
        public static string WithApi()
        {
            WebClient web = new WebClient();
            Stopwatch TimeCount = new Stopwatch();

            TimeCount.Start();

            while (TimeCount.ElapsedMilliseconds < 10000)
            {

                try
                {
                    return web.DownloadString("http://api.inforcfc.app.br/api/auth/hora").ToString();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            if (TimeCount.ElapsedMilliseconds > 10000)
            {
                throw new AuthException("Tempo para Conexão Esgotado");
            }
            return "";

        }

        /// <summary>
        /// Verifica Conexão Com o Banco de dados, Caso não conecte com o banco lança uma exceção
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SqlException">Exceção Caso Não Consiga Se conectar ao servidor ou aconteça algum erro durante a execução</exception>
        public static string WithDB()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = @"Server = icfc.guiadocondutor.com.br,1444;UID=giovanni;Password=172031";
                
                connection.Open();
                if (connection.State.ToString() == "Open")
                {
                    return "Conexão estabelecida com sucesso";
                }
                else return "";
               
            }
            catch (SqlException e)
            {

                return e.Message;
            }
            catch (Exception er)
            {
                return er.Message;
            }
    }
       
        }
}
