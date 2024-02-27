import { BookDataModel } from "./book.model";
import { ReaderDataModel } from "./reader.model";

export interface ReadingLogDtoModel{
    readerId: ReaderDataModel;
    bookId: BookDataModel;
    ReadingStart: string;
    ReadingEnd: string | undefined;
}
