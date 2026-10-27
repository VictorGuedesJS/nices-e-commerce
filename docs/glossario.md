# Glossário (linguagem ubíqua)

Os termos abaixo são usados **igual** em conversa, código, API e telas. Termo novo entra aqui antes de ir para o código.

| Termo | Código | Significado |
|---|---|---|
| Produto | `Produto` | Peça do catálogo (ex.: "Camiseta Básica Algodão"). Não tem estoque próprio. |
| Variação | `Variacao` | Combinação vendável de um produto: tamanho + cor. É o que vai para o carrinho. |
| SKU | `Sku` | Código único de uma variação (ex.: `CAM-BAS-PRE-M`). Value Object. |
| Tamanho | `Tamanho` | PP, P, M, G, GG, XG ou numeração. Value Object. |
| Cor | `Cor` | Nome + hex (ex.: Preto `#000000`). Value Object. |
| Categoria | `Categoria` | Agrupamento navegável (Masculino > Camisetas). |
| Preço | `Dinheiro` | Valor + moeda (BRL). Nunca `decimal` solto. |
| Estoque | `ItemEstoque` | Quantidade disponível de um SKU. |
| Reserva | `Reserva` | Quantidade separada para um pedido ainda não pago. |
| Carrinho | `Carrinho` | Itens que o cliente pretende comprar. Preços não ficam congelados. |
| Pedido | `Pedido` | Compra fechada. Congela preços, endereço e itens no momento da criação. |
| Item do pedido | `ItemPedido` | SKU + quantidade + preço unitário congelado. |
| Status do pedido | `StatusPedido` | AguardandoPagamento → Pago → EmSeparacao → Enviado → Entregue · Cancelado |
| Cliente | `Cliente` | Pessoa com conta na loja. |
| Endereço | `Endereco` | Endereço de entrega. Value Object. |
| Frete | `Frete` | Custo e prazo de entrega calculados para um CEP. |
| Pagamento | `Pagamento` | Tentativa de cobrança no gateway (Stripe). |
