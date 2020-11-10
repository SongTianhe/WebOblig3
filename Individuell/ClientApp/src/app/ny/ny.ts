import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Melding } from "../Melding";

@Component({
  templateUrl: "ny.html"
})
export class Ny {
  skjema: FormGroup;

  validering = {
    fornavn: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,10}")])
    ],
    etternavn: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,10}")])
    ],
    epost: [
      null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-ZøæåØÆÅ0-9._%+-]+@[a-zA-ZøæåØÆÅ0-9.-]+\\.[a-z]{2,4}$")])
    ],
    melding: [
      null, Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(500)])
    ]
  }

  constructor(private http: HttpClient, private router: Router, private fb: FormBuilder) {
    this.skjema = fb.group(this.validering);
  }

  vedSubmit() {
    this.lagreMelding();
  }

  
  lagreMelding() {
    const lagretMelding = new Melding();

    lagretMelding.fornavn = this.skjema.value.fornavn;
    lagretMelding.etternavn = this.skjema.value.etternavn;
    lagretMelding.epost = this.skjema.value.epost;
    lagretMelding.melding = this.skjema.value.melding;

    this.http.post("api/Kontakt", lagretMelding)
      .subscribe(retur => {
        this.router.navigate(['/alleKontakt']);
      },
        error => console.log(error)
      );
  };
}
