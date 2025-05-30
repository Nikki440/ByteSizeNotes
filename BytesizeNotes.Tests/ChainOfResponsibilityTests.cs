using ByteSizeNotes.ChainOfResponsibility;
using ByteSizeNotes.Models;
using System;
using Xunit;

namespace ByteSizeNotes.Tests
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public void TitleValidationHandler_ShouldThrowOnEmptyTitle()
        {
            // Arrange
            var handler = new TitleValidationHandler();
            var note = new Note { Title = "", Content = "Valid content" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => handler.Handle(note));// Expect an exception for empty title
        }

        [Fact]
        public void TitleValidationHandler_ShouldThrowOnLongTitle()
        {
            // Arrange
            var handler = new TitleValidationHandler();
            var longTitle = new string('a', 101);
            var note = new Note { Title = longTitle, Content = "Valid content" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => handler.Handle(note));// Expect an exception for long title
        }

        [Fact]
        public void ContentFormattingHandler_ShouldAddPeriod()
        {
            // Arrange
            var handler = new ContentFormattingHandler();
            var note = new Note { Title = "Valid", Content = "No period" };

            // Act
            var result = handler.Handle(note);// Process the note through the handler

            // Assert
            Assert.EndsWith(".", result.Content);// Ensure content ends with a period
        }

        [Fact]
        public void ProfanityFilterHandler_ShouldFilterBannedWords()
        {
            // Arrange
            var handler = new ProfanityFilterHandler();
            var note = new Note { Title = "This is a test", Content = "Another test123" };// Create a note with banned words

            // Act
            var result = handler.Handle(note);// Process the note through the handler

            // Assert
            Assert.Contains("♡♡♡♡♡", result.Title);// Ensure banned words are replaced with hearts
            Assert.Contains("♡♡♡♡♡♡", result.Content);// Ensure banned words are replaced with hearts
        }
    }
}