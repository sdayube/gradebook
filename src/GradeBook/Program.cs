namespace GradeBook
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            IBook book = new InMemoryBook("Silvio's Gradebook");
            book.GradeAdded += OnGradeAdded;

            Console.WriteLine("Add the grades for the student.");
            Console.WriteLine("To finish adding grades send 'Q' as an input.");
            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine($"For the book named {book.Name}");
            book.PrintStatistics(stats);
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                var grade = Console.ReadLine().ToLower();

                if (grade.Equals("q"))
                {
                    break;
                }

                try
                {
                    book.AddGrade(double.Parse(grade));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The grade must be a valid number");
                    Console.WriteLine("To finish adding grades send 'Q' as an input.");
                }
            }
        }

        private static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
