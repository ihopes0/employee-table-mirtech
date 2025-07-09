// src/app/components/employee-list/employee-list.component.ts
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../services/employee.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeModalComponent } from '../EmployeeModalComponent/employee-modal.component';
import { ConfirmModalComponent } from '../ConfirmModalComponent/confirm-modal.component';

@Component({
  selector: 'app-employee-list',
  standalone: false,
  templateUrl: './employee-list.component.html',
  // styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  filteredEmployees: Employee[] = [];
  loading = true;
  error: string | null = null;

  filters = {
    department: '',
    fullName: '',
    birthDate: null as Date | null,
    employmentDate: null as Date | null,
    salary: null as number | null,
  };

  sortField = 'fullName';
  sortDirection: 'asc' | 'desc' = 'asc';

  constructor(
    private employeeService: EmployeeService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.loading = true;
    this.error = null;

    // Загрузка сотрудников
    this.employeeService
      .getEmployees(
        this.filters.department,
        this.filters.fullName,
        this.filters.birthDate,
        this.filters.employmentDate,
        this.filters.salary
      )
      .subscribe({
        next: (data: any) => {
          this.employees = data['employees'];
          this.filteredEmployees = [...this.employees];
          this.applySorting();
          this.loading = false;
        },
        error: (err) => {
          this.error = 'Не удалось загрузить сотрудников';
          this.loading = false;
        },
      });
  }

  applyFilters(): void {
    this.filteredEmployees = this.employees.filter((emp) => {
      return (
        (!this.filters.department ||
          emp.department.toLowerCase().includes(this.filters.department.toLowerCase())) &&
        (!this.filters.fullName ||
          emp.fullName
            .toLowerCase()
            .includes(this.filters.fullName.toLowerCase())) &&
        (!this.filters.birthDate ||
          new Date(emp.birthDate).toDateString() ===
            this.filters.birthDate.toDateString()) &&
        (!this.filters.employmentDate ||
          new Date(emp.employmentDate).toDateString() ===
            this.filters.employmentDate.toDateString()) &&
        (!this.filters.salary || emp.salary === this.filters.salary)
      );
    });
  }

  sort(field: string): void {
    if (this.sortField === field) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortField = field;
      this.sortDirection = 'asc';
    }
    this.applySorting();
  }

  private applySorting(): void {
    this.filteredEmployees.sort((a, b) => {
      let valueA = a[this.sortField as keyof Employee];
      let valueB = b[this.sortField as keyof Employee];

      if (valueA instanceof Date) valueA = valueA.getTime();
      if (valueB instanceof Date) valueB = valueB.getTime();

      if (typeof valueA === 'string') valueA = valueA.toLowerCase();
      if (typeof valueB === 'string') valueB = valueB.toLowerCase();

      if (valueA < valueB) return this.sortDirection === 'asc' ? -1 : 1;
      if (valueA > valueB) return this.sortDirection === 'asc' ? 1 : -1;
      return 0;
    });
  }

  openCreateModal(): void {
    const modalRef = this.modalService.open(EmployeeModalComponent, {
      size: 'lg',
    });
    modalRef.componentInstance.employeeId = null;
    modalRef.componentInstance.mode = 'create';
    modalRef.componentInstance.employeeSaved.subscribe(() => {
      this.loadData();
    });
  }

  openEditModal(employee: Employee): void {
    const modalRef = this.modalService.open(EmployeeModalComponent, {
      size: 'lg',
    });
    modalRef.componentInstance.employeeId = employee.id;
    modalRef.componentInstance.mode = 'update';
    modalRef.componentInstance.employeeSaved.subscribe(() => {
      this.loadData();
    });
  }

  openDeleteModal(employee: Employee): void {
    const modalRef = this.modalService.open(ConfirmModalComponent);
    modalRef.componentInstance.title = 'Подтверждение удаления';
    modalRef.componentInstance.message = `Вы точно хотите удалить ${employee.fullName}?`;

    modalRef.result.then(
      () => this.deleteEmployee(employee.id),
      () => {} // Отмена удаления
    );
  }

  private deleteEmployee(id: string): void {
    this.employeeService.deleteEmployee(id).subscribe({
      next: () => {
        this.loadData();
      },
      error: () => {
        this.error = 'Не удалось удалить сотрудника';
      },
    });
  }
}
