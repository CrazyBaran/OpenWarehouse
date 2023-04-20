import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PutAwayProcessComponent } from './put-away-process.component';

describe('PutAwayProcessComponent', () => {
  let component: PutAwayProcessComponent;
  let fixture: ComponentFixture<PutAwayProcessComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PutAwayProcessComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PutAwayProcessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
