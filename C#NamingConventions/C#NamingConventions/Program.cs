// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;
using System;

namespace Day1Tasks
{
    class Program
    {
        // Task 1 Improving the Naming Conventions of the Provided
        int Total_marks = 90;
        string studentNAME = "Ali";
        void get_student_data()
        {
            Console.WriteLine("Fetching data...");
        }

        //Improved Code
        int totalMarks = 90;
        string studentName = "Ali";
        void GetStudentData()
        {
            Console.WriteLine("Fetching data...");
        }

        // Task 2 Format the following code according to C# style guide.
        class person
        {
            public string name;
            public void sayhello()
            {
                Console.WriteLine("hello " + name);
            }
        }

        // Improved Formatting of code.
        class Person
        {
            public string studentName;
            public Person(string studentName)
            {
                this.studentName = studentName;
            }
            public void SayHello()
            {
                Console.WriteLine("Hello " + studentName);
            }
        }

        // Task 3 Create a simple class with fields
        // a constructor, and one method.
        /// <summary>
        /// This Class is of Student information involving fields name,age,marks and hostelide parameter.
        /// Also it had Constructor for Initialisation and Method.
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="age"></param>
        /// <param name="isHostelide"></param>
        /// <param name="intermediateMarks"></param>
        class StudentInformation(string studentName, int age, bool isHostelide, int intermediateMarks)
        {
            public string StudentName { get; } = studentName;
            public int Age { get; } = age;
            public bool IsHostelide { get; } = isHostelide;
            public int IntermediateMarks { get; } = intermediateMarks;
            public int CalculateFees(bool isHostelide)
            {
                int studentFees = 10000;
                if (isHostelide)
                {
                    studentFees = studentFees * 2000;
                    return studentFees;
                }

                else
                {
                    studentFees = studentFees * 1000;
                    return studentFees;
                }
            }
        }

        // Task 3 Program to Calculate Area
        int CalculateArea(int length, int width)
        {
            int area = length * width;
            return area;
        }

    }
}