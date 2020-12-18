using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT3
{
    public partial class Form1 : Form
    {
        string fileName = "No";
        public Form1()
        {
            InitializeComponent();
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.Location = this.Location;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Save();
        }
        private void LoadSettings()
        {
            this.Location = Properties.Settings.Default.Location;
            this.Height = Properties.Settings.Default.Height;
            this.Width =Properties.Settings.Default.Width ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            this.Text = "Notepad" + fileName;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(fileName,txtBox.Text);
                this.Text = "Notepad - " + fileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fileName == "No")
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, txtBox.Text);
                this.Text = "Notepad - " + fileName;
            }
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if(txtBox.Modified)
            {
                this.Text = "Notepad - " + fileName + " *";
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtBox.SelectionLength > 0)
                txtBox.Copy();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (txtBox.SelectedText != "")
                txtBox.Cut();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtBox.SelectionLength > 0)
                {
                    if (MessageBox.Show("Bạn có muốn chép đè lên văn bản hiện tại ?", "Relace ?", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtBox.SelectionStart = txtBox.SelectionStart + txtBox.SelectionLength;
                }
                txtBox.Paste();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (txtBox.CanUndo == true)
            {
                txtBox.Undo();
                txtBox.ClearUndo();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBox.CanUndo == true)
            {
                txtBox.Undo();
                txtBox.ClearUndo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBox.SelectedText != "")
                txtBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBox.SelectionLength > 0)
                txtBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtBox.SelectionLength > 0)
                {
                    if (MessageBox.Show("Bạn có muốn chép đè lên văn bản hiện tại ?", "Relace ?", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtBox.SelectionStart = txtBox.SelectionStart + txtBox.SelectionLength;
                }
                txtBox.Paste();
            }
        }
    }
}
