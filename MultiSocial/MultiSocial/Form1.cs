using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using EO.WebBrowser;
using JsonParserEncrypt;
using System.IO;

namespace MultiSocial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        private string _selectedSocial = "";

        public string SelectedSocial
        {
            get { return _selectedSocial; }
            set { _selectedSocial = value; Console.WriteLine(_selectedSocial); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if(SelectedSocial == "")
            {
                return;
            }
            else if(SelectedSocial == "Facebook")
            {
                TabControl t = new TabControl();
                WebView web = new WebView();
                web.Create(t.Handle);
                

            }

        }

        //private void Form1_SizeChanged(object sender, EventArgs e)
        //{

        //}

        //private void tabPage1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
