using S4EModel;
using S4ERepository;
using System;
using System.Collections.Generic;

namespace S4EService
{
    public class AssociadoService
    {
        public void SalvarAssociado(string nome, string cpf, DateTime? dataNascimento)
        {
           new AssociadoRepository().SalvarAssociado(nome, cpf, dataNascimento);
        }

        public IEnumerable<Associados> BuscarTodosAssociados()
        {
           return new AssociadoRepository().BuscarTodosAssociados();
        }

        public void ExcluirAssociado(int id)
        {
            new AssociadoRepository().ExcluirAssociado(id);
        }
    }
}
