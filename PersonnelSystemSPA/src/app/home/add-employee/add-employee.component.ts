import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { Employee } from 'src/app/shared/models/employee';
import { Manager } from 'src/app/shared/models/manager';
import { Role } from 'src/app/shared/models/role';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit, OnChanges {

  employee: Employee ={
    managerId: 0,
    lastName: '',
    firstName: '',
    id: 0,
    roles:''
  }

  allRoles: Role[] = [];
  roles: Role[] = [];
  @Input() manager!: Manager;
  @Input() managerId!: number;

  constructor(private employeeService: EmployeeService,
    private r: Router) { }

  ngOnInit(): void {
    this.employeeService.getRoles().subscribe(e =>{
      this.allRoles = e
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    
  }
  
  add(){
    this.employee.managerId = this.managerId;
    this.employee.roles = this.roles.map(e=>e.roleName).join();
    this.employeeService.add(this.employee).subscribe(e =>{
    });
  };

}
