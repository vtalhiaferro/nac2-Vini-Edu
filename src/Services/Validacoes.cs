using System;

namespace nac2.Services
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string mensagem) : base(mensagem) { }
    }

    public static class Validacoes
    {
        public static void ValidarProdutoPerecivel(Models.Produto produto, Models.Lote lote)
        {
            if (produto.Categoria == Models.CategoriaProduto.PERECIVEL && lote == null)
                throw new ValidacaoException("Produto perecível deve ter lote e data de validade.");
        }

        public static void ValidarMovimentacao(Models.Produto produto, Models.MovimentacaoEstoque mov)
        {
            if (mov.Quantidade <= 0)
                throw new ValidacaoException("Movimentação com quantidade negativa não permitida.");
            if (mov.Tipo == Models.TipoMovimentacao.SAIDA && mov.Quantidade > produto.QuantidadeMinimaEstoque)
                throw new ValidacaoException("Saída maior que estoque disponível.");
            if (produto.Categoria == Models.CategoriaProduto.PERECIVEL && mov.Lote != null && mov.Lote.DataValidade < DateTime.Now)
                throw new ValidacaoException("Movimentação após data de validade não permitida.");
        }
    }
}
