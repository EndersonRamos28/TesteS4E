using Dapper;
using S4EModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace S4ERepository
{
    public class EmpresaRepository
    {
        private readonly string _connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void SalvarEmpresa(string nome, string cnpj)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"INSERT INTO Empresas (Nome, cnpj)
                            VALUES (@nome, @cnpj)";

                conexao.Execute(sql, new { nome, cnpj });
            }
        }

        public void ExcluirEmpresa(int id)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"DELETE Empresas WHERE id = @id";

                conexao.Execute(sql, new { id });
            }
        }

        public IEnumerable<Empresas> BuscarTodasEmpresas()
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"SELECT
                             Id,Nome,Cnpj
                            FROM Empresas";
                return conexao.Query<Empresas>(sql);
            }
        }

        public List<Empresas> BuscarTodasEmpresasNaoVinculadasAoAssociado(int associadoId)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"SELECT Id,Nome,Cnpj
                            FROM Empresas
                            WHERE NOT EXISTS (
                                SELECT 1
                                FROM AssociadosEmpresas
                                WHERE AssociadosEmpresas.AssociadoId = @associadoId
                            )";

                return conexao.Query<Empresas>(sql, new { associadoId }).ToList();
            }
        }

        public List<Empresas> BuscarTodasEmpresasVinculadasAoAssociado(int associadoId)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"SELECT Id,Nome,Cnpj
                            FROM Empresas e
                            INNER JOIN AssociadosEmpresas AE
                            ON e.Id = AE.EmpresaId
                            WHERE AE.AssociadoId = @associadoId";

                return conexao.Query<Empresas>(sql, new { associadoId }).ToList();
            }
        }
    }
}
