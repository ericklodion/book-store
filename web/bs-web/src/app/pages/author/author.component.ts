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

    this.loaderService.show()
    this.authorApiService.createAuthor(author).then((regiteredAuthor: Author)=>{
      this.cleanForm()
      this.loadAuthors()
      this.modalRef.hide()
      this.loaderService.hide()
      this.toastService.showToast('Sucesso ao incluir autor.', 'success')
    })
  }

  canSave(){
    return !(
      this.name && this.name.length > 3
    )
  }

  cleanForm(){
    this.name = ''
  }

}
