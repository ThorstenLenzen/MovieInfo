import { 
    Pipe, 
    PipeTransform,
    Input
} from '@angular/core';

@Pipe({
    name: 'reduceString'
})
export class ReduceStringPipe implements PipeTransform {

    @Input()
    public characterNumber: number;

    public transform(value: string, numberOfCharacters: number): string {
        return value.substring(0, numberOfCharacters-1) + '...'; 
    }
}