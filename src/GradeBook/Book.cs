namespace GradeBook
{
    using System;

    /// <summary>
    /// Defines an abstract <see cref="Book"/> class.
    /// </summary>
    public abstract class Book : NamedObject, IBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="name">Sets the name of the <see cref="Book"/> instance.</param>
        protected Book(string name)
            : base(name)
        {
        }

        /// <inheritdoc/>
        public abstract event GradeAddDelegate GradeAdded;

        /// <inheritdoc/>
        public abstract void AddGrade(double grade);

        /// <inheritdoc/>
        public abstract Statistics GetStatistics();

        /// <inheritdoc/>
        public void PrintStatistics(Statistics stats)
        {
            Console.WriteLine($"The lowest grade is {stats.Lowest}");
            Console.WriteLine($"The highest grade is {stats.Highest}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
