import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieDashboardComponent } from './movie-dashboard/movie-dashboard.component';

const routes: Routes = [
  {
    path: 'movies/dashboard',
    component: MovieDashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MoviesRoutingModule { }
