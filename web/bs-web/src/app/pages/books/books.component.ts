import { Component, OnInit, TemplateRef } from '@angular/core';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import Author from 'src/app/models/Author';
import Book from 'src/app/models/Book';
import BookPriceTable from 'src/app/models/BookPriceTable';
import BookView from 'src/app/models/BookView';
import PriceTable from 'src/app/models/PriceTable';
import Subject from 'src/app/models/Subject';
import { AuthorApiServiceService } from 'src/app/services/author-api-service.service';
import { BookApiServiceService } from 'src/app/services/book-api-service.service';
import { LoaderService } from 'src/app/services/loader.service';
import { PriceTableApiServiceService } from 'src/app/services/pricetable-api-service.service';
import { SubjectApiServiceService } from 'src/app/services/subject-api-service.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  
  modalRef?: BsModalRef;
  title?: string;
  publisher?: string;
  edition?: number = 1;
  year?: number;
  code?: number;
  tab?: number = 0;
  price?: number;

  authorSelectedOption: number;
  selectedAuthors: Author[] = []

  subjectSelectedOption: number;
  selectedSubjects: Subject[] = []

  priceTableSelectedOption: number;
  selectedPriceTables: BookPriceTable[] = []

  authorsList: Author[]
  booksList: Book[];
  subjectsList: Subject[];
  priceTableList: PriceTable[];

  booksByAuthor: BookView[][] = []
  isPrinting: boolean = false

  constructor(
    private modalService: BsModalService, 
    private bookApiService: BookApiServiceService,
    private authorApiService: AuthorApiServiceService,
    private subjectApiService: SubjectApiServiceService,
    private priceTableApiService: PriceTableApiServiceService,
    private toastService: ToastService,
    private loaderService: LoaderService
  ) {}

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {
        class: 'modal-lg'
    })
  }

  ngOnInit() {
    this.initalLoad()
  }

  async initalLoad(){
    this.loaderService.show()

    const [books, authors, subjects, priceTables] = await Promise.all([
      this.bookApiService.getBooks(),
      this.authorApiService.getAuthors(),
      this.subjectApiService.getSubjects(),
      this.priceTableApiService.getPriceTables()
    ]);

    this.booksList = books;
    this.authorsList = authors;
    this.subjectsList = subjects;
    this.priceTableList = priceTables;

    this.loaderService.hide()
  }

  loadBooks(){
    this.loaderService.show()
    this.bookApiService.getBooks().then((books: Book[])=>{
      this.booksList = books;
      this.loaderService.hide()
    })
  }

  validate(){

    if(!this.title){
      this.toastService.showToast('Digite o título', 'error')
      return false
    }

    if(!this.publisher){
      this.toastService.showToast('Digite a editora', 'error')
      return false
    }

    if(!this.edition || this.edition == 0){
      this.toastService.showToast('Informe a edição', 'error')
      return false
    }

    if(!this.year || this.year == 0){
      this.toastService.showToast('Informe o ano', 'error')
      return false
    }

    if(!this.selectedAuthors || this.selectedAuthors.length == 0){
      this.toastService.showToast('Selecione ao menos um autor', 'error')
      return false
    }

    if(!this.selectedSubjects || this.selectedSubjects.length == 0){
      this.toastService.showToast('Selecione ao menos um assunto', 'error')
      return false
    }

    if(!this.selectedPriceTables || this.selectedPriceTables.length == 0){
      this.toastService.showToast('Informe ao menos uma tabela de preço', 'error')
      return false
    }

    return true
  }

  save(){

    if(!this.validate())
      return

    let book = new Book()
    book.title = this.title
    book.publisher = this.publisher
    book.edition = this.edition
    book.year = this.year
    book.code = this.code
    book.authors = this.selectedAuthors.map(x=> x.code)
    book.subjects = this.selectedSubjects.map(x=> x.code)
    book.priceTables = this.selectedPriceTables

    this.loaderService.show()
    this.modalRef.hide()

    if(this.code){
      this.bookApiService.editBook(book).then((regiteredBook: Book)=>{
        this.cleanForm()
        this.loadBooks()        
        this.loaderService.hide()
        this.toastService.showToast('Sucesso ao alterar livro.', 'success')
      })
    }else{
      this.bookApiService.createBook(book).then((regiteredBook: Book)=>{
        this.cleanForm()
        this.loadBooks()
        this.loaderService.hide()
        this.toastService.showToast('Sucesso ao incluir livro.', 'success')
      })
    }
  }

  cleanForm(){
    this.title = ''
    this.publisher = ''
    this.edition = 1
    this.year = null
    this.code = null
    this.selectedAuthors = []
    this.selectedSubjects = []
    this.selectedPriceTables = []
  }

  create(template: TemplateRef<any>){
    this.cleanForm()
    this.openModal(template)
  }

  edit(book: Book, template: TemplateRef<any>){

    this.loaderService.show()
    this.bookApiService.getByCode(book.code).then((result)=>{

      console.log(book)

      this.title = result.title
      this.code = result.code
      this.publisher = result.publisher
      this.edition = result.edition
      this.year = result.year
      this.selectedAuthors = result.authors ? result.authors.map(x=> this.authorsList.find(y=> y.code == x)) : []
      this.selectedSubjects = result.subjects ? result.subjects.map(x=> this.subjectsList.find(y=> y.code == x)) : []
      this.selectedPriceTables = result.priceTables ? result.priceTables.map(x=> {
        let pt = this.priceTableList.find(y=> y.code == x.code)
        return {
          ...pt,
          price: x.price
        }
      }) : []

      this.loaderService.hide()
      this.openModal(template)
    })
  }

  delete(book: Book){
    this.loaderService.show()
    this.bookApiService.deleteBook(book.code).then(()=>{
      this.cleanForm()
      this.loadBooks()
      this.loaderService.hide()
      this.toastService.showToast('Sucesso ao excluir livro.', 'success')
    })
  }

  addAuthor(){
    if(this.selectedAuthors.find(x=> x.code == this.authorSelectedOption))
      return

    let author = this.authorsList.find(x=> x.code == this.authorSelectedOption)
    if(author)
      this.selectedAuthors.push(author)
  }

  delAuthor(author: Author){
    this.selectedAuthors = this.selectedAuthors.filter(x => x.code !== author.code);
  }

  addSubject(){
    if(this.selectedSubjects.find(x=> x.code == this.subjectSelectedOption))
      return

    let subject = this.subjectsList.find(x=> x.code == this.subjectSelectedOption)
    if(subject)
      this.selectedSubjects.push(subject)
  }

  delSubject(subject: Author){
    this.selectedSubjects = this.selectedSubjects.filter(x => x.code !== subject.code);
  }

  addPriceTable(){
    if(this.selectedPriceTables.find(x=> x.code == this.priceTableSelectedOption))
      return

    if(!this.price)
      return

    let priceTable = this.priceTableList.find(x=> x.code == this.priceTableSelectedOption)
    if(priceTable){
      let bookPriceTable = new BookPriceTable()
      bookPriceTable.code = priceTable.code
      bookPriceTable.description = priceTable.description
      bookPriceTable.price = this.price

      this.price = 0
      this.selectedPriceTables.push(bookPriceTable)
    }
  }

  delPriceTable(priceTable: PriceTable){
    this.selectedPriceTables = this.selectedPriceTables.filter(x => x.code !== priceTable.code);
  }

  currency(value: number): string {
    if (isNaN(value)) {
      return 'R$ 0,00';
    }
    return 'R$ ' + value.toFixed(2).replace('.', ',');
  }

  prepareDownload(){
    this.loaderService.show()
    this.isPrinting = true
    this.bookApiService.getReport().then((booksByAuthor: BookView[][])=>{
      this.booksByAuthor = booksByAuthor;
      this.download()
    })
  }

  download(){
    setTimeout(() => {
      const doc = new jsPDF();
      const element = document.getElementById('printContainer');
      
      html2canvas(element).then((canvas) => {
        const imgData = canvas.toDataURL('image/png');
        const imgProps = doc.getImageProperties(imgData);
        const pdfWidth = doc.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;

        doc.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);
        doc.save('books.pdf');

        this.booksByAuthor = []
        this.isPrinting = false
        this.loaderService.hide()
      });
    }, 1000);
  }

  getSubjects(book: BookView[]){
    var unique = book.map(x=> x.subjectDescription).filter((value, index, array) => array.indexOf(value) === index)
    return unique
  }

  getPrices(book: BookView[]){
    var unique = book.map(x=> `${x.priceTableDescription}: ${this.currency(x.price)}`).filter((value, index, array) => array.indexOf(value) === index)
    return unique
  }

  getBooks(books: BookView[]){
    let groupedData = this.groupBy(books, 'code');
    return groupedData 
  }

  groupBy(arr, key) {
    return Object.values(
      arr.reduce((acc, item) => {
        const groupKey = item[key];

        if (!acc[groupKey]) {
          acc[groupKey] = [];
        }

        acc[groupKey].push(item);
        return acc;
      }, {})
    );
  }
}
