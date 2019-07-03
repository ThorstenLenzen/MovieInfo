import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MoviesRoutingModule } from './movies';

const routes: Routes = [
  { 
    path: '**', 
    redirectTo: 'movies/dashboard', 
    pathMatch: 'full' }
];

@NgModule({
  imports: [
    MoviesRoutingModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
