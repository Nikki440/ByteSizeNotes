using ByteSizeNotes.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteSizeNotes.Models
{
    public class Note : INoteComponent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public void Display(TreeNodeCollection nodes)
        {
            var node = nodes.Add(Title);
            node.Tag = this; // Bewaar referentie naar deze Note
        }

    }
}

