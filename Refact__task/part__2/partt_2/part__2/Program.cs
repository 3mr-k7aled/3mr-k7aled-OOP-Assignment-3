
using RefactoringLab.Part_2.BlockedUsers;
using RefactoringLab.Part_2.Students;

Console.WriteLine(" Students (1_000_000) ");

var printed = 0;

foreach (var student in StudentCatalog.GetAllStudents())
{
    Console.WriteLine($"{student.Id}: {student.Name}");

    printed++;

    if (printed == 3)
        break;
}

Console.WriteLine($"printed={printed}");