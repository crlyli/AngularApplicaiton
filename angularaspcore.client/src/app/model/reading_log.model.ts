import { BookDataModel } from "./book.model";
import { ReaderDataModel } from "./reader.model";

export interface ReadingLogDataModel{
    reader_id: ReaderDataModel;
    book_id: BookDataModel;
    book:BookDataModel;
    reader: ReaderDataModel;
    reading_start: string;
    reading_end: string | undefined;
}
