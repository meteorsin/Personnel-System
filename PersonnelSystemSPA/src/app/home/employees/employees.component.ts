import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { EmployeeService } from '../../core/services/employee.service';
import { Employee } from '../../shared/models/employee';
import { Manager } from 'src/app/shared/models/manager';

@Component({
  selector: 'app-employee',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit, OnChanges {

  employees: Employee[] | undefined;
  managerName:string = '';
  @Input() manager!: Manager;
  @Input() managerId: number = 0;
  isSelected: boolean = false;

  constructor(private employeeService: EmployeeService) {}
  
  ngOnInit(): void {
  }

  ngOnChanges(): void{
    
    console.log(this.managerId)
    if (this.managerId){
      this.getEmployees();
    } else {
      this.employees = undefined;
    }
  }

  getEmployees(){
    this.employeeService.getEmployeesByManagerId(this.manager.id).subscribe((e) => {
      this.employees = e.length > 0? e : [];
  });
  }
}
