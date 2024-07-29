import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import Subject from 'src/app/models/Subject';
import { LoaderService } from 'src/app/services/loader.service';
import { SubjectApiServiceService } from 'src/app/services/subject-api-service.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit {

  modalRef?: BsModalRef;
  description?: string;
  code?: number;

  subjectList: Subject[];

  constructor(
    private modalService: BsModalService, 
    private subjectApiService: SubjectApiServiceService,
    private toastService: ToastService,
    private loaderService: LoaderService
  ) {}

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template)
  }

  ngOnInit() {
    this.loadSubjects()
  }

  loadSubjects(){
    this.loaderService.show()
    this.subjectApiService.getSubjects().then((subjects: Subject[])=>{
      this.subjectList = subjects;
      this.loaderService.hide()
    })
  }

  save(){
    let subject = new Subject()
    subject.description = this.description
    subject.code = this.code

    this.loaderService.show()
    this.modalRef.hide()

    if(this.code){
      this.subjectApiService.editSubject(subject).then((regiteredSubject: Subject)=>{
        this.cleanForm()
        this.loadSubjects()        
        this.loaderService.hide()
        this.toastService.showToast('Sucesso ao alterar assunto.', 'success')
      })
    }else{
      this.subjectApiService.createSubject(subject).then((regiteredSubject: Subject)=>{
        this.cleanForm()
        this.loadSubjects()
        this.loaderService.hide()
        this.toastService.showToast('Sucesso ao incluir assunto.', 'success')
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

  edit(subject: Subject, template: TemplateRef<any>){
    this.description = subject.description
    this.code = subject.code

    this.modalRef = this.modalService.show(template)
  }

  delete(subject: Subject){
    this.loaderService.show()
    this.subjectApiService.deleteSubject(subject.code).then(()=>{
      this.cleanForm()
      this.loadSubjects()
      this.loaderService.hide()
      this.toastService.showToast('Sucesso ao excluir assunto.', 'success')
    })
  }
}
