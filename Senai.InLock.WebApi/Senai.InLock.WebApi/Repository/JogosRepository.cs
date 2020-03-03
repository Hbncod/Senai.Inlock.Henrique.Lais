using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DEV102\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";
        public List<JogosDomain> ListarJogosEEstudios()
        {
            List<JogosDomain> Jogos = new List<JogosDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListarJogoseestudio = "SELECT Id_Jogo,NomeJogo,Descricao,DataLancamento,Valor,Fk_Estudio, Estudios.NomeEstudio  FROM Jogos LEFT JOIN Estudios ON Jogos.Fk_Estudio = Estudios.Id_Estudio";


                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryListarJogoseestudio,con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(rdr.HasRows)
                    {
                        while(rdr.Read())
                        {
                            JogosDomain jogo = new JogosDomain()
                            {
                                Id_Jogo = Convert.ToInt32(rdr[0]),
                                NomeJogo = rdr[1].ToString(),
                                Descricao = rdr[2].ToString(),
                                DataLancamento = Convert.ToDateTime(rdr[3]) // atribuir demais valores
                            };
                        }
                    }
                }
            }
        }
    }
}
