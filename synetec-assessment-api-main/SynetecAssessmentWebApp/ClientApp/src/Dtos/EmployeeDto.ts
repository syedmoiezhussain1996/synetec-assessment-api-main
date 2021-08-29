import { DepartmentDto } from '../Dtos/DepartmentDto';
export class EmployeeDto {
  id: number;
  fullname: string;
  jobTitle: string;
  salary: number;
  department: DepartmentDto
}
