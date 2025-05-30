using ByteSizeNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSizeNotes.ChainOfResponsibility
{
    public interface INoteHandler// Interface for note handlers in the chain of responsibility pattern
    {
        INoteHandler SetNext(INoteHandler handler);
        Note Handle(Note note);
    }

    public abstract class AbstractNoteHandler : INoteHandler// Base class for note handlers in the chain of responsibility pattern
    {
        private INoteHandler _nextHandler;

        public INoteHandler SetNext(INoteHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual Note Handle(Note note)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(note);// Pass the note to the next handler in the chain
            }
            return note;
        }
    }
}
