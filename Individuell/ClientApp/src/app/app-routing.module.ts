import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Liste } from './liste/liste';
import { Ny } from './ny/ny';
import { SpmList } from './spmList/spmList';

const appRoots: Routes = [
  { path: 'liste', component: Liste },
  { path: 'ny', component: Ny },
  { path: 'spmList/:id', component: SpmList },
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
