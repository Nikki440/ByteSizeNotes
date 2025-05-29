using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSizeNotes.Bridge
{
    public class TextNote : AbstractNote
    {
        public TextNote(string title, string content, NoteStorageStrategy storage)
            : base(title, content, storage)
        {
        }

        public override void Save()
        {
            storage.Save(new Models.Note { Title = Title, Content = Content });
            Console.WriteLine($"[SQL] Sla '{Title}' op in database");
        }

        public override void Delete()
        {
            storage.Delete(new Models.Note { Title = Title, Content = Content });
            Console.WriteLine($"[SQL] Verwijder '{Title}' uit database");
        }
    }
}

