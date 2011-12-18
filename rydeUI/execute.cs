using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace rydeUI
{
    public partial class execute : Form
    {
        
        public execute()
        {
            InitializeComponent();
        }

        private void execute_Load(object sender, EventArgs e)
        {
            this.Select();

        }

        public static void debug(string pl)
        {
            execute exec = new execute();
            exec.codeWindow.Text = pl;
            exec.Text = "Execute:";
            exec.ShowDialog();
        }

        public static void complete_debug()
        {
            int i = 0;
            execute exec = new execute();
            MessageBox.Show(mainStrip.ln.ToString());
            while (i < mainStrip.ln)
            {
                i++;                
                exec.codeWindow.Text = ExecCmd.ExecuteCommand("rye -r " + mainStrip.codeLines[1].ToString());                
            }
            exec.Show();
        }

        private void codeWindow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
