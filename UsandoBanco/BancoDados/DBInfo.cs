using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UsandoBanco.BancoDados
{
    internal class DBInfo
    {
        //utilizamos o @ para evitar o barra barra invertido, por exemplo: \n
        public const string DBConnection = @"Data Source=BUE0102D007\SQLEXPRESS;Initial Catalog=IntegraDB;User Id=sa;Password=Senac@2023";

        public static bool TestDBConnection()
        {
            var result = false;

            using (var conn = new SqlConnection(DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(ID) FROM PRODUTOS";
                
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"O comando foi executado e retournou {reader.GetInt32(0)} registros em produtos!");
                }

                //conn.Close();
            }

                return result;
        }
    }
}
