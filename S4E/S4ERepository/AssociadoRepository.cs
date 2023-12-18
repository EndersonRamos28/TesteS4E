using System;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using S4EModel;
using System.Collections;
using System.Collections.Generic;

namespace S4ERepository
{
    public class AssociadoRepository
    {
        private readonly string _connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void SalvarAssociado(string nome, string cpf, DateTime? dataNascimento)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"INSERT INTO Associados (Nome, Cpf, DataNascimento)
                            VALUES (@nome, @cpf, @DataNascimento)";

                conexao.Execute(sql, new { nome, cpf, dataNascimento });
            }

        }

        public void ExcluirAssociado(int id)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"DELETE Associados WHERE Id = @id";

                conexao.Execute(sql, new { id });
            }
        }

        public IEnumerable<Associados> BuscarTodosAssociados()
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"SELECT
                                Id,Nome, Cpf, DataNascimento
                            FROM Associados";

                return conexao.Query<Associados>(sql);
            }
        }
    }
}
