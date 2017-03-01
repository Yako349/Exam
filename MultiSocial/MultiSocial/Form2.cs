using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSocial
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private Form1 form = null;
        public Form2(Form callingForm)
        {
            form = callingForm as Form1;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(rbn_fb.Checked)
            {
                form.SelectedSocial = "Facebook";
            }
            this.Close();
        }
    }
}
