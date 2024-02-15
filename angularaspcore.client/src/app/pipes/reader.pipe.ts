import { Pipe, PipeTransform } from '@angular/core';
import { ReaderDataModel } from '../model/reader.model';
/*
 * Raise the value exponentially
 * Takes an exponent argument that defaults to 1.
 * Usage:
 *   value | exponentialStrength:exponent
 * Example:
 *   {{ 2 | exponentialStrength:10 }}
 *   formats to: 1024
*/
@Pipe({
  standalone: true,
  name: 'readerTransform'
})
export class ReaderPipe implements PipeTransform {
  transform(input: any[], key:string):any {
    return input.map(value => value[key]);
  }
}