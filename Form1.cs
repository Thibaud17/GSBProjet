using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.MySql;
namespace GSBProjet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e){}

        private void textBox2_TextChanged(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection();
            {
                
                MySqlCommand cmd = Program.mydb.connection.CreateCommand();
                
                cmd.CommandText = "select LOGIN,MDP from VISITEUR where LOGIN='" + textBox1.Text + "'and MDP='" + textBox2.Text + "'";
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Form2 Form2 = new Form2();
                        Form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Connexion refusé, vérifiez vos identifiants");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
