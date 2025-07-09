// src/app/services/employee.service.ts
import { Injectable } from '@angular/core'
import { HttpClient, HttpParams } from '@angular/common/http'
import { Observable } from 'rxjs'
import { environment } from '../../environment'
import {
  Employee,
  CreateEmployeeDto,
  UpdateEmployeeDto,
} from './employee.model'

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  private apiUrl = `${environment.apiUrl}/employees`

  constructor(private http: HttpClient) {}

  getEmployees(
    departmentFilter?: string,
    nameFilter?: string,
    birthDateFilter?: Date | null,
    employmentDateFilter?: Date | null,
    salaryFilter?: number | null
  ): Observable<Employee[]> {
    let params = new HttpParams();

    if (departmentFilter) params = params.append('departmentFilter', departmentFilter);
    if (nameFilter) params = params.append('nameFilter', nameFilter);
    if (birthDateFilter) params = params.append('birthDateFilter', birthDateFilter.toISOString());
    if (employmentDateFilter) params = params.append('employmentDateFilter', employmentDateFilter.toISOString());
    if (salaryFilter) params = params.append('salaryFilter', salaryFilter.toString());

    return this.http.get<Employee[]>(this.apiUrl, { params })
  }

  getEmployee(id: string): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`)
  }

  createEmployee(employee: CreateEmployeeDto): Observable<string> {
    return this.http.post<string>(this.apiUrl, employee)
  }

  updateEmployee(id: string, employee: UpdateEmployeeDto): Observable<string> {
    return this.http.put<string>(`${this.apiUrl}/${id}`, employee)
  }

  deleteEmployee(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }
}
