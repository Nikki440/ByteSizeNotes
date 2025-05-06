using ByteSizeNotes.Models;
using ByteSizeNotes.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteSizeNotes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            RefreshNotes();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var note = new Note
            {
                Title = txtTitle.Text,
                Content = txtContent.Text
            };

            NoteManager.Instance.Add(note);
            RefreshNotes();
            ClearInputs();
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
                RefreshNotes();
            }
        }


        private void txtContent_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
