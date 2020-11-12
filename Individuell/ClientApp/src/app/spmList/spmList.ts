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
  saveTemaId: number;
  ratingClicked: boolean;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.visSpmList(params.id);
      this.saveTemaId = params.id;
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
    this.ratingClicked = false;
  }

  rating(id: number, positiv: number, negativ: number, type: string) {

    const endreLike = new FAQ();

    //sjekk hvilken knapp som ble klikket på
    if (type == "like") {
      //Legg en til det opprinnelige nummeret
      const nyTall = positiv + 1;

      endreLike.id = id;
      endreLike.positiv = nyTall;
      endreLike.negativ = negativ;
    }
    else if (type == "dislike") {
      const nyTall = negativ + 1;

      endreLike.id = id;
      endreLike.positiv = positiv;
      endreLike.negativ = nyTall;
    }

    this.http.put("api/FAQ/", endreLike)
      .subscribe(
        retur => {
          //saveTemaId lagret id-en som ble sendt inn første, som er id-en til tema
          const temaID = this.saveTemaId;
          this.visSpmList(temaID);
          this.ratingClicked = true;
        },
        error => console.log(error)
      );
  }
}
