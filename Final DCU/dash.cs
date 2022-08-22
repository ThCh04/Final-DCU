using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Final_DCU
{
    public partial class dash : Form
    {
        
        Stopwatch stopwatch = new Stopwatch();
        bool confirm = false;
        string ime, subject, student;
        public List<exchange> list = new List<exchange>();


        public dash()
        {
            InitializeComponent();
        }

        private void startTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 log = new Form1();
            log.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (biorb.Checked)
            {
                confirm = true;
                subject = biorb.Text;
            }
            else if (grb.Checked)
            {
                confirm = true;
                subject = grb.Text;
            }
            else if (hisrb.Checked)
            {
                confirm = true;
                subject = hisrb.Text;
            }
            else if (itrb.Checked)
            {
                confirm = true;
                subject = itrb.Text;
            }
            else if (larb.Checked)
            {
                confirm = true;
                subject = larb.Text;
            }
            else if (mrb.Checked)
            {
                confirm = true;
                subject = mrb.Text;
            }
            else
            {
                confirm = false;
                MessageBox.Show("YOU SHOULD SELECT A SUBJECT");
            }

            bdop db = new bdop();

            if (confirm)
            {
                if (initbtn.Text == "Start")
                {
                    initbtn.Text = "Stop";
                    stopwatch.Start();
                    timer1.Enabled = true;
                }
                else
                {
                    initbtn.Text = "Start";
                    ime = htb.Text + "/" + mtb.Text + "/" + stb.Text;
                    student = unamLB.Text;
                    stopwatch.Reset(); 
                    timer1.Enabled = false;
                    db.trCK(student, subject,ime);
                    dash_Shown(sender, e);
                   
                }
            }




        }


        private void dash_Shown(object sender, EventArgs e)
        {

           

            foreach  (var ex in list)
            {
                unamLB.Text = ex.uname;
                emlb.Text = ex.email;
                plb1.Text= ex.phone;
            }

            bdop db = new bdop();
            db.selectTK(unamLB.Text, dataGridView1);



        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DEVELOPED BY EDUARD CRUZ " + "" + "ID: 20209358");
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FIRST SELECT A SUBJECT YOU WANT TO STUDY TO, NEXT CLICK START BUTTON TO START COUNTING, ONCE YOU FINISHED YOUR STUDYING SESSION, CLICK THE STOP BUTTON TO RECORD IT");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan tn = new TimeSpan(0, 0, 0, 0, (int)stopwatch.ElapsedMilliseconds);

            htb.Text = tn.Hours.ToString().Length < 2 ? "0" + tn.Hours.ToString() : tn.Hours.ToString();
            mtb.Text = tn.Minutes.ToString().Length < 2 ? "0" + tn.Minutes.ToString() : tn.Minutes.ToString(); ;
            stb.Text = tn.Seconds.ToString().Length < 2 ? "0" + tn.Seconds.ToString() : tn.Seconds.ToString(); ;
            miltb.Text = tn.Milliseconds.ToString().Length < 2 ? "0" + tn.Milliseconds.ToString() : tn.Milliseconds.ToString(); ;
        }

      

    }

}
