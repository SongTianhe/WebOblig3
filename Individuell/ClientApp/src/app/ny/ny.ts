import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  templateUrl: "ny.html"
})
export class Ny {
  laster: boolean;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.laster = true;
  }
}
