import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from '../../services/employee.model';
import { EmployeeService } from '../../services/employee.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Subject, takeUntil } from 'rxjs';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-employee-modal',
  standalone: false,
  templateUrl: './employee-modal.component.html',
  // styleUrls: ['./employee-modal.component.css'],
})
export class EmployeeModalComponent implements OnInit {
  @Input() employeeId: string | null = null;
  @Input() mode: string;
  @Output() employeeSaved = new EventEmitter<void>();

  employee: Employee | null = null;
  loading = true;
  saving = false;
  error: string | null = null;

  constructor(
    public activeModal: NgbActiveModal,
    private employeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    if (this.employeeId) {
      this.loadEmployee();
    } else {
      this.employee = {
        id: 'null',
        fullName: '',
        birthDate: new Date(),
        employmentDate: new Date(),
        salary: 0,
        department: '',
      };
      this.loading = false;
    }
  }

  loadEmployee(): void {
    if (!this.employeeId) return;

    this.employeeService.getEmployee(this.employeeId).subscribe(
      (employee) => {
        this.employee = employee;
        this.loading = false;
      },
      (error) => {
        this.error = 'Не удалось загрузить сотрудника';
        this.loading = false;
      }
    );
  }

  private destroy$ = new Subject<void>();

  onFormSubmit(employeeData: any): void {
    this.saving = true;
    this.error = null;

    const saveAction = this.mode == 'update'
      ? this.employeeService.updateEmployee(employeeData.id, employeeData)
      : this.employeeService.createEmployee(employeeData);

    const hasId = Boolean(employeeData.id);

    saveAction
      .pipe(
        takeUntil(this.destroy$),
        finalize<string>(() => (this.saving = false))
      )
      .subscribe({
        next: () => {
          this.employeeSaved.emit();
          this.activeModal.close();
        },
        error: () => {
          this.error = hasId
            ? 'Не удалось обновить пользователя'
            : 'Не удалось создать пользователя';
        },
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
