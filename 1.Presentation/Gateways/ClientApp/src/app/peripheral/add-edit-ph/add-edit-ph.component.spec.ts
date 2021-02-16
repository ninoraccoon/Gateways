import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPhComponent } from './add-edit-ph.component';

describe('AddEditPhComponent', () => {
  let component: AddEditPhComponent;
  let fixture: ComponentFixture<AddEditPhComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditPhComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
