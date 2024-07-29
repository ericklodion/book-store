import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { SubjectComponent } from './pages/subject/subject.component';
import { AuthorComponent } from './pages/author/author.component';
import { PricetableComponent } from './pages/pricetable/pricetable.component';
import { BooksComponent } from './pages/books/books.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SubjectComponent,
    AuthorComponent,
    PricetableComponent,
    BooksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
