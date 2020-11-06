import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FAQ } from "../FAQ";

@Component({
  templateUrl: "billett.html"
})
export class Billett {
  laster: boolean;
  alleInfo: Array<FAQ>;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.visSpm(params.id);
      this.laster = true;
    })
  }

  visSpm(id: number) {
    this.http.get<FAQ[]>("api/FAQ/" + id)
      .subscribe(
        spm => {
          this.alleInfo = spm;
          this.laster = false;
        },
        error => console.log(error)
      )
  }
}


