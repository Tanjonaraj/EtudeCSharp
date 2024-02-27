using System;
using System.Collections.Generic;

//Classe employer
public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int EmployeeId { get; set; }
    public double Salary { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID : {EmployeeId} , Name : {Name} , Position : {Position} , Salary : {Salary} ar");
    }
}

//Classe departement 
public class Department
{
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }

    public Department()
    {
        Employees = new List<Employee>();
    }
    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }
    public void DisplayEmployee()
    {
        Console.WriteLine($"Employees in {Name} department : ");
        foreach (var employee in Employees)
        {
            employee.DisplayInfo();
        }
    }
}

//Classe Tache
public class Task
{
    public string Description { get; set; }
    public Employee AssignedTo { get; set; }

}

class Program
{
    static void Main(string[] args)
    {
        //Creation d'employee
        Employee employee1 = new Employee { EmployeeId = 101, Name = "John Sins", Position = "Software Developer", Salary = 60000 };
        Employee employee2 = new Employee { EmployeeId = 102, Name = "Donovan", Position = "Project Manager", Salary = 70000 };
        Employee employee3 = new Employee { EmployeeId = 103, Name = "Mathieu", Position = "Secretary", Salary = 4000 };
        Employee employee4 = new Employee { EmployeeId = 104, Name = "Kevin", Position = "DG", Salary = 100000 };

        //Creation departement
        Department developmentDept = new Department { Name = "Developpement" };
        developmentDept.AddEmployee(employee1);
        Department directionDept = new Department { Name = "Direction" };
        directionDept.AddEmployee(employee3);
        directionDept.AddEmployee(employee4);
        Department managementDept = new Department { Name = "Management" };
        managementDept.AddEmployee(employee2);

        //Creation de tache
        Task task1 = new Task { Description = " Develop new feature", AssignedTo = employee1 };
        Task task2 = new Task { Description = "Plan Project timeline", AssignedTo = employee2 };
        Task task3 = new Task { Description = "Write a new about Company", AssignedTo = employee3 };
        Task task4 = new Task { Description = "Augmentation des employees", AssignedTo = employee4 };

        //Affichage des employees
        developmentDept.DisplayEmployee();
        directionDept.DisplayEmployee();
        managementDept.DisplayEmployee();

        //Affichage des taches assigned
        Console.WriteLine("\nTache : ");
        Console.WriteLine($"Tache1 : {task1.Description} , assignee a : {task1.AssignedTo.Name}");
        Console.WriteLine($"Tache2 : {task2.Description} , assignee a : {task2.AssignedTo.Name}");
        Console.WriteLine($"Tache1 : {task3.Description} , assignee a : {task3.AssignedTo.Name}");
        Console.WriteLine($"Tache1 : {task4.Description} , assignee a : {task4.AssignedTo.Name}");

    }
}