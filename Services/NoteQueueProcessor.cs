using ByteSizeNotes.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ByteSizeNotes.Services
{
    public class NoteQueueProcessor
    {
        private readonly BlockingCollection<Note> _noteQueue = new(); // Thread-safe collection for queuing notes
        private readonly CancellationTokenSource _cts = new(); // Cancellation token source to manage task cancellation

        public NoteQueueProcessor() // Constructor initializes the queue and starts the processing task
        {
            Task.Factory.StartNew(ProcessNotes, TaskCreationOptions.LongRunning);
        }

        public void Enqueue(Note note)
        {
            _noteQueue.Add(note);
        }

        private void ProcessNotes()
        {
            try
            {
                foreach (var note in _noteQueue.GetConsumingEnumerable(_cts.Token))
                {
                    try
                    {
                        NoteManager.Instance.Add(note);
                    }
                    catch (Exception ex)
                    {
                        // Handle validation errors from the chain
                        // Could log this or notify the UI in a real application
                        Console.WriteLine($"Error processing note: {ex.Message}");
                    }
                    Thread.Sleep(500);
                }
            }
            catch (OperationCanceledException)
            {
                // Task was cancelled, exit gracefully
            }
        }


        public void Stop()
        {
            _noteQueue.CompleteAdding();
            _cts.Cancel();
        }
    }
}
