using System.Collections.Generic;
using Aula86.Entidades;

namespace Aula86.AcessoDados
{
    public interface IProdutoRepository
    {
        List<Produto> ListarProdutos();
        Produto ObterProdutoPorId(int id);
        void Salvar(Produto produto);
    }
}