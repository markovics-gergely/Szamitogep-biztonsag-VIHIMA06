import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCaffComponent } from './add-caff.component';

describe('AddCaffComponent', () => {
  let component: AddCaffComponent;
  let fixture: ComponentFixture<AddCaffComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCaffComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddCaffComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
