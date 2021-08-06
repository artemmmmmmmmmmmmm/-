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

namespace Інформаційна_система_з_технічного_обліку
{
    public partial class Перегляд_техніки_Зав_кафедри : Form
    {
        private SqlConnection con;
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        public Перегляд_техніки_Зав_кафедри()
        {
            InitializeComponent();
        }

        

        private void Перегляд_техніки_Зав_кафедри_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @".\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "БД_інвентаризація";
            connectionStringBuilder.UserID = "artem";
            connectionStringBuilder.Password = "12345";
            con = new SqlConnection(connectionStringBuilder.ConnectionString);
            con.Open();

            dataGridView1.Rows.Clear();
            string q = "SELECT    техніка.*,типи_техніки.назва_типу from техніка,типи_техніки where техніка.idТипу_техніки = типи_техніки.idТипу_техніки";
            SqlCommand com = new SqlCommand(q, con);
            SqlDataReader reader = com.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }

        }
    }
}
