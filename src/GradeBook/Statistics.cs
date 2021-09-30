namespace GradeBook
{
    using System.Collections.Generic;
    using System.Linq;

    public class Statistics
    {
        public Statistics(IEnumerable<double> grades)
        {
            Average = grades.Average();
            Highest = grades.Max();
            Lowest = grades.Min();
            Letter = grades.Average() switch
            {
                var avg when avg >= 90.0 => 'A',
                var avg when avg >= 80.0 => 'B',
                var avg when avg >= 70.0 => 'C',
                var avg when avg >= 60.0 => 'D',
                _ => 'F',
            };
        }

        public double Average { get; set; }

        public double Highest { get; set; }

        public double Lowest { get; set; }

        public char Letter { get; set; }
    }
}