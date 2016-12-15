import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { ReduceStringPipe, MovieCardComponent }  from './movie-card';

import { AppComponent }  from './app.component';
import { MovieListComponent }  from './movie-list/movie-list.component';

@NgModule({
  imports: [ BrowserModule ],

  declarations: [
    AppComponent,
    MovieListComponent,
    MovieCardComponent,

    ReduceStringPipe
  ],

  bootstrap: [ AppComponent ]
})
export class AppModule { }
