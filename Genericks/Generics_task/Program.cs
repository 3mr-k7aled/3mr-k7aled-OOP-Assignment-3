
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Store<Student> studentStore = new Store<Student>();

        studentStore.Add(new Student(1, "Amr"));
        studentStore.Add(new Student(2, "Ahmed"));
        studentStore.Add(new Student(3, "Ali"));
        studentStore.Add(new Student(4, "Omar"));
        studentStore.Add(new Student(5, "Mona"));

        Store<Course> courseStore = new Store<Course>();

        courseStore.Add(new Course(1, "C#", 500));
        courseStore.Add(new Course(2, "OOP", 700));
        courseStore.Add(new Course(3, "SQL", 600));

        Student? student = studentStore.GetById(1);
        Course? course = courseStore.GetById(2);

        Console.WriteLine($"Student: {student?.Name}");
        Console.WriteLine($"Course: {course?.Title}");

        try
        {
            studentStore.Add(new Student(1, "Duplicate"));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nPage 2 of students:");

        foreach (Student item in studentStore.GetAll().Page(2, 2))
        {
            Console.WriteLine(item.Name);
        }

        List<Course> courses = new()
        {
            new Course(1, "C#", 500),
            new Course(2, "OOP", 700),
            new Course(3, "SQL", 600)
        };

        Course? foundCourse = courses.FindById(3);
        Console.WriteLine($"\nFound course: {foundCourse?.Title}");

        IReadOnlyDictionary<int, Course> courseDictionary =
            courses.ToIdDictionary();

        Console.WriteLine($"Course from dictionary: {courseDictionary[1].Title}");

      
    }
}

