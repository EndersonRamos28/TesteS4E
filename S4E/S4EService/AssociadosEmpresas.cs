using S4ERepository;
using System;
using System.Collections.Generic;

namespace S4EService
{
    public class AssociadosEmpresasService
    {
        public bool VerificarSeAssociadoPossuiEmpresa(int idAssociado)
        {
            return new AssociadosEmpresasRepository().VerificarSeAssociadoPossuiEmpresa(idAssociado);
        }

        public bool VerificarSeEmpresaPossuiAssociado(int idEmpresa)
        {
            return new AssociadosEmpresasRepository().VerificarSeEmpresaPossuiAssociado(idEmpresa);
        }

        public void VincularEmpresasAoAssociado(List<int> empresasSelecionadas, int associadoId)
        {
            new AssociadosEmpresasRepository().VincularEmpresasAoAssociado(empresasSelecionadas, associadoId);
        }

        public void RemoverEmpresasAoAssociado(List<int> empresasSelecionadas, int associadoId)
        {
            new AssociadosEmpresasRepository().RemoverEmpresasAoAssociado(empresasSelecionadas, associadoId);
        }
    }
}
