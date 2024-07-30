import BookPriceTable from "./BookPriceTable";

export default class Book{
    code: number;
    title: string;
    edition: number;
    year: number;
    publisher: string;
    subjects?: number[];
    authors?: number[];
    priceTables?: BookPriceTable[]
}