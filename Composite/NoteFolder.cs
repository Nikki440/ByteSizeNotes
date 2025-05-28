using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteSizeNotes.Composite
{
    public class NoteFolder : INoteComponent
    {
        public string Title { get; set; }
        public List<INoteComponent> Children { get; private set; } = new();

        public void Add(INoteComponent component)
        {
            Children.Add(component);
        }

        public void Remove(INoteComponent component)
        {
            Children.Remove(component);
        }

        public void Display(TreeNodeCollection nodes)
        {
            var folderNode = nodes.Add(Title);
            folderNode.Tag = this; 

            foreach (var child in Children)
            {
                child.Display(folderNode.Nodes);
            }
        }
    }

}
