import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToDoListAppComponent } from './to-do-list-app.component';

describe('ToDoListAppComponent', () => {
  let component: ToDoListAppComponent;
  let fixture: ComponentFixture<ToDoListAppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToDoListAppComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToDoListAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
