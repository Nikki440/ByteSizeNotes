using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSizeNotes.Observer
{
    public interface INoteObserver
    {
        void OnNotesChanged();
    }

}
