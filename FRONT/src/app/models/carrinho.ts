import { ItemVenda } from "./item-venda";

export interface Carrinho {
    Id?: number;
    Cliente: string;
    ItemVenda: ItemVenda[];
    FormaPagamentoId: number;
}