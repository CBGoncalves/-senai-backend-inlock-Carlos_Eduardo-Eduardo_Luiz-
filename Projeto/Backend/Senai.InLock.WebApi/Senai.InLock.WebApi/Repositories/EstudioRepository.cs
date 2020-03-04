using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DEV1\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdEstudio, NomeEstudio FROM Estudios WHERE IdEstudio = @ID ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        return estudio;
                    }

                    return null;
                }


            }
        }

        public void Cadastrar(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudios (NomeEstudio) VALUES (@NomeEstudio)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@NomeEstudio", estudio.NomeEstudio);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Estudios WHERE IdEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> estudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        estudios.Add(estudio);
                    }
                }
            }

            return estudios;    
        }
    }
}
