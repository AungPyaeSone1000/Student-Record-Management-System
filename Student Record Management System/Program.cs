﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Student_Record_Management_System
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
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
                        break;
                }
            } 
        }
        static void AddNewStudent()
        {
            bool condition = true;
            while (condition)
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
        }
        static void DisplayStudents()
        {
            Console.WriteLine("All Students: ");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name} || ID: {student.ID} || GPA: {student.ID}");
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
            Console.WriteLine("3. Go back.");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter student's ID");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Student studentById = students.Find(student => student.ID == id);
                        if (studentById != null)
                        {
                            Console.WriteLine($"Name: {studentById.Name} || ID: {studentById.ID} || GPA: {studentById.ID}");
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
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            

        }
        static void DeleteStudent()
        {

        }
        static void Summary()
        {

        }
    }
}
