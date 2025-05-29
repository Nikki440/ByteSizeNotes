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
        private readonly BlockingCollection<Note> _noteQueue = new();
        private readonly CancellationTokenSource _cts = new();

        public NoteQueueProcessor()
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
                    NoteManager.Instance.Add(note);
                    Thread.Sleep(500); // simulate processing delay
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
