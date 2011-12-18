using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rydeUI;
using System.IO;
using System.Text.RegularExpressions;
using StdUtils;

namespace rydeUI
{
    public partial class mainStrip : Form
    {
        string filename;
        bool saved = false;
        bool has_saved = false;
        public static string code;
        public static int ln;
        public static string[] codeLines;
        public volatile bool insert = true;
        int index;
        int lline;
        int firstChar;
        int column;
        
        public mainStrip()
        {
            InitializeComponent();

            /* Line */
            index = textBox.SelectionStart;
            lline = textBox.GetLineFromCharIndex(index);
            this.line.Text = "Ln: " + lline.ToString();
            /* col */
            firstChar = textBox.GetFirstCharIndexFromLine(lline);
            column = index - firstChar;
            col.Text = "Col: " + column.ToString();
            /* Position */
            this.pos.Text = this.textBox.Location.ToString();
            /* Lines Total */
            this.lineN.Text = "Lines: " + this.textBox.Lines.Count();
            /* Length */
            this.lengthN.Text = "Length: " + this.textBox.TextLength.ToString();
            /* Selection */
            this.sel.Text = "ChSel: " + this.textBox.SelectedText.Count().ToString();
            /* Encoding */
            this.encodingLbl.Text = "Encoding: " + "ANSI";
            /* Operating System */
            this.osLbl.Text = Environment.OSVersion.Platform.ToString();
            /* DOS */
            this.dosLbl.Text = "DOS/Windows";
            /* OS VERSION STRING */
            this.vs.Text = Environment.Version.ToString();
            /* OSSTR */
            this.osstr.Text = Environment.OSVersion.VersionString;
            /* CMPSTR */
            this.userdomain.Text = Environment.UserDomainName.ToString();
            /* End Label */
            this.endlbl.Text = Environment.WorkingSet.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool file_exists = isAvailable();
            if (file_exists == false)
            {
                MessageBox.Show("The program can't start because certain files are missing from your computer. Try reinstalling the program to fix this error", "rydeUI.exe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, 0, MessageBoxOptions.ServiceNotification);
                this.textBox.Enabled = false;
                this.menuStrip1.Enabled = false;
                this.status.Enabled = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new mainStrip()).Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Rye Scripts (.rye)|*.rye";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filename = openFile.FileName;   /* Set filename */               
            }

            try
            {

                using (System.IO.StreamReader sr = new System.IO.StreamReader(filename))
                {
                    this.textBox.Text += sr.ReadToEnd();
                    saved = true;
                    has_saved = true;
                }
            }
            catch { ; }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == false)
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Rye Scripts (.rye)|*.rye";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filename = sv.FileName;
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
                        {
                            sw.Write(textBox.Text);
                            saved = true;
                            has_saved = true;
                        }
                    }
                    catch { ; }
                }
            }
            else
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
                {
                    sw.Write(textBox.Text);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {            
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Rye Scripts (.rye)|*.rye";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filename = sv.FileName;
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
                        {
                            sw.Write(textBox.Text);
                            saved = true;
                            has_saved = true;
                        }
                    }
                    catch { ; }
                }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.SelectAll();
        }

        private void runSelectedLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("rye.exe") == true && File.Exists("bin/rye.exe") == true)
            {

                if (textBox.SelectedText != "")
                {
                    try
                    {
                        execute.debug(ExecCmd.ExecuteCommand("rye -r " + textBox.SelectedText));
                    }
                    catch
                    {
                        execute.debug("An error has occured");
                    }
                }
                else { MessageBox.Show("No code is selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else
            {
                MessageBox.Show("Error. The compiler is missing!", "rydeUI.exe",
                  MessageBoxButtons.OK, MessageBoxIcon.Error, 0, MessageBoxOptions.ServiceNotification);
            }
        }

        private void runFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("rye.exe") == true && File.Exists("bin/rye.exe") == true)
            {
                if (textBox.Text != "")
                {
                    try
                    {
                        int lnc = this.textBox.Lines.Count();
                        int i = 0;
                        while (i < lnc)
                        {
                            execute.debug(ExecCmd.ExecuteCommand("rye -r " + this.textBox.Lines[i].ToString()));
                            i++;
                        }

                    }
                    catch
                    {
                        execute.debug("An error has occured");
                    }
                }
                else { MessageBox.Show("There is no code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else
            {
                MessageBox.Show("Error. The compiler is missing!", "rydeUI.exe",
                  MessageBoxButtons.OK, MessageBoxIcon.Error, 0, MessageBoxOptions.ServiceNotification);
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                code = this.textBox.Text;
                ln = this.textBox.Lines.Count();
                codeLines = this.textBox.Lines.ToArray();

                /* Color Code */

                Regex regExp = new Regex("out |this |' ' ");
                Regex quo = new Regex("'{ENTER}'");

                foreach (Match match in regExp.Matches(textBox.Text))
                {
                    textBox.Select(match.Index, match.Length);
                    textBox.SelectionColor = Color.Blue;
                    textBox.Select(10, match.Length);
                    textBox.SelectionColor = Color.Black;
                    textBox.DeselectAll();
                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.Focus();
                    
                    textBox.ForeColor = Color.Black;
                    has_saved = false;
                    break;
                }

                foreach (Match match in quo.Matches(textBox.Text))
                {
                    textBox.Select(match.Index, match.Length);
                    textBox.SelectionColor = Color.Firebrick;
                    textBox.DeselectAll();
                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.Focus();
                    textBox.ForeColor = Color.Black;
                    has_saved = false;
                    break;
                }

               
            }
            else { textBox.ForeColor = Color.Black;  };

            /* Lines */
            index = textBox.SelectionStart;
            lline = textBox.GetLineFromCharIndex(index);
            this.line.Text = "Ln: " + lline.ToString();

            /* Columns */
            firstChar = textBox.GetFirstCharIndexFromLine(lline);
            column = index - firstChar;
            col.Text = "Col: " + column.ToString();

            /* Position */
            this.pos.Text = this.textBox.Location.ToString();

            /* Lines Total */
            this.lineN.Text = "Lines: " + this.textBox.Lines.Count();

            /* Length */
            this.lengthN.Text = "Length: " + this.textBox.TextLength.ToString();

            /* Encoding */
            this.encodingLbl.Text = "Encoding: " + "ANSI";

            
        }

        private void asdasdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < codeLines.Count())
            {
                MessageBox.Show(codeLines[i]);
                i++;
            }
        }

        private void codeCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This file has a: " + ln.ToString() + " code count", "RYDE", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void mainStrip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (has_saved == false && this.textBox.Text != ""
                    && this.textBox.Text != null) {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Exit without saving data?", "RYDE",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    has_saved = true;
                    Application.Exit();
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
                else if (dr == DialogResult.No)
                {
                    if (saved == false)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "Rye Scripts (.rye)|*.rye";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                filename = sv.FileName;
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
                                {
                                    sw.Write(textBox.Text);
                                    saved = true;
                                    has_saved = true;
                                }
                            }
                            catch { ; }
                        }
                    }
                    else
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
                        {
                            sw.Write(textBox.Text);
                        }
                    }
                }
            }
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://kryptonx.webs.com/rye/");
        }

        private void debugFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debugging is not currently supported.", "RYDE",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, (0), MessageBoxOptions.ServiceNotification);
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new about()).ShowDialog();
        }

        private void mainStrip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (insert == true)
                {
                    this.cmpos.Text = "INS";
                } else {
                    this.cmpos.Text = "OVR";
                }
            }
        }

        private void ins_DoubleClick(object sender, EventArgs e)
        {
            if (insert == true)
            {
                this.cmpos.Text = "INS";
            }
            else
            {
                this.cmpos.Text = "OVR";
            }
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new content()).ShowDialog();
        }

        // extracts [resource] into the the file specified by [path]
public void ExtractResource( string resource, string path )
{
    Stream stream = GetType().Assembly.GetManifestResourceStream( resource );
    byte[] bytes = new byte[(int)stream.Length];
    stream.Read( bytes, 0, bytes.Length );
    File.WriteAllBytes( path, bytes );
}

private void searchToolStripMenuItem_Click(object sender, EventArgs e)
{
    (new search()).ShowDialog();
}

private void findToolStripMenuItem_Click(object sender, EventArgs e)
{
    MessageBox.Show(search.find(textBox.Text));
}

public bool isAvailable()
{
    if (File.Exists("rye.exe") == true &&
        File.Exists("bin/rye.exe") == true &&
        File.Exists("bin/strip.exe") == true &&
        File.Exists("lib/bsmth.dll") == true &&
        File.Exists("lib/stdutils.dll") == true
        && File.Exists("lib/system.dll") == true)
        return true;
    else
        return false;
}

private void shellToolStripMenuItem_Click(object sender, EventArgs e)
{
    (new shell()).Show(this);
}
    }
}
