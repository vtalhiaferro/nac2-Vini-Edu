# Sistema de Gestão de Estoque

Este projeto implementa um sistema para controle de produtos perecíveis e não-perecíveis, com regras de negócio específicas para cada categoria.

## Estrutura Inicial
- src/
  - Models/
  - Services/
  - Controllers/
- README.md

## Etapas do Projeto
1. Modelagem do domínio
2. Implementação das regras de negócio
3. Validações e tratamento de erros
4. Documentação

## Regras de Negócio
- Produtos perecíveis devem ter lote e data de validade
- Não é permitido entrada/saída de quantidade negativa
- Saída só é permitida se houver estoque suficiente
- Produtos abaixo da quantidade mínima geram alerta
- Produto perecível não pode movimentar após data de validade

## Diagrama das Entidades (texto)
Produto: SKU, Nome, Categoria, Preço, Quantidade Mínima, Data de Criação
Lote: Código, Data de Validade (apenas perecíveis)
Movimentação: Tipo (ENTRADA/SAIDA), Quantidade, Data, Lote

## Exemplos de Requisições (API)
// Cadastro de produto
POST /produtos
{
  "sku": "123",
  "nome": "Leite",
  "categoria": "PERECIVEL",
  "precoUnitario": 5.99,
  "quantidadeMinimaEstoque": 10,
  "dataCriacao": "2025-10-29"
}

// Movimentação de estoque
POST /movimentacoes
{
  "tipo": "SAIDA",
  "sku": "123",
  "quantidade": 2,
  "dataMovimentacao": "2025-10-29",
  "lote": {
    "codigoLote": "L001",
    "dataValidade": "2025-11-05"
  }
}

## Como executar
Abra o projeto em ambiente .NET, compile e execute. As regras podem ser testadas via chamadas aos serviços em src/Services.

## Tag de entrega
versao-final
