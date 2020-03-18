import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Component } from '@angular/core';

/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PhoneComponent } from './phone.component';

class Page {
  constructor(private fixture: ComponentFixture<PhoneComponent>) {
  }

  get component(): PhoneComponent {
    return this.fixture.componentInstance;
  }
}

class setup {
  public static getFormGroup() {
    return new FormGroup({
      phoneNumber: new FormControl(['', [Validators.required, Validators.pattern('^(\\d{7}|\\d{10})$')]])
    });
  }
}

describe('PhoneComponent', () => {
  
  let fixture: ComponentFixture<PhoneComponent>;
  let page: Page;

  async function createComponent() {
    fixture = TestBed.createComponent(PhoneComponent);

    page = new Page(fixture);
    page.component.registerForm = setup.getFormGroup();
    fixture.detectChanges();
    await fixture.whenStable();
  }

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PhoneComponent]
    })
      .compileComponents();
  }));

  it('should create', () => {
    expect(page.component).toBeTruthy();
  });

  it('should show error message on submit when there is no number entered', () => { 
    page.component.registerForm.get('phoneNumber').setValue('');
    page.component.submitted = true;
    spyOn(page.component, 'onSubmit');

  let button = fixture.debugElement.nativeElement.querySelector('id_submit_button');
  button.click();

  fixture.whenStable().then(() => {
    expect(page.component.onSubmit).toHaveBeenCalled();
  });
  });
});
