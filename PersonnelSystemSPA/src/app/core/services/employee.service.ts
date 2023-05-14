import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Employee } from "src/app/shared/models/employee";
import { Role } from 'src/app/shared/models/role';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private apiService: ApiService) { }

  getEmployeesByManagerId(id:number){
    return this.apiService.getByForeignKey('manager',id);
  }

  add(employee: Employee): Observable<any> {
    return this.apiService.create('employee/addEmployee', employee);
  }

  getRoles() {
    return this.apiService.getAll('employee/roles');
  }
}