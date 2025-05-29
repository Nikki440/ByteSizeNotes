using ByteSizeNotes.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class SQLSizeNotes : NoteStorageStrategy
{
    private readonly string _connectionString = "Data Source=notes.db";

    public SQLSizeNotes()
    {
        using var conn = new SQLiteConnection(_connectionString);
        conn.Open();
        var cmd = new SQLiteCommand(
            "CREATE TABLE IF NOT EXISTS Notes (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT, Content TEXT, Created TEXT)",
            conn);
        cmd.ExecuteNonQuery();
    }

    public List<Note> LoadAll()
    {
        var notes = new List<Note>();
        using var conn = new SQLiteConnection(_connectionString);
        conn.Open();
        var cmd = new SQLiteCommand("SELECT Id, Title, Content, Created FROM Notes", conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            notes.Add(new Note
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Content = reader.GetString(2),
                Created = DateTime.Parse(reader.GetString(3))
            });
        }
        return notes;
    }

    public void Save(Note note)
    {
        using var conn = new SQLiteConnection(_connectionString);
        conn.Open();
        var cmd = new SQLiteCommand(
            "INSERT INTO Notes (Title, Content, Created) VALUES (@title, @content, @created)", conn);
        cmd.Parameters.AddWithValue("@title", note.Title);
        cmd.Parameters.AddWithValue("@content", note.Content);
        cmd.Parameters.AddWithValue("@created", note.Created.ToString("o"));
        cmd.ExecuteNonQuery();
    }

    public void Delete(Note note)
    {
        using var conn = new SQLiteConnection(_connectionString);
        conn.Open();
        var cmd = new SQLiteCommand("DELETE FROM Notes WHERE Id = @id", conn);
        cmd.Parameters.AddWithValue("@id", note.Id);
        cmd.ExecuteNonQuery();
    }

    public void Update(Note note)
    {
        using var conn = new SQLiteConnection(_connectionString);
        conn.Open();
        var cmd = new SQLiteCommand(
            "UPDATE Notes SET Title = @title, Content = @content, Created = @created WHERE Id = @id", conn);
        cmd.Parameters.AddWithValue("@title", note.Title);
        cmd.Parameters.AddWithValue("@content", note.Content);
        cmd.Parameters.AddWithValue("@created", note.Created.ToString("o"));
        cmd.Parameters.AddWithValue("@id", note.Id);
        cmd.ExecuteNonQuery();
    }
    public void DeleteAll()
    {
        using (var conn = new SQLiteConnection("Data Source=notes.db"))
        {
            conn.Open();
            var cmd = new SQLiteCommand("DELETE FROM Notes", conn);
            cmd.ExecuteNonQuery();
        }
    }
    public void Save(string title, string content)
    {
        // Simuleer SQL-opslag
        Console.WriteLine($"[SQL] Sla '{title}' op in database");
    }

    public void Delete(string title)
    {
        Console.WriteLine($"[SQL] Verwijder '{title}' uit database");
    }

}
