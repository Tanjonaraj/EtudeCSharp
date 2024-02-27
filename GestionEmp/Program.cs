using System;

//Classe employee represente un employe
public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"Name : {Name} , Position : {Position} , Salary : {Salary} ar");
    }
}

//Classe departement represente un departement
public class Department
{
    public string Name { get; set; }
    public Employee[] Employees { get; set; }
}

//Classe company represente une entreprise

public class Company
{
    public string Name { get; set; }
    public Department[] Departments { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        //creation d'employees
        Employee employee1 = new Employee { Name = "Tanjona", Position = "Developer C#/.Net", Salary = 1800000 };
        Employee employee2 = new Employee { Name = "Billy", Position = "Admin", Salary = 1500000 };
        Employee employee3 = new Employee { Name = "Cedrick", Position = "Developer ReactJS", Salary = 1200000 };
        Employee employee4 = new Employee { Name = "Kiady", Position = "Developer FullStack JS", Salary = 1500000 };

        //Creation d'un departement

        Department departmentDev = new Department { Name = "Dev/Data", Employees = new Employee[] { employee1, employee3, employee4 } };
        Department departmentAdmin = new Department { Name = "Administrateur", Employees = new Employee[] { employee2 } };

        //Creation d'un entreprise

        Company company = new Company
        {
            Name = "RTH.Inc",
            Departments = new Department[] { departmentDev, departmentAdmin }
        };

        //Affichage des details des employees
        foreach (var department in company.Departments)
        {
            Console.WriteLine($"Departement : {department.Name}");

            foreach (var employee in department.Employees)
            {
                employee.DisplayEmployeeDetails();
            }
        }

    }
}