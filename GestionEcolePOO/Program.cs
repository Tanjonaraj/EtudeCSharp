using System;
using System.Collections.Generic;

//Classe Student pour representer un erudiant

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name : {Name} , Age : {Age} , Grade : {Grade}");
    }
}

//Classe Teacher pour representer un enseignant 

public class Teacher
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public int ExperienceYears { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name : {Name} , Subject : {Subject} , Experience Years : {ExperienceYears}");
    }
}

public class professeur
{
    public List<Teacher> prof { get; set; }
    public professeur()
    {
        prof = new List<Teacher>();
    }
    public void DisplayInfo()
    {
        Console.WriteLine("Les details concernant les profs : ");

        foreach (var profs in prof)
        {
            Console.WriteLine($"-{profs.Name} {profs.Subject} {profs.ExperienceYears}");

        }
    }
}

//Classe Course pour representer un cours

public class Course
{
    public string Name { get; set; }
    public Teacher Instructor { get; set; }
    public List<Student> Students { get; set; }

    public Course()
    {
        Students = new List<Student>();
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Course : {Name} , Instructor : {Instructor.Name}");
        Console.WriteLine("Students enrolled : ");
        foreach (var student in Students)
        {
            Console.WriteLine($"-{student.Name}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        //creation d'enseignant
        Teacher teacher1 = new Teacher { Name = "Mr.Smith", Subject = "Math", ExperienceYears = 10 };
        Teacher teacher2 = new Teacher { Name = "Mlle.Kanto", Subject = "Science", ExperienceYears = 8 };


        //creation d'etudiant
        Student student1 = new Student { Name = "John", Age = 10, Grade = "4th" };
        Student student2 = new Student { Name = "Kevin", Age = 15, Grade = "12th" };
        Student student3 = new Student { Name = "koko", Age = 13, Grade = "8th" };

        //Creation de cours
        Course mathCourse = new Course { Name = "Mathematique", Instructor = teacher1 };
        mathCourse.Students.Add(student1);
        mathCourse.Students.Add(student2);

        Course scienceCourse = new Course { Name = "Science", Instructor = teacher2 };
        scienceCourse.Students.Add(student2);
        scienceCourse.Students.Add(student3);

        professeur detailProf = new professeur { };
        detailProf.prof.Add(teacher1);
        detailProf.prof.Add(teacher2);


        //Affichage des informations sur les cours
        Console.WriteLine("Math cours information : ");
        mathCourse.DisplayInfo();

        Console.WriteLine("Science cours information : ");
        scienceCourse.DisplayInfo();

        Console.WriteLine("Information du professeur : ");
        detailProf.DisplayInfo();
    }
}