namespace GradeBook
{
    using System;
    using System.Collections.Generic;

    public class InMemoryBook : Book
    {
        private readonly List<double> grades;

        public InMemoryBook(string name)
            : base(name) => this.grades = new List<double>();

        public override event GradeAddDelegate GradeAdded;

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    this.AddGrade(90);
                    break;

                case 'B':
                    this.AddGrade(80);
                    break;

                case 'C':
                    this.AddGrade(70);
                    break;

                case 'D':
                    this.AddGrade(70);
                    break;

                default:
                    this.AddGrade(0);
                    break;
            }
        }

        /// <inheritdoc/>
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
                this.GradeAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException("Valid grades must be between 0 and 100");
            }
        }

        public override Statistics GetStatistics()
        {
            return new Statistics(this.grades);
        }

        public List<double> GetGradeList()
        {
            return this.grades;
        }
    }
}
