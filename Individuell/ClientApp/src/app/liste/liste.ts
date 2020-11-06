import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FAQ } from "../FAQ";

@Component({
  templateUrl: "liste.html"
})
export class Liste {
  allTema: Array<FAQ>;
  allSpm: Array<FAQ>;
  laster: boolean;
  visTema: boolean;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.visTema = true;
    this.laster = true;
    this.hentAlleTema();
  }

  hentAlleTema() {
    this.http.get<FAQ[]>("api/FAQ/")
      .subscribe(temaene => {
        this.allTema = temaene;
        this.laster = false;
      },
        error => console.log(error)
      );
  };

  temaSelect(id: number) {
    this.http.get<FAQ[]>("api/FAQ/" + id)
      .subscribe(spm => {
        this.allSpm = spm;
      })
  }
}
