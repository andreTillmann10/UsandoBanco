using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UsandoBanco.BancoDados;

namespace UsandoBanco.LoginSenha
{
    internal class Usuario
    {
        public int Id { get; private set; }
        public string NickName { get; private set; }
        public string Password { get; private set;}
        public bool IsActive { get; private set; }

        public Usuario(string nickname, string passwword, bool isactive)
        {
            NickName = nickname;
            Password = passwword;
            IsActive = isactive;

        }

        public void Save()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO USERS (NICKNAME, PASSWORD,ISACTIVE) VALUES (@NICKNAME ,@PASSWORD ,@ISACTIVE )";
                cmd.Parameters.AddWithValue("@NICKNAME", NickName);
                cmd.Parameters.AddWithValue("@PASSWORD", Password);
                cmd.Parameters.AddWithValue("@ISACTIVE", IsActive ? "X" : ".");
                

                cmd.ExecuteNonQuery();
            }
        }
    }
}
