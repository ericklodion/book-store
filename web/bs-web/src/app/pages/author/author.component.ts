import { Component, inject, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import Author from 'src/app/models/Author';
import { AuthorApiServiceService } from 'src/app/services/author-api-service.service';
import { LoaderService } from 'src/app/services/loader.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {

  modalRef?: BsModalRef;
  name?: string;
  code?: number;

  authorList: Author[];

  constructor(
    private modalService: BsModalService, 
    private authorApiService: AuthorApiServiceService,
    private toastService: ToastService,
    private loaderService: LoaderService
  ) {}

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template)
  }

  ngOnInit() {
    this.loadAuthors()
  }

  loadAuthors(){
    this.loaderService.show()
    this.authorApiService.getAuthors().then((authors: Author[])=>{
      this.authorList = authors;
      this.loaderService.hide()
    })
  }

  save(){
    let author = new Author()
    author.name = this.name
    author.code = this.code

    this.loaderService.show()
    this.modalRef.hide()

    if(this.code){
      this.authorApiService.editAuthor(author).then((regiteredAuthor: Author)=>{
        this.cleanForm()
        this.loadAuthors()        
        this.loaderService.hide()
        this.toastService.showToast('Sucesso ao alterar autor.', 'success')
      })
    }else{
      this.authorApiService.createAuthor(author).then((regiteredAuthor: Author)=>{
        this.cleanForm()
        this.loadAuthors()
        this.loaderService.hide()
        this.toastService.showToast('Sucesso ao incluir autor.', 'success')
      })
    }
  }

  canSave(){
    return !(
      this.name && this.name.length > 3
    )
  }

  cleanForm(){
    this.name = ''
    this.code = null
  }

  edit(author: Author, template: TemplateRef<any>){
    this.name = author.name
    this.code = author.code

    this.modalRef = this.modalService.show(template)
  }

  delete(author: Author){
    this.loaderService.show()
    this.authorApiService.deleteAuthor(author.code).then(()=>{
      this.cleanForm()
      this.loadAuthors()
      this.loaderService.hide()
      this.toastService.showToast('Sucesso ao excluir autor.', 'success')
    })
  }
}
