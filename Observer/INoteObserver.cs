using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSizeNotes.Observer
{
    public interface INoteObserver // Observer Pattern to notify changes in notes
    {
        void OnNotesChanged();
    }

}
