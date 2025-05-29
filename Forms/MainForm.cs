using ByteSizeNotes.Composite;
using ByteSizeNotes.Factory;
using ByteSizeNotes.Models;
using ByteSizeNotes.Observer;
using ByteSizeNotes.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteSizeNotes
{

    public partial class MainForm : Form, INoteObserver
    {

        private NoteQueueProcessor _noteProcessor = new NoteQueueProcessor();
        public MainForm()
        {
            InitializeComponent();
            NoteManager.Instance.RegisterObserver(this);
            RefreshNotes();
            LoadNotesToTree(); 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var note = NoteFactory.Create(txtTitle.Text, txtContent.Text);
            _noteProcessor.Enqueue(note);

        }


        private void RefreshNotes()
        {
            Task.Run(() => // ->tread pool pattern
            {
                var notes = NoteManager.Instance.Notes;

                // check if the handle is created before invoking
                if (IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        treeNotes.Nodes.Clear();

                        var root = new TreeNode("Mijn Notities");

                        foreach (var note in notes)
                        {
                            var noteNode = new TreeNode(note.Title) { Tag = note };
                            root.Nodes.Add(noteNode);
                        }

                        treeNotes.Nodes.Add(root);
                        treeNotes.ExpandAll();
                    });
                }
            });
        }




        private void ClearInputs()
        {
            txtTitle.Text = string.Empty;
            txtContent.Text = string.Empty;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeNotes.SelectedNode?.Tag is Note note)
            {
                int index = NoteManager.Instance.Notes.FindIndex(n => n == note);
                if (index >= 0)
                {
                    NoteManager.Instance.RemoveAt(index);
                    RefreshNotes();
                    ClearInputs();
                }
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (treeNotes.SelectedNode?.Tag is Note note)
            {
                note.Title = txtTitle.Text;
                note.Content = txtContent.Text;

                NoteManager.Instance.Update(note);
                RefreshNotes();
            }
        }



        public void OnNotesChanged()
        {
            if (InvokeRequired)
            {
                if (IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { OnNotesChanged(); });
                }
                return;
            }

            RefreshNotes();
            ClearInputs();
            LoadNotesToTree();
            //MessageBox.Show("Observer is aangeroepen!");
        }



        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            NoteManager.Instance.UnregisterObserver(this);
            base.OnFormClosed(e);
            _noteProcessor.Stop();
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

        private void treeNotes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Note note)
            {
                txtTitle.Text = note.Title;
                txtContent.Text = note.Content;
            }
            else
            {
                txtTitle.Text = string.Empty;
                txtContent.Text = string.Empty;
            }
        }



        private void LoadNotesToTree()
        {
            treeNotes.Nodes.Clear();

            var root = new TreeNode("Mijn Notities");

            foreach (var note in NoteManager.Instance.Notes)
            {
                var noteNode = new TreeNode(note.Title);
                noteNode.Tag = note;
                root.Nodes.Add(noteNode);
            }

            treeNotes.Nodes.Add(root);
            treeNotes.ExpandAll();
        }

        private void btnMassDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Weet je zeker dat je alle notities wilt verwijderen?", "Bevestigen", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                NoteManager.Instance.RemoveAll();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
