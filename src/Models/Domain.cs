using System;

namespace nac2.Models
{
    public enum CategoriaProduto
    {
        PERECIVEL,
        NAO_PERECIVEL
    }

    public class Produto
    {
        public string SKU { get; set; }
        public string Nome { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeMinimaEstoque { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    public class Lote
    {
        public string CodigoLote { get; set; }
        public DateTime DataValidade { get; set; }
    }

    public enum TipoMovimentacao
    {
        ENTRADA,
        SAIDA
    }

    public class MovimentacaoEstoque
    {
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public Lote Lote { get; set; } // Somente para perecíveis
    }
}
