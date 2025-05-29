using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteSizeNotes.Bridge
{
    public class BridgeDemo
    {
        public static void Run()
        {
            NoteStorageStrategy sqlStorage = new SQLSizeNotes();
            AbstractNote note = new TextNote("Dagboek", "Het regende vandaag ):", sqlStorage);

            note.Save(); 
            note.Delete();
        }
    }

}
