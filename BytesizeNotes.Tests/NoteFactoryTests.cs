using ByteSizeNotes.Factory;
using ByteSizeNotes.Models;
using System;
using Xunit;

namespace ByteSizeNotes.Tests
{
    public class NoteFactoryTests
    {
        [Fact]
        public void Create_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var title = "Test Title";
            var content = "Test Content";

            // Act
            var note = NoteFactory.Create(title, content);

            // Assert
            Assert.Equal(title, note.Title);
            Assert.Equal(content, note.Content);
            Assert.True(DateTime.Now.Subtract(note.Created).TotalSeconds < 1); // Check if Created is set to now
        }

        [Fact]
        public void CreateEmpty_ShouldReturnDefaultNote()
        {
            // Act
            var note = NoteFactory.CreateEmpty();

            // Assert
            Assert.Equal("Nieuwe notitie", note.Title);// Default title
            Assert.Equal("Hier kan je tekst typen", note.Content);// Default content
            Assert.True(DateTime.Now.Subtract(note.Created).TotalSeconds < 1); // Check if Created is set to now
        }
    }
}
