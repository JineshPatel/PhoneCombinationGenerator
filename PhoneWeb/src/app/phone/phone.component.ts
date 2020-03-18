import { PhoneData } from './../shared/phone-data.model';
import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { NgForm, FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { PaginatorModule } from 'primeng/paginator';
import { PhoneServiceService } from '../shared/phone-service.service';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-phone',
  templateUrl: './phone.component.html',
  styleUrls: ['./phone.component.scss']
})
export class PhoneComponent implements OnInit {

  phoneNumber: string;
  numberValidator = '^(\\d{7}|\\d{10})$';
  registerForm: FormGroup;
  submitted = false;
  valid = false;
  data: PhoneData;
  p: number;
  itemPerPage = 10;
  constructor(private formBuilder: FormBuilder, public phoneservice: PhoneServiceService) { }

  ngOnInit() {
    this.valid = false;
    this.registerForm = this.formBuilder.group({
      phoneNumber: ['', [Validators.required, Validators.pattern(this.numberValidator)]]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }
  onChange(newvalue) {
    this.data = null;
  }
  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    this.valid = true;

    this.phoneservice.getPhoneData(this.phoneNumber, this.itemPerPage, 1).subscribe(result => {
      this.data = result;
    }
    );

  }
  pageChanged(page: number) {
    this.phoneservice.getPhoneData(this.phoneNumber, this.itemPerPage, page).subscribe(result => {
      this.data = result;
      this.p = page;
    }
    );
  }
}
