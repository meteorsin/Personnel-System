import { Component, OnInit } from '@angular/core';
import { Employee } from '../shared/models/employee';
import { ManagerService } from '../core/services/manager.service';
import { Manager } from '../shared/models/manager';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  managerId:number = 0;
  manager!: Manager;
  managers: Manager[] = [];
  isSelected: boolean = false;
  showList: boolean = true;
  employees: Employee[] = [];


  constructor(
    private managerService: ManagerService,
    ) {}

    ngOnInit(): void {
      this.managerService.getAllManagers().subscribe((m)=>{
        this.managers = m;
      });
    }

    onOptionsSelected(managerId: number) {      
      this.managerId = managerId;
      if (managerId) {
        this.isSelected = true;
        this.manager = this.managers.find( e => e.id == managerId)!!;
      } else {
        this.isSelected = false;
      }
    }

    onAddEmployee(){
      this.showList = false;
    }

    onShowList(){
      this.showList = true;
    }
}


