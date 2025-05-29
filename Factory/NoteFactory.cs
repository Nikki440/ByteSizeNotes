using ByteSizeNotes.Models;
using System;

namespace ByteSizeNotes.Factory
{
    public static class NoteFactory
    {
        public static Note Create(string title, string content)
        {
            return new Note
            {
                Title = title,
                Content = content,
                Created = DateTime.Now 
            };
        }
        public static Note CreateEmpty()
        {
            return new Note
            {
                Title = "Nieuwe notitie",
                Content ="Hier kan je tekst typen",
                Created = DateTime.Now
            };
        }

    }

}
