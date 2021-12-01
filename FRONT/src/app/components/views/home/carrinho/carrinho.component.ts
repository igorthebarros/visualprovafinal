import { Component, OnInit } from "@angular/core";
import { FormaPagamento } from "src/app/models/forma-pagamento";
import { ItemVenda } from "src/app/models/item-venda";
import { ItemService } from "src/app/services/item.service";
import { FormaPagamentoService } from "src/app/services/forma-pagamento.service";
import { CarrinhoService } from "src/app/services/carrinho.service";
import { Carrinho } from "src/app/models/carrinho";
import { Router } from "@angular/router";

@Component({
    selector: "app-carrinho",
    templateUrl: "./carrinho.component.html",
    styleUrls: ["./carrinho.component.css"],
})
export class CarrinhoComponent implements OnInit {
    itens: ItemVenda[] = [];
    colunasExibidas: String[] = ["nome", "preco", "quantidade", "imagem"];
    valorTotal!: number;
    cliente!: string;
    formaPagamentoId!: number;
    formasPagamento: FormaPagamento[] = [];
    constructor( private router: Router,
        private itemService: ItemService, 
        private formaPagamentoService: FormaPagamentoService,
        private carrinhoService: CarrinhoService) {}

    ngOnInit(): void {
        let carrinhoId = localStorage.getItem("carrinhoId")! || "";
        this.itemService.getByCartId(carrinhoId).subscribe((itens) => {
            this.itens = itens;
            this.valorTotal = this.itens.reduce((total, item) => {
                return total + item.preco * item.quantidade;
            }, 0);
        });
        this.formaPagamentoService.list().subscribe((formasPagamento) => {
            this.formasPagamento = formasPagamento;
        });
    }

    cadastrar(): void {
        let carrinho: Carrinho = {
            Cliente: this.cliente,
            ItemVenda: this.itens,
            FormaPagamentoId: this.formaPagamentoId
        };
        this.carrinhoService.create(carrinho).subscribe((carrinho) => {
            console.log(carrinho);
            this.router.navigate([""]);
        });
    }
}
