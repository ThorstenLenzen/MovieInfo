import { MovieService } from './movie-services/movie.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MovieDashboardComponent } from './movie-dashboard/movie-dashboard.component';
import { MovieCardComponent } from './movie-card/movie-card.component';
import { MovieRatingComponent } from './movie-rating/movie-rating.component';

@NgModule({
  declarations: [
    AppComponent,
    MovieDashboardComponent,
    MovieCardComponent,
    MovieRatingComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [ MovieService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
