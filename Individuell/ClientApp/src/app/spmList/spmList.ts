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
  allSpm: Array<FAQ>;
  selectId: number;
  select: boolean;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.visSpmList(params.id);
      this.laster = true;
      this.select = false;
    })
  }

  visSpmList(id: number) {
    this.http.get<FAQ[]>("api/FAQ/" + id)
      .subscribe(spm => {
        this.allSpm = spm;
        this.laster = false;
      },
        error => console.log(error)
      );
  }

  spmSelect(id: number) {
    this.select = true;
    this.selectId = id;
  }
}
