import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'
import { FlexLayoutModule } from '@angular/flex-layout';

import {MatCardModule} from '@angular/material/card';

import { MoviesRoutingModule } from './movies-routing.module';
import { MovieDashboardComponent } from './movie-dashboard/movie-dashboard.component';
import { MovieService } from './movie.service';
import { MovieOverviewCardComponent } from './movie-overview-card/movie-overview-card.component';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FlexLayoutModule,
    MatCardModule,
    MoviesRoutingModule
  ],
  providers: [
    MovieService
  ],
  declarations: [
    MovieDashboardComponent,
    MovieOverviewCardComponent
  ]
})
export class MoviesModule { }
