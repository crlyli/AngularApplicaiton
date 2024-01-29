export interface AddBookRequest {
    id:number;
    title:string;
    description :string;
    author: string;
    rate: number
    dateStart: string;
    dateFinish : string;
}