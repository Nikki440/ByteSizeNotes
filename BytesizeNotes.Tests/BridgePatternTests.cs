using ByteSizeNotes.Bridge;
using ByteSizeNotes.Models;
using Moq;
using Xunit;

namespace ByteSizeNotes.Tests
{
    public class BridgePatternTests
    {
        [Fact]
        public void TextNote_ShouldUseStorageStrategy()
        {
            // Arrange
            var mockStorage = new Mock<NoteStorageStrategy>();
            var note = new TextNote("Test", "Content", mockStorage.Object);

            // Act
            note.Save();
            note.Delete();

            // Assert
            mockStorage.Verify(x => x.Save(It.IsAny<Note>()), Times.Once); // Verify that Save was called once
            mockStorage.Verify(x => x.Delete(It.IsAny<Note>()), Times.Once); // Verify that Delete was called once
        }
    }
}
