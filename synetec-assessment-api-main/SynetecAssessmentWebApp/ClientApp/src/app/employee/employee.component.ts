import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeDto } from '../../Dtos/EmployeeDto';
import { DepartmentDto } from '../../Dtos/DepartmentDto';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { BonusPoolComponent } from '../bonusPool/bonusPool.component';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
  public employees: EmployeeDto[];
  dtOptions: DataTables.Settings = {};
  department: DepartmentDto;



  constructor(
    http: HttpClient,
    @Inject('API_URL') baseUrl: string,
    private modalService: NgbModal
  ) {
    http.get<EmployeeDto[]>(baseUrl + 'api/Employee').subscribe(result => {
      console.log(result);
      this.employees = result;

    }, error => console.error(error));
  }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      processing: true
    };
  }
  openBonusPoolModal(employee: EmployeeDto) {
    const modalRef = this.modalService.open(BonusPoolComponent,
      {
        scrollable: true,
        windowClass: 'myCustomModalClass',
        size:'xl'
        // keyboard: false,
        // backdrop: 'static'
      });

    //let data = {
    //  prop1: 'Some Data',
    //  prop2: 'From Parent Component',
    //  prop3: 'This Can be anything'
    //}

    modalRef.componentInstance.fromParent = employee;
    modalRef.result.then((result) => {
      console.log(result);
    }, (reason) => {
    });
  }
  openModal(content: any, department: DepartmentDto) {
    this.modalService.open(content);
    this.department = department;

  }
  closeModal(sendData) {
    this.modalService.dismissAll();
  }
}


