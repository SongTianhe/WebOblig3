/*
import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FAQ } from "../FAQ";

@Component({
  templateUrl: "spmList.html"
})
export class SpmList {
  laster: boolean;
  alleSpm: Array<FAQ>;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.visSpmList(params.id);
      this.laster = true;
    })
  }

  visSpmList(id: number) {
    this.http.get<FAQ[]>("api/FAQ/" + id)
      .subscribe(
        spm => {
          this.alleSpm = spm;
          this.laster = false;
        },
        error => console.log(error)
      )
  }
}*/
//# sourceMappingURL=spmList.js.map