using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class EstudiosRepository : IEstudiosRepository
    {
        private string stringConexao = "";

        public List<EstudiosDomain> ListarEstudios()
        {
            List<EstudiosDomain> Estudios = new List<EstudiosDomain>(); // lista que será retornada
            using (SqlConnection con = new SqlConnection(stringConexao))  // criei a using em q abrirei a conexao
            {
                string queryListarEstudios = "SELECT Id_Estudio, NomeEstudio From Estudios "; // código q rodará no sql server
                con.Open(); //abrindo conexao

                SqlDataReader rdr; 

                using (SqlCommand cmd = new SqlCommand(queryListarEstudios,con)) // using em q realizarei o comando 
                {
                    rdr = cmd.ExecuteReader(); // realizando o comando de leitura e o aplicando para dentro do "rdr"
                    while(rdr.Read()) // para continuar rodando enquando houver arquivos para ler
                    {
                        EstudiosDomain estudio = new EstudiosDomain // criar um EstudioDomain por arquivo lido
                        {
                            Id_Estudio = Convert.ToInt32(rdr[0]),
                            NomeEstudio = rdr[1].ToString()
                        };
                        Estudios.Add(estudio); // adicionar cada estudio encontrado na lista
                    }
                    return Estudios; // retornar a lista de estudios
                }
            }
        }
    }
}
