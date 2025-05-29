using ByteSizeNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface NoteStorageStrategy // Strategy Pattern for Note Storage
{
    void Save(Note note);
    List<Note> LoadAll(); // Load all notes from storage
    void Delete(Note note);
    void Update(Note note);
    void DeleteAll();
    void Save(string title, string content);
    void Delete(string title);

}
