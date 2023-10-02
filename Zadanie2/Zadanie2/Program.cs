using System;

struct Student
{
    public string FullName { get; set; }
    public string GroupNumber { get; set; }
    public int[] Grades { get; set; }

    public double CalculateAverageGrade()
    {
        if (Grades == null || Grades.Length == 0)
        {
            return 0;
        }

        double sum = 0;
        foreach (int grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Length;
    }

    public bool HasExcellentGrades()
    {
        if (Grades == null || Grades.Length == 0)
        {
            return false;
        }

        foreach (int grade in Grades)
        {
            if (grade < 4)
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество учащихся: ");
        if (int.TryParse(Console.ReadLine(), out int studentCount) && studentCount > 0)
        {
            Student[] students = new Student[studentCount];

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Введите информацию о студенте {i + 1}:");

                Console.Write("Фамилия и инициалы: ");
                string fullName = Console.ReadLine();

                Console.Write("Номер группы: ");
                string groupNumber = Console.ReadLine();

                int[] grades = new int[5];
                Console.WriteLine("Введите оценки студента (5 оценок):");
                for (int j = 0; j < grades.Length; j++)
                {
                    Console.Write($"Оценка {j + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 2 && grade <= 5)
                    {
                        grades[j] = grade;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите корректную оценку (от 2 до 5).");
                        j--;
                    }
                }

                students[i] = new Student { FullName = fullName, GroupNumber = groupNumber, Grades = grades };
            }

            // Сортировка студентов по возрастанию среднего балла
            Array.Sort(students, (s1, s2) => s1.CalculateAverageGrade().CompareTo(s2.CalculateAverageGrade()));

            Console.WriteLine("\nСтуденты, имеющие оценки 4 или 5:");

            foreach (Student student in students)
            {
                if (student.HasExcellentGrades())
                {
                    Console.WriteLine($"Фамилия и инициалы: {student.FullName}, Номер группы: {student.GroupNumber}");
                }
            }
        }
        else
        {
            Console.WriteLine("Ошибка! Введите корректное количество учащихся (целое положительное число).");
        }

        Console.ReadLine();
    }
}
