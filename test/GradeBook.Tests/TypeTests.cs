using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            //Given
            WriteLogDelegate logDelegate = ReturnMessage;
            logDelegate += ReturnMessage;
            logDelegate += IncrementCount;
            //When
            var result = logDelegate("Hello!");
            //Then
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void ValueTypeCanBePassedByRef()
        {
            //Given
            var x = GetInt();

            //When
            SetInt(ref x);

            //Then
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //Given
            var book1 = GetBook("Book 1");
            var newName = "New Name";

            //When
            GetBookSetName(book1, newName);

            //Then
            Assert.NotEqual(book1.Name, newName);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //Given
            var book1 = GetBook("Book 1");
            var newName = "New Name";

            //When
            GetBookSetNameByRef(ref book1, newName);

            //Then
            Assert.Equal(book1.Name, newName);
        }

        private void GetBookSetNameByRef(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            //Given
            var name = "Silvio";

            //When
            name.ToUpper();
            var upper = name.ToUpper();

            //Then
            Assert.Equal("Silvio", name);
            Assert.Equal("SILVIO", upper);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //Given
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //Then
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //Given
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //Then
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
