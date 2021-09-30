// <copyright file="IBook.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GradeBook
{
    /// <summary>Sets the interface for the Book type.</summary>
    public interface IBook
    {
        /// <summary>Is triggered whenever a grade is added</summary>
        event GradeAddDelegate GradeAdded;

        /// <summary>Gets the name of the GradeBook instance.</summary>
        string Name { get; }

        /// <summary>Adds a grade to the GradeBook.</summary>
        /// <param name="grade">The grade that will be added.</param>
        void AddGrade(double grade);

        /// <summary>Returns the gradebook statistics.</summary>
        /// <returns>Object that contains fields with all statistics.</returns>
        Statistics GetStatistics();

        /// <summary>Prints the statistics to teh console.</summary>
        /// <param name="stats">
        /// The object that contains all statistics to be printed.
        /// </param>
        void PrintStatistics(Statistics stats);
    }
}
