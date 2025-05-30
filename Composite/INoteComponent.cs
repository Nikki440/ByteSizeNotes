using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteSizeNotes.Composite
{
    public interface INoteComponent
    {
        string Title { get; set; }
        void Display(TreeNodeCollection nodes); // treeview listview
    }

}
