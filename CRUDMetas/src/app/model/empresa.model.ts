import { Departamento } from "./departamento.model";
import { Setor } from "./setor.model";
import { Vendedor } from "./vendedor.model";

export class Empresa{
    public id!: number;
    public nome!: string;
    public setores!: Array<Setor>;
    public filiais!: Array<Departamento>;
    public vendedores!:Array<Vendedor>;
}