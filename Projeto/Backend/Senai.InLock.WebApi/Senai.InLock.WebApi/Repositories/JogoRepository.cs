using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private string stringConexao = "Data Source=DEV1\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor)" +
                                        "VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor)";

                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> jogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogo, NomeJogo, DataLancamento, Valor, Descricao FROM Jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            NomeJogo = rdr["NomeJogo"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = rdr["Valor"].ToString(),

                            Descricao = rdr["Descricao"].ToString()
                        };

                        jogos.Add(jogo);
                    }
                }
            }
            return jogos;
        }

        /* public void Atualizar(int id, JogoDomain JogoAtualizado)
        {
            throw new NotImplementedException();
        }*/

        /*public JogoDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }*/

        /*public List<JogoDomain> BuscarPorNome(string nomeJogo)
        {
            throw new NotImplementedException();
        }*/


        /*public void Deletar(int id)
        {
            throw new NotImplementedException();
        }*/


        /*public List<JogoDomain> ListarOrdenado(string ordemJogo)
        {
            throw new NotImplementedException();
        }*/
    }
}
