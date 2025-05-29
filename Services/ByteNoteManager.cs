using ByteSizeNotes.Models;
using ByteSizeNotes.Observer;
using System.Collections.Generic;

namespace ByteSizeNotes.Services
{

    public class NoteManager // Singleton pattern to manage notes
    {
        private static NoteManager _instance;
        public static NoteManager Instance => _instance ?? (_instance = new NoteManager());

        private NoteStorageStrategy _storageStrategy;

        private List<Note> _cachedNotes;

        public List<Note> Notes => _cachedNotes ??= _storageStrategy.LoadAll();


        private NoteManager() // Private constructor to enforce singleton pattern
        {
            _storageStrategy = new SQLSizeNotes();
        }

 
        public void Add(Note note)
        {
            _storageStrategy.Save(note);
            RefreshCache();
            NotifyObservers(); 
            
        }

        public void RemoveAt(int index) // Remove a note by its index in the cached list
        {
            var allNotes = _storageStrategy.LoadAll();
            if (index >= 0 && index < allNotes.Count)
            {
                var noteToRemove = allNotes[index];
                _storageStrategy.Delete(noteToRemove);
                RefreshCache();
                NotifyObservers(); 
                
            }
        }

        public void Update(Note note)
        {
            _storageStrategy.Update(note); 
            RefreshCache();
            NotifyObservers();
           
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
        public void RemoveAll()
        {
            _storageStrategy.DeleteAll();
            RefreshCache();
            NotifyObservers();
        }
            
        

        private void RefreshCache()
        {
            _cachedNotes = _storageStrategy.LoadAll();
        }

    }
}
