import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { BonusPoolComponent } from './bonusPool.component';


describe('BonusPoolComponent', () => {
  let fixture: ComponentFixture<BonusPoolComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [BonusPoolComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BonusPoolComponent);
    fixture.detectChanges();
  });

  it('should display a title', waitForAsync(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Counter');
  }));

  it('should start with count 0, then increments by 1 when clicked', waitForAsync(() => {
    const countElement = fixture.nativeElement.querySelector('strong');
    expect(countElement.textContent).toEqual('0');

    const incrementButton = fixture.nativeElement.querySelector('button');
    incrementButton.click();
    fixture.detectChanges();
    expect(countElement.textContent).toEqual('1');
  }));
});
