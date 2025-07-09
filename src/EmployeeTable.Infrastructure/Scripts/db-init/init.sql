IF NOT EXISTS (SELECT name
               FROM sys.databases
               WHERE name = N'EmployeeTableDB')
    BEGIN
        CREATE DATABASE [EmployeeTableDB];
    END