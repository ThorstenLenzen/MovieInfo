import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }  from './app.component';
import { MovieListComponent }  from './movie-list/movie-list.component';
import { MovieCardComponent }  from './movie-card/movie-card.component';

@NgModule({
  imports: [ BrowserModule ],

  declarations: [ 
    AppComponent,
    MovieListComponent,
    MovieCardComponent
  ],

  bootstrap: [ AppComponent ]
})
export class AppModule { }
