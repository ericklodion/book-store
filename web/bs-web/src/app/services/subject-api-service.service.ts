import { Injectable } from '@angular/core';
import Subject from '../models/Subject';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SubjectApiServiceService {

  constructor(private http: HttpClient) { }

  getSubjects() : Promise<Subject[]>{
    return this.http.get<Subject[]>(`${environment.apiUrl}/api/subject`).toPromise()
  }

  createSubject(subject: Subject): Promise<Subject>{
    return this.http.post<Subject>(`${environment.apiUrl}/api/subject`, subject).toPromise()
  }

  editSubject(subject: Subject): Promise<Subject>{
    return this.http.put<Subject>(`${environment.apiUrl}/api/subject`, subject).toPromise()
  }

  deleteSubject(code: number): Promise<any>{
    return this.http.delete(`${environment.apiUrl}/api/subject/${code}`).toPromise()
  }

}
