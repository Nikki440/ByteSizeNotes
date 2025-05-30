using ByteSizeNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSizeNotes.ChainOfResponsibility
{
    public class TitleValidationHandler : AbstractNoteHandler
    {
        public override Note Handle(Note note)// Validate the title of the note
        {
            if (string.IsNullOrWhiteSpace(note.Title))
            {
                throw new ArgumentException("Note title cannot be empty");
            }

            if (note.Title.Length > 100)
            {
                throw new ArgumentException("Note title cannot exceed 100 characters");
            }

            return base.Handle(note);
        }
    }

    // Handler for content formatting
    public class ContentFormattingHandler : AbstractNoteHandler
    {
        public override Note Handle(Note note)
        {
            // Trim whitespace and ensure content ends with a period if it's not empty
            note.Content = note.Content?.Trim();
            if (!string.IsNullOrEmpty(note.Content) &&
                !note.Content.EndsWith(".") &&
                !note.Content.EndsWith("!") &&
                !note.Content.EndsWith("?"))
            {
                note.Content += ".";// Ensure content ends with a period
            }

            return base.Handle(note);
        }
    }

    // Handler for profanity filtering
    public class ProfanityFilterHandler : AbstractNoteHandler// Filter out banned words from the note
    {
        private readonly string[] _bannedWords = { "test", "test123" };

        public override Note Handle(Note note)
        {
            foreach (var word in _bannedWords)
            {
                note.Title = note.Title.Replace(word, "♡♡♡♡♡");
                note.Content = note.Content.Replace(word, "♡♡♡♡♡♡");
            }

            return base.Handle(note);
        }
    }
}
