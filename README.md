# Payroll Service

## Description
Payroll Service is a simple ASP.NET Web Service designed to calculate salaries for different types of employees including full-time, part-time, contract, and freelance workers. It exposes methods to compute salaries based on input parameters such as hours worked, rates, milestones, and task counts.

## Features
- Calculate full-time employee salary based on annual salary and logged hours
- Calculate part-time employee salary with overtime warning
- Calculate contract employee salary using fixed project fee or milestone fees
- Calculate freelance salary based on task categories, counts, and rates

## Technologies Used
- Language: C#
- Framework: ASP.NET Web Services (.asmx)
- Development Environment: Visual Studio (recommended)

## Methods Overview

### CalculateFullTimeSalary
```csharp
double CalculateFullTimeSalary(double annualSalary, int hoursPerWeek, int weeksPerYear, int loggedHours)
