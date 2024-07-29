import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AuthorComponent } from './pages/author/author.component';
import { PricetableComponent } from './pages/pricetable/pricetable.component';
import { SubjectComponent } from './pages/subject/subject.component';
import { BooksComponent } from './pages/books/books.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'authors', component: AuthorComponent },
  { path: 'subjects', component: SubjectComponent },
  { path: 'pricetables', component: PricetableComponent },
  { path: 'books', component: BooksComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
