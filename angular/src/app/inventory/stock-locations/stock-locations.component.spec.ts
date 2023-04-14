import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockLocationsComponent } from './stock-locations.component';

describe('StockLocationsComponent', () => {
  let component: StockLocationsComponent;
  let fixture: ComponentFixture<StockLocationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StockLocationsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StockLocationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
