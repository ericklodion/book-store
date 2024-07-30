import { Injectable } from '@angular/core';
import Book from '../models/Book';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookApiServiceService {

  constructor(private http: HttpClient) { }

  getBooks() : Promise<Book[]>{
    return this.http.get<Book[]>(`${environment.apiUrl}/api/book`).toPromise()
  }

  getByCode(code: number): Promise<Book>{
    return this.http.get<Book>(`${environment.apiUrl}/api/book/${code}`).toPromise()
  }

  createBook(book: Book): Promise<Book>{
    return this.http.post<Book>(`${environment.apiUrl}/api/book`, book).toPromise()
  }

  editBook(book: Book): Promise<Book>{
    return this.http.put<Book>(`${environment.apiUrl}/api/book`, book).toPromise()
  }

  deleteBook(code: number): Promise<any>{
    return this.http.delete(`${environment.apiUrl}/api/book/${code}`).toPromise()
  }

}
