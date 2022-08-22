namespace Final_DCU
{
    public partial class Form1 : Form
    {
        String uname, upass,suname,supass,suphone;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup sn= new Signup();
            this.Hide();
            sn.ShowDialog();
            this.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uname = unameTB.Text;
            upass = upassTB.Text;
            bdop db=new bdop();
            db.logIN(uname,upass);
            

            if (db.conf)
            {
                dash da = new dash();
                db.nameEX(uname,upass);
                suname = db.exchangeN();
                supass = db.exchangemail();
                suphone= db.exchangephone();
                exchange ex = new exchange();
                ex.email = supass;
                ex.uname = suname;
                ex.phone= suphone;
                da.list.Add(ex);
                this.Hide();
                
                da.ShowDialog();
                this.Close();
            }
            
        }
    }
}