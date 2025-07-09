// src/app/components/employee-form/employee-form.component.ts
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee, CreateEmployeeDto, UpdateEmployeeDto } from '../../services/employee.model';

@Component({
  selector: 'app-employee-form',
  standalone: false,
  templateUrl: './employee-form.component.html',
  // styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  @Input() employee: Employee | null = null;
  @Input() mode: string;
  @Output() formSubmit = new EventEmitter<CreateEmployeeDto | UpdateEmployeeDto>();
  @Output() cancel = new EventEmitter<void>();
  
  form: FormGroup;
  minBirthDate: Date;
  maxBirthDate: Date;
  minEmploymentDate: Date;

  constructor(
    private fb: FormBuilder,
  ) {
    // Рассчитываем допустимые даты
    const today = new Date();
    this.minBirthDate = new Date(today.getFullYear() - 70, today.getMonth(), today.getDate());
    this.maxBirthDate = new Date(today.getFullYear() - 18, today.getMonth(), today.getDate());
    this.minEmploymentDate = new Date(2000, 0, 1);
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(): void {
    this.form = this.fb.group({
      id: [this.employee?.id || 'null'],
      fullName: [
        this.employee?.fullName || '', 
        [Validators.required, Validators.maxLength(100)]
      ],
      birthDate: [
        this.employee?.birthDate || null, 
        [Validators.required]
      ],
      employmentDate: [
        this.employee?.employmentDate || null, 
        [Validators.required]
      ],
      salary: [
        this.employee?.salary || 0, 
        [Validators.required, Validators.min(0), Validators.max(10000000)]
      ],
      department: [
        this.employee?.department || '', 
        [Validators.required]
      ]
    });
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    
    const formValue = this.form.value;
    if (formValue.id) {
      this.formSubmit.emit(formValue as UpdateEmployeeDto);
    } else {
      this.formSubmit.emit(formValue as CreateEmployeeDto);
    }
  }

  onCancel(): void {
    this.cancel.emit();
  }
}