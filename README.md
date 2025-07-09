# Employee Table
#### Тестовое задание на вакансию Junior .Net Core Разработчик компании МирТех

![](https://img.shields.io/badge/.NET-9.0-blue)
![](https://img.shields.io/badge/Angular-16.0-red)
![](https://img.shields.io/badge/MSSQL-Server-lightgrey)

Это веб-приложение для управления сотрудниками компании, реализованное с использованием ASP.NET Core 9 для бэкенда и Angular для фронтенда.
- Clean Architecture
- Domain-Driven Design (DDD)
- ASP.NET Core 9 Web API
- Angular 16
- Entity Framework Core
- MSSQL Server
- Docker
***
## Особенности архитектуры
- Четкое разделение на слои (Domain, Application, Infrastructure, Presentation)
- Использование CQRS с MediatR
- Value Objects (Salary, Department)
- Реализация Unit of Work и Repository
- Реализация Docker контейнеризации
***
## Запуск проекта

### Требования
- [Docker и Docker Compose](https://docs.docker.com/engine/install/)

### Шаги запуска
1. Клонировать репозиторий
```bash
 git clone https://github.com/ihopes0/employee-table-mirtech.git
```
2. Перейти в корневую папку
```bash
cd employee-table-mirtech  
```
3. Поднять контейнеры с помощью Docker Compose (если нет, то [установить Docker и Docker Compose](https://docs.docker.com/engine/install/)). API будет доступно по `localhost:5225`, а приложение Angular по `localhost:4200`.
```bash
docker compose up -d
```
4. Дождаться окончания поднятия контейнеров и перейти по `localhost:5225/swagger` для ознакомления с Swagger документацией, или по `localhost:4200` для использования приложения.

***
## Документация API (OpenAPI)

После запуска Web API документация доступна по адресу: http://localhost:5225/swagger

https://docs/swagger-ui.png

## Основные эндпоинты

### 1. Получение сотрудников с фильтрацией

    GET /api/employees

Параметры:

        departmentFilter (string)

        nameFilter (string)

        birthDateFilter (date)

        employmentDateFilter (date)

        salaryFilter (number)

Пример ответа:
```json
{
    "employees": [
        {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "fullName": "string",
            "birthDate": "2025-07-09T21:51:48.659Z",
            "employmentDate": "2025-07-09T21:51:48.659Z",
            "salary": 0,
            "department": "string"
        },
        {
            "id": "1fa85f64-5717-4562-b3fc-2c963f66afa6",
            "fullName": "string",
            "birthDate": "2025-07-09T21:51:48.659Z",
            "employmentDate": "2025-07-09T21:51:48.659Z",
            "salary": 0,
            "department": "string"
        }
    ]
}
```

### 2. Получение сотрудника по ID

    GET /api/employees/{id}

Пример ответа:
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "fullName": "string",
  "birthDate": "2025-07-09T22:00:25.498Z",
  "employmentDate": "2025-07-09T22:00:25.498Z",
  "salary": 0,
  "department": "string"
}
```

### 3. Создание сотрудника

    POST /api/employees

Тело запроса:
```json
{
  "fullName": "Петров Петр Петрович",
  "birthDate": "1990-11-20",
  "employmentDate": "2020-03-10",
  "salary": 45000,
  "department": "Отдел виртуализации"
}
```
Пример ответа:
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

### 4. Обновление сотрудника

    PUT /api/employees/{id}

Тело запроса:
```json
{
  "fullName": "Петров Петр Петрович",
  "birthDate": "1990-11-20",
  "employmentDate": "2020-03-10",
  "salary": 48000,
  "department": "Отдел виртуализации"
}
```
Пример ответа:
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "fullName": "Петров Петр Петрович",
  "birthDate": "1990-11-20",
  "employmentDate": "2020-03-10",
  "salary": 48000,
  "department": "Отдел виртуализации"
}
```
### 5. Удаление сотрудника

    DELETE /api/employees/{id}

***

## Дополнительно
- SQL скрипты находятся в папке src/EmployeeTable.Infrastructure/Scripts
