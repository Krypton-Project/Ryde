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
    public partial class search : Form
    {
        public static string ftext;
        public static string tfile;
        public search()
        {
            InitializeComponent();           
        }

        private void search_Load(object sender, EventArgs e)
        {
            /* */
        }

        public static string find(string ft)
        {
            string xstr = "";
            search sr = new search();
            search.tfile = ft;
            sr.ShowDialog();
            return xstr;
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            search.ftext = input.Text;            
            this.Close();
        }

                    
    }
}
