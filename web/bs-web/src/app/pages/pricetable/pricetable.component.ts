import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import PriceTable from 'src/app/models/PriceTable';
import { LoaderService } from 'src/app/services/loader.service';
import { PriceTableApiServiceService } from 'src/app/services/pricetable-api-service.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-pricetable',
  templateUrl: './pricetable.component.html',
  styleUrls: ['./pricetable.component.css']
})
export class PricetableComponent implements OnInit {

  
  modalRef?: BsModalRef;
  description?: string;
  code?: number;

  priceTableList: PriceTable[];

  constructor(
    private modalService: BsModalService, 
    private priceTableApiService: PriceTableApiServiceService,
    private toastService: ToastService,
    private loaderService: LoaderService
  ) {}

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template)
  }

  ngOnInit() {
    this.loadPriceTables()
  }

  loadPriceTables(){
    this.loaderService.show()
    this.priceTableApiService.getPriceTables().then((priceTables: PriceTable[])=>{
      this.priceTableList = priceTables;
      this.loaderService.hide()
    })
  }

  save(){
    let priceTable = new PriceTable()
    priceTable.description = this.description
    priceTable.code = this.code

    this.loaderService.show()
    this.modalRef.hide()

    if(this.code){
      this.priceTableApiService.editPriceTable(priceTable).then((regiteredPriceTable: PriceTable)=>{
        this.cleanForm()
        this.loadPriceTables()        
        this.loaderService.hide()
        this.toastService.showToast('Sucesso ao alterar tabela de preço.', 'success')
      })
    }else{
      this.priceTableApiService.createPriceTable(priceTable).then((regiteredPriceTable: PriceTable)=>{
        this.cleanForm()
        this.loadPriceTables()
        this.loaderService.hide()
        this.toastService.showToast('Sucesso ao incluir tabela de preço.', 'success')
      })
    }
  }

  canSave(){
    return !(
      this.description && this.description.length > 3
    )
  }

  cleanForm(){
    this.description = ''
    this.code = null
  }

  edit(priceTable: PriceTable, template: TemplateRef<any>){
    this.description = priceTable.description
    this.code = priceTable.code

    this.modalRef = this.modalService.show(template)
  }

  delete(priceTable: PriceTable){
    this.loaderService.show()
    this.priceTableApiService.deletePriceTable(priceTable.code).then(()=>{
      this.cleanForm()
      this.loadPriceTables()
      this.loaderService.hide()
      this.toastService.showToast('Sucesso ao excluir tabela de preço.', 'success')
    })
  }

}
