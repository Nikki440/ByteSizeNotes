using ByteSizeNotes.Composite;
using System.Windows.Forms;
using Xunit;

namespace ByteSizeNotes.Tests
{
    public class CompositePatternTests
    {
        [Fact]
        public void NoteFolder_ShouldAddAndDisplayChildren()
        {
            // Arrange
            var folder = new NoteFolder { Title = "Parent" };
            var childFolder = new NoteFolder { Title = "Child" };
            using var treeView = new TreeView(); // Create real TreeView
            var treeNodes = treeView.Nodes; // Get its Nodes collection

            // Act
            folder.Add(childFolder);
            folder.Display(treeNodes);// Display the folder in the TreeView

            // Assert
            Assert.Single(folder.Children);// Ensure the child folder is added
            Assert.Equal("Parent", treeNodes[0].Text);// Ensure the parent folder is added correctly
            Assert.Equal("Child", treeNodes[0].Nodes[0].Text);// Ensure the child folder is added correctly
        }
    }
}