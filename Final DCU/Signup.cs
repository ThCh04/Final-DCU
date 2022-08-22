using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_DCU
{
    public partial class Signup : Form
    {
        string fname, email, pass, cpass, pnum;
        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

            if (string.IsNullOrEmpty(fnameTB.Text))
            {
                MessageBox.Show("YOU SHOULD SPECIFY A NAME");
            }
            else
            {
                fname = fnameTB.Text;
            }
            if (string.IsNullOrEmpty(em1TB.Text) && string.IsNullOrEmpty(em2TB.Text))
            {
                MessageBox.Show("YOU SHOULD SPECIFY AN EMAIL");
            }
            else
            {
                email = em1TB.Text + "@" + em2TB.Text;
            }
            if (string.IsNullOrEmpty(passTB.Text) && string.IsNullOrEmpty(cpassTB.Text))
            {
                MessageBox.Show("YOU SHOULD SPECIFY A PASSWORD");
            }else if(passTB.Text == cpassTB.Text)
            {
                pass = passTB.Text;
            }
            else
            {
                MessageBox.Show("PASSWORDS DON´T MATCH");
            }

            if (string.IsNullOrEmpty(pnum1.Text) && string.IsNullOrEmpty(pnum2.Text) && string.IsNullOrEmpty(pnum3.Text))
            {
                MessageBox.Show("YOU SHOULD SPECIFY A PHONE NUMBER");
            }
            else
            {
                pnum = pnum1.Text + "-" + pnum2.Text + "-" + pnum3.Text;
            }

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(email)|| string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(pnum))
            {
                MessageBox.Show("INVALID DATA, CHECK YOUR ENTRIES");
            }
            else
            {
                bdop db = new bdop();
                db.signUP(email, pass, fname, pnum);
            }
           

        }
    }
}
