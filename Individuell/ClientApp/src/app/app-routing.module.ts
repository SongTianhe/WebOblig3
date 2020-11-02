import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Liste } from './liste/liste';

const appRoots: Routes = [
  { path: 'liste', component: Liste },
  { path: '', redirectTo: 'liste', pathMatch: 'full' }
]

@NgModule({
  imports: [
    RouterModule.forRoot(appRoots)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }