"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var bonusPool_component_1 = require("./bonusPool.component");
describe('BonusPoolComponent', function () {
    var fixture;
    beforeEach((0, testing_1.waitForAsync)(function () {
        testing_1.TestBed.configureTestingModule({
            declarations: [bonusPool_component_1.BonusPoolComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = testing_1.TestBed.createComponent(bonusPool_component_1.BonusPoolComponent);
        fixture.detectChanges();
    });
    it('should display a title', (0, testing_1.waitForAsync)(function () {
        var titleText = fixture.nativeElement.querySelector('h1').textContent;
        expect(titleText).toEqual('Counter');
    }));
    it('should start with count 0, then increments by 1 when clicked', (0, testing_1.waitForAsync)(function () {
        var countElement = fixture.nativeElement.querySelector('strong');
        expect(countElement.textContent).toEqual('0');
        var incrementButton = fixture.nativeElement.querySelector('button');
        incrementButton.click();
        fixture.detectChanges();
        expect(countElement.textContent).toEqual('1');
    }));
});
//# sourceMappingURL=bonusPool.component.spec.js.map