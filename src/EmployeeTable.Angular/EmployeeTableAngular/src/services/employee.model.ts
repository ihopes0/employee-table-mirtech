export interface Employee {
  id: string
  fullName: string
  birthDate: Date
  employmentDate: Date
  salary: number
  department: string
}

export interface CreateEmployeeDto {
  fullName: string
  birthDate: Date
  employmentDate: Date
  salary: number
  department: string
}

export interface UpdateEmployeeDto {
  id: string
  fullName: string
  birthDate: Date
  employmentDate: Date
  salary: number
  department: string
}
