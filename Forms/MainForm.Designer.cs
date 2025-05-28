namespace ByteSizeNotes
{
    using System.Windows.Forms;

    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstNotes;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblNotes;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstNotes = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnNewEmptyNote = new System.Windows.Forms.Button();
            this.treeNotes = new System.Windows.Forms.TreeView();
            this.btnMassDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Khaki;
            this.txtTitle.Location = new System.Drawing.Point(11, 41);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(318, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.Khaki;
            this.txtContent.Location = new System.Drawing.Point(11, 89);
            this.txtContent.Margin = new System.Windows.Forms.Padding(2);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(318, 136);
            this.txtContent.TabIndex = 3;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged_1);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnAdd.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(5, 229);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 41);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Toevoegen";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstNotes
            // 
            this.lstNotes.BackColor = System.Drawing.Color.Khaki;
            this.lstNotes.FormattingEnabled = true;
            this.lstNotes.Location = new System.Drawing.Point(338, 41);
            this.lstNotes.Margin = new System.Windows.Forms.Padding(2);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(128, 212);
            this.lstNotes.TabIndex = 5;
            this.lstNotes.SelectedIndexChanged += new System.EventHandler(this.lstNotes_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDelete.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(116, 229);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 41);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Verwijder";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnUpdate.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(227, 229);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 41);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblTitle.Location = new System.Drawing.Point(11, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // lblContent
            // 
            this.lblContent.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblContent.Location = new System.Drawing.Point(11, 63);
            this.lblContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(110, 24);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "Content:";
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblNotes.Location = new System.Drawing.Point(333, 15);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(87, 24);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Notes:";
            // 
            // btnNewEmptyNote
            // 
            this.btnNewEmptyNote.Location = new System.Drawing.Point(262, 5);
            this.btnNewEmptyNote.Name = "btnNewEmptyNote";
            this.btnNewEmptyNote.Size = new System.Drawing.Size(66, 31);
            this.btnNewEmptyNote.TabIndex = 9;
            this.btnNewEmptyNote.Text = "Lege note";
            this.btnNewEmptyNote.UseVisualStyleBackColor = true;
            this.btnNewEmptyNote.Click += new System.EventHandler(this.btnNewEmptyNote_Click_1);
            // 
            // treeNotes
            // 
            this.treeNotes.Location = new System.Drawing.Point(477, 41);
            this.treeNotes.Name = "treeNotes";
            this.treeNotes.Size = new System.Drawing.Size(181, 212);
            this.treeNotes.TabIndex = 11;
            this.treeNotes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeNotes_AfterSelect);
            // 
            // btnMassDelete
            // 
            this.btnMassDelete.Location = new System.Drawing.Point(345, 258);
            this.btnMassDelete.Name = "btnMassDelete";
            this.btnMassDelete.Size = new System.Drawing.Size(75, 23);
            this.btnMassDelete.TabIndex = 12;
            this.btnMassDelete.Text = "Delete all";
            this.btnMassDelete.UseVisualStyleBackColor = true;
            this.btnMassDelete.Click += new System.EventHandler(this.btnMassDelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(670, 284);
            this.Controls.Add(this.btnMassDelete);
            this.Controls.Add(this.treeNotes);
            this.Controls.Add(this.btnNewEmptyNote);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstNotes);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "ByteSizeNotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Button btnNewEmptyNote;
        private TreeView treeNotes;
        private Button btnMassDelete;
    }
}
