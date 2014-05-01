using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlEventEditor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Brawl data editor by Heinermann.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( openFileDialog.ShowDialog() == DialogResult.OK )
            {
                Program.event_file.load(openFileDialog.FileName);
                entry_list.Items.Clear();
                entry_list.Items.AddRange( Program.event_file.m_entries.Keys.ToArray() );
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unimplemented");
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Program.event_file.save(saveFileDialog.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void entry_list_SelectedValueChanged(object sender, EventArgs e)
        {
            string key = entry_list.SelectedItem.ToString();
            if (Program.event_file.m_entries.ContainsKey(key) )
            {
                MessageBox.Show(key + " FOUND");
                entry_props.SelectedObject = Program.event_file.m_entries[key];
            }
            else
            {
                MessageBox.Show(key + " NOT FOUND");
                entry_props.SelectedObject = null;
            }
        }
    }
}
