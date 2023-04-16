using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Student_Record_Management_System
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            LoadData();
            bool condition = true;
            while (condition)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add new student");
                Console.WriteLine("2. Display all students");
                Console.WriteLine("3. Search student");
                Console.WriteLine("4. Delete student");
                Console.WriteLine("5. Display summary");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your option from 1 to 6: ");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AddNewStudent();
                            break;
                        case 2:
                            Console.Clear();
                            DisplayStudents();
                            break;
                        case 3:
                            Console.Clear();
                            SearchStudent();
                            break;
                        case 4:
                            Console.Clear();
                            DeleteStudent();
                            break;
                        case 5:
                            Console.Clear();
                            Summary();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Exitiing Program.");
                            condition = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Input. Please try again.");
                            Thread.Sleep(1200);
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please try again");
                    Thread.Sleep(1200);
                }
                SaveDataToTextFile();
            } 
        }
        static void AddNewStudent()
        {
            bool condition = true;
            while (condition)
            {
                try
                {
                    Console.Write("Enter student's name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter student's ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter student's GPA: ");
                    double gpa = Convert.ToDouble(Console.ReadLine());

                    Student student = new Student
                    {
                        Name = name,
                        ID = id,
                        GPA = gpa
                    };
                    students.Add(student);
                    Console.Clear();
                    char ans;
                    do
                    {
                        Console.WriteLine("Do you wish to add more student?(Y/N)");
                        ans = Convert.ToChar(Console.ReadLine());
                        if (Char.ToUpper(ans) != 'N' && Char.ToUpper(ans) != 'Y')
                        {
                            Console.WriteLine("Invalid Input. Please try again.");
                            Thread.Sleep(1200);
                            Console.Clear();
                        }

                    } while (Char.ToUpper(ans) != 'N' && Char.ToUpper(ans) != 'Y');
                    if (Char.ToUpper(ans) == 'N')
                    {
                        Console.Clear();
                        condition = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Input. Please try again.");
                    Thread.Sleep(1200);
                    Console.Clear();
                }
            }
        }
        static void DisplayStudents()
        {
            Console.WriteLine("All Students: ");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name} || ID: {student.ID} || GPA: {student.GPA}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

        }
        static void SearchStudent()
        {
            Console.WriteLine("Search the student by:");
            Console.WriteLine("1. ID.");
            Console.WriteLine("2. Name. ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter student's ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    List<Student> studentById = students.FindAll(student => student.ID == id);
                    if (studentById != null)
                    {
                        foreach (Student student in studentById)
                        {
                            Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, GPA: {student.GPA}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is not student with such ID.");
                    }
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("Enter student's Name.");
                    string name = Console.ReadLine();
                    List<Student> studentsName = students.FindAll(student => student.Name.Contains(name));
                    if (studentsName != null)
                    {
                        foreach (Student student in studentsName)
                        {
                            Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, GPA: {student.GPA}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is not student with such Name.");
                    }
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        

        }
        static void DeleteStudent()
        {

            Console.WriteLine("Delete the student by:");
            Console.WriteLine("1. ID.");
            Console.WriteLine("2. Name. ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter student's ID");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Student studentToDelete = students.Find(student => student.ID == id);
                    if (studentToDelete == null)
                    {
                        Console.WriteLine("Student not found.");

                    }
                    else
                    {
                        while (studentToDelete != null)
                        {
                            students.Remove(studentToDelete);
                            studentToDelete = students.Find(student => student.ID == id);
                        }
                        Console.WriteLine("Deletion done.");
                    }

                    break;
                case 2:
                    Console.WriteLine("Enter student's Name");
                    string name = Console.ReadLine();
                    Student studentToDelete1 = students.Find(student => student.Name == name);
                    if (studentToDelete1 == null)
                    {
                        Console.WriteLine("Student not found.");

                    }
                    else
                    {
                        while (studentToDelete1 != null)
                        {
                            students.Remove(studentToDelete1);
                            studentToDelete1 = students.Find(student => student.Name == name);
                        }
                        Console.WriteLine("Deletion done.");
                    }
                    break;
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        static void Summary()
        {
            int numberOfStudent = students.Count;
            Console.WriteLine($"Number of students is {numberOfStudent}.");
            double maxGPA = students[0].GPA;
            double minGPA = students[0].GPA;
            foreach (var student in students)
            {
                if (student.GPA > maxGPA)
                {
                    maxGPA = student.GPA; 
                }
                if (student.GPA < minGPA)
                { 
                    minGPA = student.GPA; 
                }
            }
            Console.WriteLine($"The highest GPA is {maxGPA}.");
            Console.WriteLine($"The lowest GPA is {minGPA}.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

        }
        static void SaveDataToTextFile()
        {
            string fileName = "ListOfStudents.txt";
            StreamWriter writer = new StreamWriter(fileName);
            foreach (Student student in students)
            {
                writer.WriteLine(student.Name);
                writer.WriteLine(student.ID);
                writer.WriteLine(student.GPA);
            }
            writer.Flush();

        }
        static void LoadData()
        {
            string fileName = "ListOfStudents.txt";
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string name;
                while ((name = reader.ReadLine()) != null)
                {
                    int id = int.Parse(reader.ReadLine());
                    double gpa = Convert.ToDouble(reader.ReadLine());
                    students.Add(new Student
                    {
                        Name = name,
                        ID = id,
                        GPA = gpa
                    });
                }
                
                reader.Close();
            }
        }
    }
}
