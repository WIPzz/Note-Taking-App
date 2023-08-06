using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
x -Concept
    Left side
        Title
        Note field
    Right Side
        List with all notes
        Delete Note
        Add Note
        Edit Note
x - Get the text of textBox1 & 2
x - Add Note button saves the text of textBox1 & 2 into the list
x - Clear text if you add a note
x - Able to select a note on the list
x - In the list:
    Show the title of the note on the left side
    Show the note itself on the right side
x - Selected note can be deleted
x - Selected note can be edited
    edit mode is on the left side



Fix:
x - Error if delete button is pressed and no row is selected
x - If editing a note, change the button text to "update", update the old entry with the new one
x - Dont accept empty entries
x - App crashes if pressing the edit button without selecting a row




*/



namespace Note_Taking_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Add button
        private void addNoteBttn(object sender, EventArgs e)
        {
            // Check for empty or null in textBox1 & 2
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                string title = textBox2.Text;
                string text = textBox1.Text;

                ListViewItem list = new ListViewItem(title);
                list.SubItems.Add(text);
                listView1.Items.Add(list);

                textBox1.Clear();
                textBox2.Clear();
            }
        }

        // Delete button
        private void delNoteBttn(object sender, EventArgs e)
        {
            //Check if an entry is selected
            if (listView1.SelectedItems.Count == 0) return;
            
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        // Edit button
        private bool editMode = false;
        private void editNoteBttn(object sender, EventArgs e)
        {
            //Check if an entry is selected
            if (listView1.SelectedItems.Count == 0) return;
            
            if (editMode)
            {
                // Update the selected item and subitems
                ListViewItem selectedItem = listView1.SelectedItems[0];
                selectedItem.SubItems[0].Text = textBox2.Text; 
                selectedItem.SubItems[1].Text = textBox1.Text; 

                button3.Text = "Edit Note";
                editMode = false;
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                button3.Text = "Update";
                editMode = true;

                // Show the subitems in the edit box
                string title = listView1.SelectedItems[0].SubItems[0].Text;
                string text = listView1.SelectedItems[0].SubItems[1].Text;

                textBox1.Text = text;
                textBox2.Text = title;
            }
        }

    }
}
