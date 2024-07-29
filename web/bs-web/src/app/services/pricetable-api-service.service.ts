import { Injectable } from '@angular/core';
import PriceTable from '../models/PriceTable';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PriceTableApiServiceService {

  constructor(private http: HttpClient) { }

  getPriceTables() : Promise<PriceTable[]>{
    return this.http.get<PriceTable[]>(`${environment.apiUrl}/api/priceTable`).toPromise()
  }

  createPriceTable(priceTable: PriceTable): Promise<PriceTable>{
    return this.http.post<PriceTable>(`${environment.apiUrl}/api/priceTable`, priceTable).toPromise()
  }

  editPriceTable(priceTable: PriceTable): Promise<PriceTable>{
    return this.http.put<PriceTable>(`${environment.apiUrl}/api/priceTable`, priceTable).toPromise()
  }

  deletePriceTable(code: number): Promise<any>{
    return this.http.delete(`${environment.apiUrl}/api/priceTable/${code}`).toPromise()
  }

}
