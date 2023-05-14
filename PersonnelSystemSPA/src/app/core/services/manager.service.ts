import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Manager } from "src/app/shared/models/manager";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private apiService: ApiService) { }

  getAllManagers(): Observable<Manager[]> {    
    return this.apiService.getAll('manager/all');
  }
}