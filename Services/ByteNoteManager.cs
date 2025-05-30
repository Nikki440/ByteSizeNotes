using ByteSizeNotes.ChainOfResponsibility;
using ByteSizeNotes.Models;
using ByteSizeNotes.Observer;
using System;
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
        private INoteHandler _noteHandlerChain;

        private NoteManager() // Private constructor to enforce singleton pattern
        {
            _storageStrategy = new SQLSizeNotes();
            InitializeHandlerChain();
        }


        public void Add(Note note)
        {

            var processedNote = _noteHandlerChain.Handle(note);// Process the note through the chain before saving
            _storageStrategy.Save(processedNote);
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
            var processedNote = _noteHandlerChain.Handle(note);
            _storageStrategy.Update(processedNote);
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
        public Note CloneNote(Note originalNote)
        {
            if (originalNote == null)
            {
                throw new ArgumentNullException(nameof(originalNote));
            }

            try
            {
                var clonedNote = originalNote.CreateClone();
                this.Add(clonedNote);
                return clonedNote;
            }
            catch (Exception ex)
            {
                // Log error if needed
                throw new InvalidOperationException("Failed to clone note", ex);
            }
        }
        private void InitializeHandlerChain()
        {
            // Build the chain of responsibility
            var titleValidator = new TitleValidationHandler();
            var profanityFilter = new ProfanityFilterHandler();
            var contentFormatter = new ContentFormattingHandler();

            titleValidator
                .SetNext(profanityFilter)
                .SetNext(contentFormatter);

            _noteHandlerChain = titleValidator;
        }

    }
}
