using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_DCU
{
    public class bdop
    {
        SqlConnection conect = new SqlConnection("server=LAPTOP-6HP1LBO9\\SQLEXPRESS; database=studytrack; integrated security=true");

        DataSet data = new DataSet();
        SqlDataReader read;
        string x, y,p;

        public bool conf = false;

        public void logIN(String username, String pass)
        {
            SqlCommand chelog = new SqlCommand($"select stname from student where email='{username}' and passwd='{pass}' ", conect);

            conect.Open();
            chelog.ExecuteNonQuery();
            read = chelog.ExecuteReader();


            if (read.Read())
            {
                conf = true;
                conect.Close();


            }
            else
            {
                MessageBox.Show("INCORRECT USERNAME OR PASSWORD, VERIFY YOUR ENTRIES");
            }



        }

        public void signUP(string username, string pass, string n, string ph)
        {
            SqlCommand sup = new SqlCommand($"insert into student values ('{n}','{username}','{pass}','{ph}');", conect);
            conect.Open();
            try
            {
                sup.ExecuteNonQuery();
                MessageBox.Show("NEW USER ADDED SUCCESSFULLY");
            }
            catch
            {
                MessageBox.Show("NEW USER ADDED UNSUCCESSFULLY");
            }
            conect.Close();
        }

        public void trCK(string n, string sub, string to)
        {
            SqlCommand track = new SqlCommand($"insert into trck values ('{n}','{sub}','{to}');", conect);
            conect.Open();

            try
            {
                track.ExecuteNonQuery();
                MessageBox.Show("STUDYING SESSION RECORDED SUCCESSFULLY");
            }
            catch
            {
                MessageBox.Show("STUDYING SESSION RECORDED UNSUCCESSFULLY");
            }
            conect.Close();
        }
        public void act()
        {

        }

        public void nameEX(string uname, string pass)
        {

            SqlCommand getfact = new SqlCommand($"select stname,email,phone from student where email='{uname}' and passwd='{pass}';", conect);
            SqlDataReader rd;
            conect.Open();
            rd = getfact.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("stname");
            dt.Load(rd);
            x = dt.Rows[0][0].ToString();
            y = dt.Rows[0][1].ToString();
            p = dt.Rows[0][2].ToString();
            exchangeN();
            exchangemail();
            exchangephone();
            conect.Close();


        }

        public string exchangeN()
        {
            string senme = x;
            return senme;

        }

        public string exchangemail()
        {
            string senmail = y;
            return senmail;
        }

        public string exchangephone()
        {
            string sphone = p;
            return sphone;
        }

        public void selectTK(string ss, DataGridView dtaV)
        {
            SqlDataAdapter select = new SqlDataAdapter($"select trckid as ID, stu as Student, subjct as Subject, total as SessionTime from trck where stu='{ss}'", conect);
            conect.Open();
            select.Fill(data, "trck");
            dtaV.DataSource = data.Tables["trck"].DefaultView;
            conect.Close();

        }
    }
}
