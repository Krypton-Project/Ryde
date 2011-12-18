using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace rydeUI
{
    public partial class shell : Form
    {
        public shell()
        {
            InitializeComponent();
            this.AcceptButton = send;
            send.SendToBack();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
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
                    
                    break;
                }


            }
            else { textBox.ForeColor = Color.Black; };
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
            
           
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cc = ExecCmd.ExecuteCommand("rye -r " + textBox.Text);
            log.Text += "\n" + cc + "\n";
        }
    
        private void shell_Load(object sender, EventArgs e)
        {

        }
    }
}
