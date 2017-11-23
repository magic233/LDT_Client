using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LDT_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int labelNum;
        private int labelX;
        private int labelY;
        private string labelName;
        private string labelText;
        private void Form1_Load(object sender, EventArgs e)
        {
            string constr = "server=LAPTOP-DBO5TAHI;database=soft;integrated security=SSPI";
            //string constr = "server=.;database=myschool;uid=sa;pwd=sa";
            //string constr = "data source=.;initial catalog=myschool;user id=sa;pwd=sa";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }

            labelNum = int.Parse(sc("num"));
            labelX = int.Parse(sc("x"));
            labelY = int.Parse(sc("y"));
            labelName = sc("name");
            labelText = sc("text");
            newLabel(labelName, labelText, labelX, labelY);

        }
        private string sc(string name)
        {
            string constr = "server=LAPTOP-DBO5TAHI;database=soft;integrated security=SSPI";
            //string constr = "server=.;database=myschool;uid=sa;pwd=sa";
            //string constr = "data source=.;initial catalog=myschool;user id=sa;pwd=sa";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }

            string sql = "select " + name + " from KongJian where obj = 'label'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader[name].ToString();

            }
            else
            {
                return "";
            }

        }
        private void newLabel(string name, string text, int x, int y)
        {
            Label lb = new Label();
            lb.Text = text;
            lb.Name = name;
            lb.Size = new Size(50, 50);
            lb.Location = new Point(x, y);
            lb.ContextMenuStrip = contextMenuStrip1;
            this.Controls.Add(lb);
            lb.Click += new EventHandler(this.lb_Click);
            lb.MouseDown += new MouseEventHandler(this.lb_MouseDown);
            lb.MouseMove += new MouseEventHandler(this.lb_MouseMove);
            lb.MouseUp += new MouseEventHandler(this.lb_MouseUp);
        }
    }
}
