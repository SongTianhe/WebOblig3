import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Melding } from "../Melding";

@Component({
  templateUrl: "alleKontakt.html"
})
export class AlleKontakt {
  alleMeldinger: Array<Melding>;
  laster: boolean;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.laster = true;
    this.hentAlleMeldinger();
  }

  hentAlleMeldinger() {
    this.http.get<Melding[]>("api/Kontakt")
      .subscribe(meldingene => {
        this.alleMeldinger = meldingene;
        this.laster = false;
      },
        error => console.log(error)
      );
  };
}
