using Senai.InLock.WebApi.DataViewModel;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-1N95O0N; initial catalog=InLock_Games_Manha; integrated security=true;";

        public UsuariosDomain BuscarEmailESenha(UsuarioViewModel usuariobuscado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarEmaileSenha = "SELECT Email,Senha,Id_Usuario, Fk_TipoUsuario FROM Usuarios WHERE Email = @EMAIL AND Senha = @SENHA";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarEmaileSenha, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", usuariobuscado.Email);
                    cmd.Parameters.AddWithValue("@SENHA", usuariobuscado.Senha);

                    rdr = cmd.ExecuteReader();

                    if(rdr.HasRows)
                    {
                        while(rdr.Read())
                        {
                            UsuariosDomain usuario = new UsuariosDomain()
                            {
                                Email = rdr[0].ToString(),
                                Senha = rdr[1].ToString(),
                                Id_Usuario = Convert.ToInt32(rdr[2]),
                                Fk_TipoUsuario = Convert.ToInt32(rdr[3])
                            };
                            return usuario;
                        }
                    }
                    return null;
                }
            }
        }
    }
}
