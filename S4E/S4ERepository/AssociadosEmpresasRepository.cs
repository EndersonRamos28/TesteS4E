using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace S4ERepository
{
    public class AssociadosEmpresasRepository
    {
        private readonly string _connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool VerificarSeAssociadoPossuiEmpresa(int idAssociado)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"SELECT CAST(CASE WHEN EXISTS (
                        SELECT 1 
                        FROM AssociadosEmpresas 
                        WHERE AssociadoId = @idAssociado
                        ) THEN 1 ELSE 0 END AS BIT)";

                return conexao.ExecuteScalar<bool>(sql, new { idAssociado });
            }
        }

        public void VincularEmpresasAoAssociado(List<int> empresasSelecionadas, int associadoId)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"INSERT INTO AssociadosEmpresas (EmpresaId, AssociadoId)
                            VALUES (@empresasSelecionadas, @associadoId)";

                conexao.Execute(sql, new { empresasSelecionadas, associadoId });
            }
        }

        public void RemoverEmpresasAoAssociado(List<int> empresasSelecionadas, int associadoId)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"DELETE AssociadosEmpresas WHERE EmpresaId IN @empresasSelecionadas AND associadoId = @associadoId";

                conexao.Execute(sql, new { empresasSelecionadas, associadoId });
            }
        }

        public void VincularAssociadosAEmpresas(List<int> associadosIds, int empresaId)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"INSERT INTO AssociadosEmpresas (EmpresaId, AssociadoId)
                            VALUES (@empresaId, @associadosIds)";

                conexao.Execute(sql, new { associadosIds, empresaId });
            }
        }

        public bool VerificarSeEmpresaPossuiAssociado(int idEmpresa)
        {
            using (var conexao = new SqlConnection(_connection))
            {
                var sql = @"SELECT CAST(CASE WHEN EXISTS (
                        SELECT 1 
                        FROM AssociadosEmpresas 
                        WHERE EmpresaId = @idEmpresa
                        ) THEN 1 ELSE 0 END AS BIT)";

                return conexao.ExecuteScalar<bool>(sql, new { idEmpresa });
            }
        }
    }
}
