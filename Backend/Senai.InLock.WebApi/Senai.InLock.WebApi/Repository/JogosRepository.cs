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
        private string stringConexao = "Data Source=DESKTOP-1N95O0N; initial catalog=InLock_Games_Manha; integrated security=true;";

        public void CadastroJogos(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO Jogos (NomeJogo,Descricao,DataLancamento,Valor, Fk_Estudio) VALUES (@NOME,@DESCRICAO,@DATA,@VALOR,@FK)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryCadastro,con))
                {
                    cmd.Parameters.AddWithValue("@NOME", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@DESCRICAO",novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DATA",novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@VALOR", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@FK",novoJogo.Fk_Estudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

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
                                DataLancamento = Convert.ToDateTime(rdr[3]),
                                Valor = Convert.ToDecimal(rdr[4]),
                                Fk_Estudio = Convert.ToInt32(rdr[5]),
                                Estudio = new EstudiosDomain()
                                {
                                    Id_Estudio = Convert.ToInt32(rdr[5]),
                                    NomeEstudio = rdr[6].ToString()
                                }
                            };
                            Jogos.Add(jogo);
                        }
                        return Jogos;                       
                    }
                    return null;
                }
            }
        }
    }
}
