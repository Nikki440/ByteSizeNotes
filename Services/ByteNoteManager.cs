using ByteSizeNotes.Models;
using System.Collections.Generic;

namespace ByteSizeNotes.Services
{

    /// Singleton 

    public class NoteManager
    {
        private static NoteManager _instance;
        public static NoteManager Instance => _instance ?? (_instance = new NoteManager());

        private NoteStorageStrategy _storageStrategy;

        private NoteManager()
        {
            _storageStrategy = new SQLSizeNotes();
        }

        public List<Note> Notes => _storageStrategy.LoadAll();

        public void Add(Note note)
        {
            _storageStrategy.Save(note);
        }

        public void RemoveAt(int index)
        {
            var allNotes = _storageStrategy.LoadAll();
            if (index >= 0 && index < allNotes.Count)
            {
                var noteToRemove = allNotes[index];
                _storageStrategy.Delete(noteToRemove);
            }
        }

        public void Update(Note note)
        {
            _storageStrategy.Update(note); 
        }
    }
}
