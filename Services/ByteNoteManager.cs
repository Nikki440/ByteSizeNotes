using ByteSizeNotes.Models;
using System.Collections.Generic;

namespace ByteSizeNotes.Services
{
    public class NoteManager
    {
        private static NoteManager _instance;
        public static NoteManager Instance => _instance ?? (_instance = new NoteManager());

        private List<Note> _notes = new List<Note>();
        public List<Note> Notes => _notes;

        private NoteManager() { }

        public void Add(Note note)
        {
            _notes.Add(note);
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _notes.Count)
            {
                _notes.RemoveAt(index);
            }
        }
    }
}