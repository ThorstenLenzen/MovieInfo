import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieOverviewCardComponent } from './movie-overview-card.component';

describe('MovieOverviewCardComponent', () => {
  let component: MovieOverviewCardComponent;
  let fixture: ComponentFixture<MovieOverviewCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MovieOverviewCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieOverviewCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
