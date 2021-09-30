namespace GradeBook
{
    using System;
    using System.IO;

    public class DiskBook : Book
    {
        public DiskBook(string name)
            : base(name)
        {
            this.filePath = $"./src/GradeBook/{this.Name}.txt";
        }

        private string filePath { get; set; }

        public override event GradeAddDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                using (var gradeWriter = File.AppendText(this.filePath))
                {
                    gradeWriter.WriteLine(grade);
                }

                this.GradeAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException("Valid grades must be between 0 and 100");
            }
        }

        public override Statistics GetStatistics()
        {
            var grades = Array.ConvertAll(File.ReadAllLines(this.filePath), Double.Parse);

            return new Statistics(grades);
        }
    }
}
