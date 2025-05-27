using ByteSizeNotes.Models;
using ByteSizeNotes.Observer;
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
            NotifyObservers(); // Voeg deze regel toe
        }

        public void RemoveAt(int index)
        {
            var allNotes = _storageStrategy.LoadAll();
            if (index >= 0 && index < allNotes.Count)
            {
                var noteToRemove = allNotes[index];
                _storageStrategy.Delete(noteToRemove);
                NotifyObservers(); // Voeg deze regel toe
            }
        }

        public void Update(Note note)
        {
            _storageStrategy.Update(note);
            NotifyObservers(); // Voeg deze regel toe
        }

        private readonly List<INoteObserver> _observers = new List<INoteObserver>();

        public void RegisterObserver(INoteObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void UnregisterObserver(INoteObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNotesChanged();
            }
        }


    }
}
