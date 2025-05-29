using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSizeNotes.Bridge
{
    public abstract class AbstractNote
    {
        protected NoteStorageStrategy storage;
        public string Title { get; set; }
        public string Content { get; set; }

        protected AbstractNote(string title, string content, NoteStorageStrategy storage)
        {
            Title = title;
            Content = content;
            this.storage = storage;
        }

        public abstract void Save();
        public abstract void Delete();
    }
}

