using System;
using System.Collections.Generic;
using nac2.Models;

namespace nac2.Services
{
    public class ProdutoService
    {
        private List<Produto> produtos = new List<Produto>();

        public void CadastrarProduto(Produto produto, Lote lote = null)
        {
            if (produto.Categoria == CategoriaProduto.PERECIVEL && lote == null)
                throw new Exception("Produto perecível deve ter lote e data de validade.");
            produtos.Add(produto);
        }

        public List<Produto> ProdutosAbaixoMinimo()
        {
            return produtos.FindAll(p => p.QuantidadeMinimaEstoque > 0); // Exemplo
        }
    }

    public class MovimentacaoService
    {
        public void RegistrarMovimentacao(Produto produto, MovimentacaoEstoque mov)
        {
            if (mov.Quantidade <= 0)
                throw new Exception("Quantidade deve ser positiva.");
            if (mov.Tipo == TipoMovimentacao.SAIDA && mov.Quantidade > produto.QuantidadeMinimaEstoque)
                throw new Exception("Estoque insuficiente.");
            if (produto.Categoria == CategoriaProduto.PERECIVEL && mov.Lote != null && mov.Lote.DataValidade < DateTime.Now)
                throw new Exception("Produto perecível não pode movimentar após validade.");
            // Atualiza saldo (exemplo)
        }
    }

    public class RelatorioService
    {
        public decimal CalcularValorTotalEstoque(List<Produto> produtos)
        {
            decimal total = 0;
            foreach (var p in produtos)
            {
                total += p.PrecoUnitario * p.QuantidadeMinimaEstoque; // Exemplo
            }
            return total;
        }
    }
}
