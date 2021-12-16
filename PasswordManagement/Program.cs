using System;
using System.Windows.Forms;

namespace PasswordManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Tuple<string, string> info = GetLoginPassword();

            if (string.IsNullOrWhiteSpace(info.Item1))
            {
                SetupMasterKey setup = new SetupMasterKey();
                if (setup.ShowDialog() != DialogResult.Cancel)
                    Application.Run(new Zipper());
            }
            else
            {
                SecurityLock c = new SecurityLock(info.Item1, info.Item2);
                if (c.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Zipper());
                }
            }
        }

        private static Tuple<string, string> GetLoginPassword()
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Properties.Resources.ConnectionString))
            using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SELECT PasswordKey, Email FROM Identification", connection))
            {
                connection.Open();
                using (System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return Tuple.Create(reader.GetString(0), reader.GetString(1));
                    }
                    else return Tuple.Create("", "");
                }
            }
        }
    }
}
