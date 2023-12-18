using S4EModel;
using S4ERepository;
using System.Collections.Generic;

namespace S4EService
{
    public class EmpresaService
    {
        public void SalvarEmpresa(string nome, string cnpj)
        {
            new EmpresaRepository().SalvarEmpresa(nome, cnpj);
        }

        public IEnumerable<Empresas> BuscarTodasEmpresas()
        {
            return new EmpresaRepository().BuscarTodasEmpresas();
        }

        public List<Empresas> BuscarTodasEmpresasNaoVinculadasAoAssociado(int associadoId)
        {
            return new EmpresaRepository().BuscarTodasEmpresasNaoVinculadasAoAssociado(associadoId);
        }

        public List<Empresas> BuscarTodasEmpresasVinculadasAoAssociado(int associadoId)
        {
            return new EmpresaRepository().BuscarTodasEmpresasVinculadasAoAssociado(associadoId);
        }

        public void ExcluirEmpresa(int id)
        {
            new EmpresaRepository().ExcluirEmpresa(id);
        }
    }
}
