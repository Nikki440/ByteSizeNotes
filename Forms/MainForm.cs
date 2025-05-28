using ByteSizeNotes.Factory;
using ByteSizeNotes.Models;
using ByteSizeNotes.Observer;
using ByteSizeNotes.Services;
using System;
using System.Windows.Forms;

namespace ByteSizeNotes
{
    public partial class MainForm : Form, INoteObserver
    {
        public MainForm()
        {
            InitializeComponent();
            NoteManager.Instance.RegisterObserver(this);
            RefreshNotes();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var note = NoteFactory.Create(txtTitle.Text, txtContent.Text);
            NoteManager.Instance.Add(note);
        }


        private void RefreshNotes()
        {
            int selectedIndex = lstNotes.SelectedIndex;

            lstNotes.Items.Clear();
            foreach (var note in NoteManager.Instance.Notes)
            {
                lstNotes.Items.Add(note.Title);
            }

            if (selectedIndex >= 0 && selectedIndex < lstNotes.Items.Count)
            {
                lstNotes.SelectedIndex = selectedIndex;
            }
        }


        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex != -1)
            {
                var selectedNote = NoteManager.Instance.Notes[lstNotes.SelectedIndex];
                txtTitle.Text = selectedNote.Title;
                txtContent.Text = selectedNote.Content;
            }
        }

        private void ClearInputs()
        {
            txtTitle.Text = string.Empty;
            txtContent.Text = string.Empty;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex != -1)
            {
                NoteManager.Instance.RemoveAt(lstNotes.SelectedIndex);
                RefreshNotes();
                ClearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex != -1)
            {
                var selectedNote = NoteManager.Instance.Notes[lstNotes.SelectedIndex];
                selectedNote.Title = txtTitle.Text;
                selectedNote.Content = txtContent.Text;

                NoteManager.Instance.Update(selectedNote);
                RefreshNotes();
            }
        }

        public void OnNotesChanged()
        {
            RefreshNotes();
            ClearInputs();
            //MessageBox.Show("Observer is aangeroepen!");
        }



        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            NoteManager.Instance.UnregisterObserver(this);
            base.OnFormClosed(e);
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContent_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewEmptyNote_Click_1(object sender, EventArgs e)
        {
            var emptyNote = NoteFactory.CreateEmpty();
            txtTitle.Text = emptyNote.Title;
            txtContent.Text = emptyNote.Content;
        }
    }
}
