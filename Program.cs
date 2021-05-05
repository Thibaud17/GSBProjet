using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSBProjet
{
    static class Program
    {
        public static DB mydb;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            mydb = new DB("192.168.2.4", "bdamarionneau3", "sqlamarionneau", "savary");
            if (Program.mydb.OpenConnection() != true)
            {
                MessageBox.Show("Connexion a la BD impossible", "Connexion a la BD impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}


