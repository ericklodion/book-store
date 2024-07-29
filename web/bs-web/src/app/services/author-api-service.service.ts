import { Injectable } from '@angular/core';
import Author from '../models/Author';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthorApiServiceService {

  constructor(private http: HttpClient) { }

  getAuthors() : Promise<Author[]>{
    return this.http.get<Author[]>(`${environment.apiUrl}/api/author`).toPromise()
  }

  createAuthor(author: Author): Promise<Author>{
    return this.http.post<Author>(`${environment.apiUrl}/api/author`, author).toPromise()
  }

}
