using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.Highest, 1);
            Assert.Equal(77.3, result.Lowest, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void InvalidValuesAreNotAccepted()
        {
            //Given
            var book = new InMemoryBook("");

            //When
            double[] allValues = { 100, 50, 0 };

            foreach (var value in allValues)
            {
                book.AddGrade(value);
            }

            var allGrades = book.GetGradeList();
            var validGrades = new List<double>() { 100, 50, 0 };

            //Then
            Assert.Equal(validGrades, allGrades);
            Assert.Throws<ArgumentException>(() => book.AddGrade(105));
            Assert.Throws<ArgumentException>(() => book.AddGrade(-5));
        }
    }
}
