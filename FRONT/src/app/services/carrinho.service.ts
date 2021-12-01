import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Carrinho } from "../models/carrinho";

@Injectable({
    providedIn: "root",
})

export class CarrinhoService {
    private baseUrl = "http://localhost:5000/api/carrinho";

    constructor(private http: HttpClient) {}

    create(carrinho: Carrinho): Observable<Carrinho> {
        return this.http.post<Carrinho>(`${this.baseUrl}/create`, carrinho);
    }
}