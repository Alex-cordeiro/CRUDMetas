import { Pipe, PipeTransform } from "@angular/core";


@Pipe({
    name: 'arrayfiltro'
})

export class FiltroPecasPipe implements PipeTransform{
    transform(value: Array<any>, filtro: string | null | undefined): any {
        if(filtro) {
            filtro = filtro.toUpperCase();
            console.log(filtro);
            const retorno = value.filter( v => {
                v.nome.toUpperCase().indexOf(filtro) >= 0
            });

            console.log(retorno);
            return retorno;
        }else{
            console.log(value);
            return value;
            
        }
    }
}