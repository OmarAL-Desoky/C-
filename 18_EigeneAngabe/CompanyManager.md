# Company Manager

## Implement the following classes:

### Company

workers: A list of workers working at the company.
<br>
WorkerCount: the amount of workers at the company.
<br>
TotalSalaryToPay: Calculates the total amount of money needed to pay all employees.
<br>
HireWorker(): Hires a worker to the company.
<br>
FireWorker(): Fires worker from company.
<br>
SortWorkersByCatalogNumber(): Sorts an array of workers by ther catalog number.
<br>

### SalaryComparer

hours: the amount of working hours to compare.
<br>
salaryForWorkingHoursComparer(): Makes comparison of salary for a set amount of hours possible.
<br>
Compare(): compares two employees by their salary.

### Worker

workedHours: amount of hours worked.
<br>
catalogNumber: A number that defines a worker.
<br>
Worker: the constructor.
<br>
CompareTo: compares to a different worker.
<br>
Equals: self explanitory.
<br>
GetHashCode: gets hashcode.
<br>
Work(): starts work for a set amount of numbers, and return the amount of total worked hours.
<br>
CalculateSalary: calculates salary.
<br>
IsValidCatalogNumber(): checks if the catalog number is above 0 and below 1000.

### Programmer

CoffeePerHour: the amount of coffees needed per hour.
<br>
CalculateSalary: calculates salary and substract 1,5€ per coffee per hour.

### Acountant

CalculateSalary(): calculates salary based on worked hours.

### SysAdmin

taskCount: Amount of tasks, complete and incomplete.
<br>
helpedWorkers: Amount of completed tasks.
<br>
CalculateSalary(): calculates salary based on worked hours.
<br>
UpdateSystem(): adds 10€ to baseSalary.
<br>
HelpWorkers(): adds 20€ to baseSalary for every incomplete task.