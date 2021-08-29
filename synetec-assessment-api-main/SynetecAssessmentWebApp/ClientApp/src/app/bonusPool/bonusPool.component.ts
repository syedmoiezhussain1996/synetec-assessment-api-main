import { Component, Inject, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CalculateBonusDto } from '../../Dtos/CalculateBonusDto';
import { EmployeeDto } from '../../Dtos/EmployeeDto';
import { HttpClient } from '@angular/common/http';
import { BonusPoolCalculatorResultDto } from '../../Dtos/BonusPoolCalculatorResultDto';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-bonusPool-component',
  templateUrl: './bonusPool.component.html'
})
export class BonusPoolComponent {

  bonusResult: BonusPoolCalculatorResultDto;

  bonusDto: CalculateBonusDto =
    {
      TotalBonusPoolAmount: 0,
      SelectedEmployeeId: 0
    };

  _fromParent: EmployeeDto;
  get fromParent(): EmployeeDto {
    return this._fromParent;
  }
  @Input() set fromParent(value: EmployeeDto) {
    this._fromParent = value;
    this.bonusDto.SelectedEmployeeId = value.id;
  }


  constructor(
    public activeModal: NgbActiveModal,
    public http: HttpClient,
    private toastr: ToastrService,
    @Inject('API_URL') public baseUrl: string)
  {}

  closeModal(sendData) {
    this.activeModal.close(sendData);
  }

  CalculateBonusAmount() {
    this.http.post<BonusPoolCalculatorResultDto>(this.baseUrl + 'api/BonusPool', this.bonusDto).subscribe(result => {
      console.log(result);
      this.bonusResult = result;
      console.log(this.bonusResult);
    }, error => {
      this.toastr.error('Invalid Value!', 'Error!');
      console.error(error)
    });
  }

}
