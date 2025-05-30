using ByteSizeNotes.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteSizeNotes.Models
{
    public class Note : INoteComponent, ICloneable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        // Existing INoteComponent implementation
        public void Display(TreeNodeCollection nodes)
        {
            var node = nodes.Add(Title);
            node.Tag = this;
        }

        // ICloneable implementation
        public object Clone()
        {
            return new Note
            {
                Id = 0, // Reset ID for new database entry
                Title = this.Title,
                Content = this.Content,
                Created = DateTime.Now // Fresh timestamp
            };
        }

        // Convenience method
        public Note CreateClone()
        {
            var clone = (Note)this.Clone();
            clone.Title = $"Copy of {this.Title}";
            return clone;
        }
    }
}

