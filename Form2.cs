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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter msda = new MySqlDataAdapter("Select NOM, ID_VISIT from VISITEUR order by NOM", Program.mydb.connection);
            DataSet DS = new DataSet();   //on cree en memoire un nouveau jeu de donnees
            msda.Fill(DS);                //on remplit ce jeu de donnees
            comboBox1.DataSource = DS.Tables[0];  // lie le jeu de données à la combo
            comboBox1.DisplayMember = "NOM"; // colonne de la table apparaissant dans la liste
            comboBox1.ValueMember = "ID_VISIT";    // valeur retournée lorsqu'un élément est sélectionné
            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                MySqlCommand command = Program.mydb.connection.CreateCommand();
                command.CommandText = "Select NOM from VISITEUR where ID_VISIT =@id"; //requete avec un paramètre
                command.Parameters.AddWithValue("@id", comboBox1.SelectedValue.ToString()); //remplissage du paramètre
                                                                                            //avec le numéro du club selectionne dans la liste

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                }
            }

        }
    }
}
