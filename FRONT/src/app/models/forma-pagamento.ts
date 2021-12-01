export interface FormaPagamento {
    Id: number;
    Nome: string;
    ImprimirComprovante?: boolean;
    CriadoEm?: Date;
}